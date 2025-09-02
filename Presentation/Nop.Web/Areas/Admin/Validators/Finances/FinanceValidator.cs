using FluentValidation;
using Nop.Core.Domain.Finances;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Finances;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Finances
{
    public partial class FinanceValidator : BaseNopValidator<FinanceModel>
    {
        public FinanceValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ApplicantId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Finance.Fields.ApplicantId.Required"));
            RuleFor(x => x.RecordTypeId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Finance.Fields.RecordTypeId.Required"));
            RuleFor(x => x.BankName).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Finance.Fields.BankName.Required"));
            RuleFor(x => x.AccountMask).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Finance.Fields.AccountMask.Required"));
            RuleFor(x => x.AssetTypeId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Finance.Fields.AssetTypeId.Required"));
            RuleFor(x => x.Amount).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Finance.Fields.Amount.Required"));

            SetDatabaseValidationRules<Finance>();
        }
    }
}