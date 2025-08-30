using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Educations
{
    /// <summary>
    /// Represents an education search model
    /// </summary>
    public partial record EducationSearchModel : BaseSearchModel
    {
        public EducationSearchModel()
        {
            AvailableApplicants = new List<SelectListItem>();
            AvailableStandards = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Education.List.SearchApplicantId")]
        public int SearchApplicantId { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Education.List.SearchStandardId")]
        public int SearchStandardId { get; set; }
        public IList<SelectListItem> AvailableStandards { get; set; }
    }
}