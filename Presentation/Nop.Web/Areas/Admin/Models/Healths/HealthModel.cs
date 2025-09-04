using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Healths
{
    /// <summary>
    /// Represents a health model
    /// </summary>
    public partial record HealthModel : BaseNopEntityModel
    {
        public HealthModel()
        {
            AvailableApplicants = new List<SelectListItem>();
            AvailableRelevantConditions = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Health.Fields.ApplicantId")]
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Health.Fields.RelevantConditionId")]
        public int RelevantConditionId { get; set; }
        public string RelevantCondition { get; set; }
        public IList<SelectListItem> AvailableRelevantConditions { get; set; }

        [NopResourceDisplayName("Admin.Health.Fields.Notes")]
        public string Notes { get; set; }

        [NopResourceDisplayName("Admin.Health.Fields.CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [NopResourceDisplayName("Admin.Health.Fields.CreatedBy")]
        public string CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Health.Fields.UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [NopResourceDisplayName("Admin.Health.Fields.CreatedBy")]
        public string UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Health.Fields.Record1Id")]
        [UIHint("Download")]
        public int Record1Id { get; set; }

        [NopResourceDisplayName("Admin.Health.Fields.Record2Id")]
        [UIHint("Download")]
        public int Record2Id { get; set; }
    }
}