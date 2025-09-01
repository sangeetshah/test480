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
            RuleFor(x => x.ApplicantId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.ApplicantId.Required"));
            RuleFor(x => x.EmploymentStatusId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.StandardId.Required"));
            RuleFor(x => x.JobTitle).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.CourseName.Required"));
            RuleFor(x => x.EmployerOrBusiness).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.FieldOfStudy.Required"));

            SetDatabaseValidationRules<Work>();
        }
    }
}