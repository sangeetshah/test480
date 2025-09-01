using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Works
{
    /// <summary>
    /// Represents an work search model
    /// </summary>
    public partial record WorkSearchModel : BaseSearchModel
    {
        public WorkSearchModel()
        {
            AvailableApplicants = new List<SelectListItem>();
            AvailableEmploymentStatuses = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Work.List.SearchApplicantId")]
        public int SearchApplicantId { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Work.List.SearchEmploymentStatusId")]
        public int SearchEmploymentStatusId { get; set; }
        public IList<SelectListItem> AvailableEmploymentStatuses { get; set; }
    }
}