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
        RuleFor(x => x.Email).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.Email.Required"));
        RuleFor(x => x.Email).IsEmailAddress().WithMessageAwait(localizationService.GetResourceAsync("Admin.Common.WrongEmail"));
        RuleFor(x => x.GenderCode).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.GenderCode.Required"));
        RuleFor(x => x.ApplicantId).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.GivenName).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.FamilyName).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.MaritalStatusCode).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.PrimaryCitizenship).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.AadharNo).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Email).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Mobile1).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Mobile2).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.WhtasppMobile).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Address1Line1).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Address1Line2).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Address1City).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Address1PostalCode).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Address2Line1).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Address2Line2).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Address2City).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.Address2PostalCode).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.FacebookId1).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.FacebookId2).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.InstagramId1).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.InstagramId2).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.LinkedInURL).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));
        RuleFor(x => x.TwitterId).MaximumLength(150).WithMessageAwait(localizationService.GetResourceAsync("Admin.Profile.Fields.MaximumCharsAllowed"));

        SetDatabaseValidationRules<Profile>();
    }
}