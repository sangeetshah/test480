using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Finances
{
    /// <summary>
    /// Represents a finance model
    /// </summary>
    public partial record FinanceModel : BaseNopEntityModel
    {
        public FinanceModel()
        {
            AvailableApplicants = new List<SelectListItem>();
            AvailableRecordTypes = new List<SelectListItem>();
            AvailableAssetTypes = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Finance.Fields.ApplicantId")]
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.RecordTypeId")]
        public int RecordTypeId { get; set; }
        public string RecordType { get; set; }
        public IList<SelectListItem> AvailableRecordTypes { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.BankName")]
        public string BankName { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.AccountMask")]
        public string AccountMask { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.Currency")]
        public decimal Currency { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.PeriodStart")]
        [UIHint("DateTimeNullable")]
        public DateTime? PeriodStart { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.PeriodEnd")]
        [UIHint("DateTimeNullable")]
        public DateTime? PeriodEnd { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.AvgBalance")]
        public decimal AvgBalance { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.AssetTypeId")]
        public int AssetTypeId { get; set; }
        public string AssetType { get; set; }
        public IList<SelectListItem> AvailableAssetTypes { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.Amount")]
        public decimal Amount { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.Notes")]
        public string Notes { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.CreatedBy")]
        public string CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.CreatedBy")]
        public string UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Finance.Fields.DocumentId")]
        [UIHint("Download")]
        public int DocumentId { get; set; }
    }
}