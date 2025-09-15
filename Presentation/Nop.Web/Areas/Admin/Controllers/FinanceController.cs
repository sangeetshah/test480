using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Finances;
using Nop.Services.Finances;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Profiles;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Finances;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class FinanceController : BaseAdminController
    {
        #region Fields

        protected readonly IFinanceModelFactory _financeModelFactory;
        protected readonly IFinanceService _financeService;
        protected readonly INotificationService _notificationService;
        protected readonly ILocalizationService _localizationService;
        protected readonly IWorkContext _workContext;
        protected readonly IProfileService _profileService;

        #endregion

        #region Ctor

        public FinanceController(IFinanceModelFactory financeModelFactory,
                                 IFinanceService financeService,
                                 INotificationService notificationService,
                                 ILocalizationService localizationService,
                                 IWorkContext workContext,
                                 IProfileService profileService)
        {
            _financeModelFactory = financeModelFactory;
            _financeService = financeService;
            _notificationService = notificationService;
            _localizationService = localizationService;
            _workContext = workContext;
            _profileService = profileService;
        }
        
        #endregion

        #region Methods

        [CheckPermission(StandardPermission.Finance.ACCESS_FINANCE)]
        public virtual async Task<IActionResult> List()
        {
            //prepare model
            var model = await _financeModelFactory.PrepareFinanceSearchModelAsync(new FinanceSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Finance.ACCESS_FINANCE)]
        public virtual async Task<IActionResult> List(FinanceSearchModel searchModel)
        {
            //prepare model
            var model = await _financeModelFactory.PrepareFinanceListModelAsync(searchModel);

            return Json(model);
        }

        [CheckPermission(StandardPermission.Finance.FINANCE_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Create()
        {
            //prepare model
            var model = await _financeModelFactory.PrepareFinanceModelAsync(new FinanceModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        [CheckPermission(StandardPermission.Finance.FINANCE_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Create(FinanceModel model, bool continueEditing)
        {
            var existFinance = await _financeService.GetFinanceByApplicantIdRecordTypeIdAsync(model.ApplicantId, model.RecordTypeId);
            if (existFinance != null)
                ModelState.AddModelError("", await _localizationService.GetResourceAsync("Admin.Finance.Exists"));

            if (ModelState.IsValid)
            {
                var finance = model.ToEntity<Finance>();

                finance.CreatedAt = DateTime.UtcNow;
                finance.CreatedBy = (await _workContext.GetCurrentCustomerAsync()).Email;

                await _financeService.InsertFinanceAsync(finance);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Finance.Created"));

                return continueEditing ? RedirectToAction("Edit", new { id = finance.Id }) : RedirectToAction("List");
            }

            //prepare model
            model = await _financeModelFactory.PrepareFinanceModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [CheckPermission(StandardPermission.Finance.FINANCE_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Edit(int id)
        {
            //try to get an finance with the specified id
            var finance = await _financeService.GetFinanceByIdAsync(id);
            if (finance == null)
                return RedirectToAction("List");

            //prepare model
            var model = await _financeModelFactory.PrepareFinanceModelAsync(null, finance);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [CheckPermission(StandardPermission.Finance.FINANCE_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Edit(FinanceModel model, bool continueEditing)
        {
            //try to get an finance with the specified id
            var finance = await _financeService.GetFinanceByIdAsync(model.Id);
            if (finance == null)
                return RedirectToAction("List");

            var existFinance = await _financeService.GetFinanceByApplicantIdRecordTypeIdAsync(model.ApplicantId, model.RecordTypeId);
            if (existFinance != null && existFinance.Id != finance.Id)
                ModelState.AddModelError("", await _localizationService.GetResourceAsync("Admin.Finance.Exists"));

            if (ModelState.IsValid)
            {
                finance = model.ToEntity(finance);

                var customer = await _workContext.GetCurrentCustomerAsync();

                finance.UpdatedAt = DateTime.UtcNow;
                finance.UpdatedBy = customer.Email;                

                await _financeService.UpdateFinanceAsync(finance);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Finance.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = finance.Id });
            }

            //prepare model
            model = await _financeModelFactory.PrepareFinanceModelAsync(model, finance);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Finance.FINANCE_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            //try to get an finance with the specified id
            var finance = await _financeService.GetFinanceByIdAsync(id);
            if (finance == null)
                return RedirectToAction("List");

            await _financeService.DeleteFinanceAsync(finance);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Finance.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Finance.FINANCE_CREATE_EDIT_DELETE)]
        public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
                return NoContent();

            var finances = await _financeService.GetFinancesByIdsAsync(selectedIds.ToArray());
            if (finances.Any())
                await _financeService.DeleteFinancesAsync(finances);

            return Json(new { Result = true });
        }

        [HttpPost]
        public virtual async Task<IActionResult> GetFinanceCompletionPercentage(string applicantId)
        {
            var profile = await _profileService.GetProfileByApplicantIdAsync(applicantId);

            var percentage = await _financeService.GetFinanceCompletionPercentageAsync(profile != null ? profile.Id : 0);

            return Json(new
            {
                Filled = percentage,
                Empty = 100 - percentage
            });
        }

        #endregion
    }
}