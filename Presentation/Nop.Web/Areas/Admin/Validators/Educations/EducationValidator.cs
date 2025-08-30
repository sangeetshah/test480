using FluentValidation;
using Nop.Core.Domain.Educations;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Educations;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Educations
{
    public partial class EducationValidator : BaseNopValidator<EducationModel>
    {
        public EducationValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ApplicantId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.ApplicantId.Required"));
            RuleFor(x => x.StandardId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.StandardId.Required"));
            RuleFor(x => x.CourseName).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.CourseName.Required"));
            RuleFor(x => x.FieldOfStudy).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.FieldOfStudy.Required"));
            RuleFor(x => x.Institution).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.Institution.Required"));
            RuleFor(x => x.University).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.University.Required"));
            RuleFor(x => x.GraduationYear).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Education.Fields.GraduationYear.Required"));

            SetDatabaseValidationRules<Education>();
        }
    }
}