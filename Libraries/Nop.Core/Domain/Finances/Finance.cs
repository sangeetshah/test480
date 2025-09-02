
namespace Nop.Core.Domain.Finances
{
    /// <summary>
    /// Represents a finance
    /// </summary>
    public partial class Finance : BaseEntity
    {
        public int ApplicantId { get; set; }

        public int RecordTypeId { get; set; }

        public string BankName { get; set; }

        public string AccountMask { get; set; }

        public decimal Currency { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        public decimal AvgBalance { get; set; }

        public int AssetTypeId { get; set; }

        public decimal Amount { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the record type
        /// </summary>
        public RecordTypeEnum RecordTypeEnum
        {
            get => (RecordTypeEnum)RecordTypeId;
            set => RecordTypeId = (int)value;
        }

        /// <summary>
        /// Gets or sets the record type
        /// </summary>
        public AssetTypeEnum AssetTypeEnum
        {
            get => (AssetTypeEnum)AssetTypeId;
            set => AssetTypeId = (int)value;
        }
    }
}