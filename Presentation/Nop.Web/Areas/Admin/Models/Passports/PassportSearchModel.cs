using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Passports
{
    /// <summary>
    /// Represents an passport search model
    /// </summary>
    public partial record PassportSearchModel : BaseSearchModel
    {
        public PassportSearchModel() 
        {
            AvailableApplicants = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Passport.List.SearchApplicantId")]
        public int SearchApplicantId { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Passport.List.SearchPassportNumber")]
        public string SearchPassportNumber { get; set; }
    }
}