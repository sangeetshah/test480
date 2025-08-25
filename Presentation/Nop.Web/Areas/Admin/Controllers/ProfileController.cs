using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Polls;
using Nop.Core.Domain.Profiles;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Profiles;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Profiles;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers;

public partial class ProfileController : BaseAdminController
{
    #region Fields

    protected readonly IProfileModelFactory _profileModelFactory;
    protected readonly IWorkContext _workContext;
    protected readonly IProfileService _profileService;
    protected readonly INotificationService _notificationService;
    protected readonly ILocalizationService _localizationService;

    #endregion

    #region Ctor

    public ProfileController(IProfileModelFactory profileModelFactory,
                             IWorkContext workContext,
                             IProfileService profileService,
                             INotificationService notificationService,
                             ILocalizationService localizationService)
    {
        _profileModelFactory = profileModelFactory;
        _workContext = workContext;
        _profileService = profileService;
        _notificationService = notificationService;
        _localizationService = localizationService;
    }

    #endregion

    #region Methods

    [CheckPermission(StandardPermission.Profile.ACCESS_PROFILE)]
    public virtual async Task<IActionResult> Create(string applicantId)
    {
        Profile profile = null;
        if (!string.IsNullOrEmpty(applicantId))
        {
            profile = await _profileService.GetProfileByApplicantIdAsync(applicantId);

            if (profile == null)
            {
                _notificationService.ErrorNotification(await _localizationService.GetResourceAsync("Admin.Profile.Fields.ApplicantId.NotExists"));
                return RedirectToAction("Create");
            }
        }

        //prepare model
        var model = await _profileModelFactory.PrepareProfileModelAsync(new ProfileModel(), profile);

        return View(model);
    }

    [HttpPost]
    [CheckPermission(StandardPermission.Profile.ACCESS_PROFILE)]
    public virtual async Task<IActionResult> Create(ProfileModel model)
    {
        var existProfile = await _profileService.GetProfileByApplicantIdAsync(model.ApplicantId);
        if (existProfile != null && existProfile.Id != model.Id)
            ModelState.AddModelError(nameof(model.ApplicantId), await _localizationService.GetResourceAsync("Admin.Profile.Fields.ApplicantId.Exists"));

        if (ModelState.IsValid)
        {
            var customer = await _workContext.GetCurrentCustomerAsync();            

            if (model.Id == 0)
            {
                var profile = model.ToEntity<Profile>();

                profile.CreatedAt = DateTime.UtcNow;
                profile.UpdatedAt = DateTime.UtcNow;
                profile.CreatedBy = customer.Email;
                profile.UpdatedBy = string.Empty;

                await _profileService.InsertProfileAsync(profile);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Profile.Created"));
            }
            else
            {
                existProfile = model.ToEntity(existProfile);

                existProfile.UpdatedAt = DateTime.UtcNow;
                existProfile.UpdatedBy = customer.Email;

                await _profileService.UpdateProfileAsync(existProfile);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Profile.Updated"));
            }

            return RedirectToAction("Create");
        }

        //prepare model
        model = await _profileModelFactory.PrepareProfileModelAsync(model, existProfile);

        //if we got this far, something failed, redisplay form
        return View(model);
    }

    #endregion
}