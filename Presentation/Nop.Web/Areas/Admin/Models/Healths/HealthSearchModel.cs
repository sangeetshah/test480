using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Healths
{
    /// <summary>
    /// Represents an health search model
    /// </summary>
    public partial record HealthSearchModel : BaseSearchModel
    {
        public HealthSearchModel()
        {
            AvailableApplicants = new List<SelectListItem>();
            AvailableRelevantConditions = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Health.List.SearchApplicantId")]
        public int SearchApplicantId { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Health.List.SearchRelevantConditionId")]
        public int SearchRelevantConditionId { get; set; }
        public IList<SelectListItem> AvailableRelevantConditions { get; set; }
    }
}