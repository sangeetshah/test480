using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Educations;
using Nop.Services.Educations;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Educations;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class EducationController : BaseAdminController
    {
        #region Fields

        protected readonly IEducationModelFactory _educationModelFactory;
        protected readonly IEducationService _educationService;
        protected readonly INotificationService _notificationService;
        protected readonly ILocalizationService _localizationService;
        protected readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public EducationController(IEducationModelFactory educationModelFactory,
                                   IEducationService educationService,
                                   INotificationService notificationService,
                                   ILocalizationService localizationService,
                                   IWorkContext workContext)
        {
            _educationModelFactory = educationModelFactory;
            _educationService = educationService;
            _notificationService = notificationService;
            _localizationService = localizationService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [CheckPermission(StandardPermission.Education.ACCESS_EDUCATION)]
        public virtual async Task<IActionResult> List()
        {
            //prepare model
            var model = await _educationModelFactory.PrepareEducationSearchModelAsync(new EducationSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Education.ACCESS_EDUCATION)]
        public virtual async Task<IActionResult> List(EducationSearchModel searchModel)
        {
            //prepare model
            var model = await _educationModelFactory.PrepareEducationListModelAsync(searchModel);

            return Json(model);
        }

        [CheckPermission(StandardPermission.Education.ACCESS_EDUCATION)]
        public virtual async Task<IActionResult> Create()
        {
            //prepare model
            var model = await _educationModelFactory.PrepareEducationModelAsync(new EducationModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        [CheckPermission(StandardPermission.Education.ACCESS_EDUCATION)]
        public virtual async Task<IActionResult> Create(EducationModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var education = model.ToEntity<Education>();

                var customer = await _workContext.GetCurrentCustomerAsync();

                education.UploadedBy = customer.Email;
                education.UploadedAt = DateTime.UtcNow;

                await _educationService.InsertEducationAsync(education);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Education.Created"));

                return continueEditing ? RedirectToAction("Edit", new { id = education.Id }) : RedirectToAction("List");
            }

            //prepare model
            model = await _educationModelFactory.PrepareEducationModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [CheckPermission(StandardPermission.Education.ACCESS_EDUCATION)]
        public virtual async Task<IActionResult> Edit(int id)
        {
            //try to get an education with the specified id
            var education = await _educationService.GetEducationByIdAsync(id);
            if (education == null)
                return RedirectToAction("List");

            //prepare model
            var model = await _educationModelFactory.PrepareEducationModelAsync(null, education);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [CheckPermission(StandardPermission.Education.ACCESS_EDUCATION)]
        public virtual async Task<IActionResult> Edit(EducationModel model, bool continueEditing)
        {
            //try to get an education with the specified id
            var education = await _educationService.GetEducationByIdAsync(model.Id);
            if (education == null)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                education = model.ToEntity(education);

                var customer = await _workContext.GetCurrentCustomerAsync();

                education.UploadedBy = customer.Email;
                education.UploadedAt = DateTime.UtcNow;

                await _educationService.UpdateEducationAsync(education);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Education.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = education.Id });
            }

            //prepare model
            model = await _educationModelFactory.PrepareEducationModelAsync(model, education);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            //try to get an education with the specified id
            var education = await _educationService.GetEducationByIdAsync(id);
            if (education == null)
                return RedirectToAction("List");

            await _educationService.DeleteEducationAsync(education);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Education.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
                return NoContent();

            var educations = await _educationService.GetEducationsByIdsAsync(selectedIds.ToArray());
            if (educations.Any())
                await _educationService.DeleteEducationsAsync(educations);

            return Json(new { Result = true });
        }

        #endregion
    }
}