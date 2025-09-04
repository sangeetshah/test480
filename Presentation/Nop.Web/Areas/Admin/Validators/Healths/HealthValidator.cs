using FluentValidation;
using Nop.Core.Domain.Healths;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Healths;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Healths
{
    public partial class HealthValidator : BaseNopValidator<HealthModel>
    {
        public HealthValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ApplicantId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Health.Fields.ApplicantId.Required"));
            RuleFor(x => x.RelevantConditionId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Health.Fields.RelevantConditionId.Required"));

            SetDatabaseValidationRules<Health>();
        }
    }
}