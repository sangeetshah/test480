using FluentValidation;
using Nop.Core.Domain.Works;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Works;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Works
{
    public partial class WorkValidator : BaseNopValidator<WorkModel>
    {
        public WorkValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ApplicantId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Work.Fields.ApplicantId.Required"));
            RuleFor(x => x.EmploymentStatusId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Work.Fields.EmploymentStatusId.Required"));
            RuleFor(x => x.JobTitle).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Work.Fields.JobTitle.Required"));
            RuleFor(x => x.EmployerOrBusiness).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Work.Fields.EmployerOrBusiness.Required"));

            SetDatabaseValidationRules<Work>();
        }
    }
}