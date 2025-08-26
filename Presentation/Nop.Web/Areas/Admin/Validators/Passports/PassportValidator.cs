using FluentValidation;
using Nop.Core.Domain.Passports;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Passports;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Passports
{
    public partial class PassportValidator : BaseNopValidator<PassportModel>
    {
        public PassportValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ApplicantId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Passport.Fields.ApplicantId.Required"));
            RuleFor(x => x.PassportNumber).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Passport.Fields.PassportNumber.Required"));
            RuleFor(x => x.IssuingCountry).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Passport.Fields.IssuingCountry.Required"));
            RuleFor(x => x.PlaceOfIssue).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Passport.Fields.IssuingCountry.Required"));

            SetDatabaseValidationRules<Passport>();
        }
    }
}