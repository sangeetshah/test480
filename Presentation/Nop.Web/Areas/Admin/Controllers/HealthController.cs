using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Healths;
using Nop.Services.Healths;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Profiles;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Healths;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class HealthController : BaseAdminController
    {
        #region Fields

        protected readonly IHealthModelFactory _healthModelFactory;
        protected readonly IHealthService _healthService;
        protected readonly INotificationService _notificationService;
        protected readonly ILocalizationService _localizationService;
        protected readonly IWorkContext _workContext;
        protected readonly IProfileService _profileService;

        #endregion

        #region Ctor

        public HealthController(IHealthModelFactory healthModelFactory,
                                IHealthService healthService,
                                INotificationService notificationService,
                                ILocalizationService localizationService,
                                IWorkContext workContext,
                                IProfileService profileService)
        {
            _healthModelFactory = healthModelFactory;
            _healthService = healthService;
            _notificationService = notificationService;
            _localizationService = localizationService;
            _workContext = workContext;
            _profileService = profileService;
        }
        
        #endregion

        #region Methods

        [CheckPermission(StandardPermission.Health.ACCESS_HEALTH)]
        public virtual async Task<IActionResult> List()
        {
            //prepare model
            var model = await _healthModelFactory.PrepareHealthSearchModelAsync(new HealthSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Health.ACCESS_HEALTH)]
        public virtual async Task<IActionResult> List(HealthSearchModel searchModel)
        {
            //prepare model
            var model = await _healthModelFactory.PrepareHealthListModelAsync(searchModel);

            return Json(model);
        }

        [CheckPermission(StandardPermission.Health.HEALTH_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Create()
        {
            //prepare model
            var model = await _healthModelFactory.PrepareHealthModelAsync(new HealthModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        [CheckPermission(StandardPermission.Health.HEALTH_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Create(HealthModel model, bool continueEditing)
        {
            var existHealth = await _healthService.GetHealthByApplicantIdRelevantConditionIdAsync(model.ApplicantId, model.RelevantConditionId);
            if (existHealth != null)
                ModelState.AddModelError("", await _localizationService.GetResourceAsync("Admin.Health.Exists"));

            if (ModelState.IsValid)
            {
                var health = model.ToEntity<Health>();

                health.CreatedAt = DateTime.UtcNow;
                health.CreatedBy = (await _workContext.GetCurrentCustomerAsync()).Email;

                await _healthService.InsertHealthAsync(health);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Health.Created"));

                return continueEditing ? RedirectToAction("Edit", new { id = health.Id }) : RedirectToAction("List");
            }

            //prepare model
            model = await _healthModelFactory.PrepareHealthModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [CheckPermission(StandardPermission.Health.HEALTH_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Edit(int id)
        {
            //try to get an health with the specified id
            var health = await _healthService.GetHealthByIdAsync(id);
            if (health == null)
                return RedirectToAction("List");

            //prepare model
            var model = await _healthModelFactory.PrepareHealthModelAsync(null, health);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [CheckPermission(StandardPermission.Health.HEALTH_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Edit(HealthModel model, bool continueEditing)
        {
            //try to get an health with the specified id
            var health = await _healthService.GetHealthByIdAsync(model.Id);
            if (health == null)
                return RedirectToAction("List");

            var existHealth = await _healthService.GetHealthByApplicantIdRelevantConditionIdAsync(model.ApplicantId, model.RelevantConditionId);
            if (existHealth != null && existHealth.Id != health.Id)
                ModelState.AddModelError("", await _localizationService.GetResourceAsync("Admin.Health.Exists"));

            if (ModelState.IsValid)
            {
                health = model.ToEntity(health);

                var customer = await _workContext.GetCurrentCustomerAsync();

                health.UpdatedAt = DateTime.UtcNow;
                health.UpdatedBy = customer.Email;                

                await _healthService.UpdateHealthAsync(health);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Health.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = health.Id });
            }

            //prepare model
            model = await _healthModelFactory.PrepareHealthModelAsync(model, health);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Health.HEALTH_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            //try to get an health with the specified id
            var health = await _healthService.GetHealthByIdAsync(id);
            if (health == null)
                return RedirectToAction("List");

            await _healthService.DeleteHealthAsync(health);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Health.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Health.HEALTH_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
                return NoContent();

            var healths = await _healthService.GetHealthsByIdsAsync(selectedIds.ToArray());
            if (healths.Any())
                await _healthService.DeleteHealthsAsync(healths);

            return Json(new { Result = true });
        }

        [HttpPost]
        public virtual async Task<IActionResult> GetHealthCompletionPercentage(string applicantId)
        {
            var profile = await _profileService.GetProfileByApplicantIdAsync(applicantId);

            var percentage = await _healthService.GetHealthCompletionPercentageAsync(profile != null ? profile.Id : 0);

            return Json(new
            {
                Filled = percentage,
                Empty = 100 - percentage
            });
        }

        #endregion
    }
}