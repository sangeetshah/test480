using FluentValidation;
using Nop.Core.Domain.Profiles;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Profiles;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Profiles;

public partial class ProfileValidator : BaseNopValidator<ProfileModel>
{
    public ProfileValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.ApplicantId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.ApplicantId.Required"));
        RuleFor(x => x.Email).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.ApplicantId.Required"));
        RuleFor(x => x.Email).IsEmailAddress().WithMessageAwait(localizationService.GetResourceAsync("Admin.Common.WrongEmail"));

        SetDatabaseValidationRules<Profile>();
    }
}