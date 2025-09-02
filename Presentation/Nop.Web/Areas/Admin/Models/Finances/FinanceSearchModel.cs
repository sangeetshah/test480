using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Finances
{
    /// <summary>
    /// Represents an finance search model
    /// </summary>
    public partial record FinanceSearchModel : BaseSearchModel
    {
        public FinanceSearchModel()
        {
            AvailableApplicants = new List<SelectListItem>();
            AvailableRecordTypes = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Finance.List.SearchApplicantId")]
        public int SearchApplicantId { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Finance.List.SearchRecordTypeId")]
        public int SearchRecordTypeId { get; set; }
        public IList<SelectListItem> AvailableRecordTypes { get; set; }
    }
}