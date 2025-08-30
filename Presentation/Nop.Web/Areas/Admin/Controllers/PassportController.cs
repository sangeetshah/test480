using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Passports;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Passports;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Passports;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class PassportController : BaseAdminController
    {
        #region Fields

        protected readonly IPassportModelFactory _passportModelFactory;
        protected readonly IPassportService _passportService;
        protected readonly INotificationService _notificationService;
        protected readonly ILocalizationService _localizationService;
        protected readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public PassportController(IPassportModelFactory passportModelFactory,
                                  IPassportService passportService,
                                  INotificationService notificationService,
                                  ILocalizationService localizationService,
                                  IWorkContext workContext)
        {
            _passportModelFactory = passportModelFactory;
            _passportService = passportService;
            _notificationService = notificationService;
            _localizationService = localizationService;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> List()
        {
            //prepare model
            var model = await _passportModelFactory.PreparePassportSearchModelAsync(new PassportSearchModel());

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> List(PassportSearchModel searchModel)
        {
            //prepare model
            var model = await _passportModelFactory.PreparePassportListModelAsync(searchModel);

            return Json(model);
        }

        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> Create()
        {
            //prepare model
            var model = await _passportModelFactory.PreparePassportModelAsync(new PassportModel(), null);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> Create(PassportModel model, bool continueEditing)
        {
            var existPassport = await _passportService.GetPassportByPassportNumberAsync(model.PassportNumber);
            if (existPassport != null)
                ModelState.AddModelError(nameof(model.PassportNumber), await _localizationService.GetResourceAsync("Admin.Passport.Fields.PassportNumber.Exists"));

            if (ModelState.IsValid)
            {
                var passport = model.ToEntity<Passport>();

                var customer = await _workContext.GetCurrentCustomerAsync();

                passport.UploadedBy = customer.Email;
                passport.UploadedAt = DateTime.UtcNow;

                await _passportService.InsertPassportAsync(passport);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Passport.Created"));

                return continueEditing ? RedirectToAction("Edit", new { id = passport.Id }) : RedirectToAction("List");
            }

            //prepare model
            model = await _passportModelFactory.PreparePassportModelAsync(model, null);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> Edit(int id)
        {
            //try to get an passport with the specified id
            var passport = await _passportService.GetPassportByIdAsync(id);
            if (passport == null)
                return RedirectToAction("List");

            //prepare model
            var model = await _passportModelFactory.PreparePassportModelAsync(null, passport);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> Edit(PassportModel model, bool continueEditing)
        {
            //try to get an passport with the specified id
            var passport = await _passportService.GetPassportByIdAsync(model.Id);
            if (passport == null)
                return RedirectToAction("List");

            var existPassport = await _passportService.GetPassportByPassportNumberAsync(model.PassportNumber);
            if (existPassport != null && existPassport.Id != passport.Id)
                ModelState.AddModelError(nameof(model.PassportNumber), await _localizationService.GetResourceAsync("Admin.Passport.Fields.PassportNumber.Exists"));

            if (ModelState.IsValid)
            {
                passport = model.ToEntity(passport);

                var customer = await _workContext.GetCurrentCustomerAsync();

                passport.UploadedBy = customer.Email;
                passport.UploadedAt = DateTime.UtcNow;

                await _passportService.UpdatePassportAsync(passport);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Passport.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = passport.Id });
            }

            //prepare model
            model = await _passportModelFactory.PreparePassportModelAsync(model, passport);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        //delete
        [HttpPost]
        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            //try to get an passport with the specified id
            var passport = await _passportService.GetPassportByIdAsync(id);
            if (passport == null)
                return RedirectToAction("List");

            await _passportService.DeletePassportAsync(passport);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Passport.Deleted"));

            return RedirectToAction("List");
        }

        [HttpPost]
        [CheckPermission(StandardPermission.Passport.ACCESS_PASSPORT)]
        public virtual async Task<IActionResult> DeleteSelected(ICollection<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
                return NoContent();

            var passports = await _passportService.GetPassportsByIdsAsync(selectedIds.ToArray());
            if (passports.Any())
                await _passportService.DeletePassportsAsync(passports);

            return Json(new { Result = true });
        }

        #endregion
    }
}