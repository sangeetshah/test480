using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{
    public partial class ChangePasswordController : BaseAdminController
    {
        #region Fields

        protected readonly ICustomerService _customerService;
        protected readonly IWorkContext _workContext;
        protected readonly CustomerSettings _customerSettings;
        protected readonly ICustomerRegistrationService _customerRegistrationService;
        protected readonly INotificationService _notificationService;
        protected readonly ILocalizationService _localizationService;
        protected readonly ICustomerModelFactory _customerModelFactory;

        #endregion

        #region Ctor

        public ChangePasswordController(ICustomerService customerService,
                                        IWorkContext workContext,
                                        CustomerSettings customerSettings,
                                        ICustomerRegistrationService customerRegistrationService,
                                        INotificationService notificationService,
                                        ILocalizationService localizationService,
                                        ICustomerModelFactory customerModelFactory)
        {
            _customerService = customerService;
            _workContext = workContext;
            _customerSettings = customerSettings;
            _customerRegistrationService = customerRegistrationService;
            _notificationService = notificationService;
            _localizationService = localizationService;
            _customerModelFactory = customerModelFactory;
        }

        #endregion

        #region Methods

        [CheckPermission(StandardPermission.ChangePassword.ACCESS_CHANGE_PASSWORD)]
        public virtual async Task<IActionResult> Edit()
        {
            var customer = await _workContext.GetCurrentCustomerAsync();
            if (!await _customerService.IsRegisteredAsync(customer))
                return Challenge();

            var model = await _customerModelFactory.PrepareChangePasswordModelAsync(customer);

            return View(model);
        }

        [HttpPost]
        [CheckPermission(StandardPermission.ChangePassword.ACCESS_CHANGE_PASSWORD)]
        public virtual async Task<IActionResult> Edit(ChangePasswordModel model)
        {
            var customer = await _workContext.GetCurrentCustomerAsync();
            if (!await _customerService.IsRegisteredAsync(customer))
                return Challenge();

            if (ModelState.IsValid)
            {
                var changePasswordRequest = new ChangePasswordRequest(customer.Email,
                    true, _customerSettings.DefaultPasswordFormat, model.NewPassword, model.OldPassword);
                var changePasswordResult = await _customerRegistrationService.ChangePasswordAsync(changePasswordRequest);
                if (changePasswordResult.Success)
                {
                    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Account.ChangePassword.Success"));

                    //authenticate customer after changing password
                    await _customerRegistrationService.SignInCustomerAsync(customer, null, true);

                    return RedirectToAction("Edit");
                }

                //errors
                foreach (var error in changePasswordResult.Errors)
                    ModelState.AddModelError("", error);
            }

            //If we got this far, something failed, redisplay form
            model = await _customerModelFactory.PrepareChangePasswordModelAsync(customer);

            return View(model);
        }

        #endregion
    }
}