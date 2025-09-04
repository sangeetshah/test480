
namespace Nop.Core.Domain.Healths
{
    public class Health : BaseEntity
    {
        public int ApplicantId { get; set; }

        public int RelevantConditionId { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public int Record1Id { get; set; }

        public int Record2Id { get; set; }

        /// <summary>
        /// Gets or sets the standard
        /// </summary>
        public RelevantConditionEnum RelevantConditionEnum
        {
            get => (RelevantConditionEnum)RelevantConditionId;
            set => RelevantConditionId = (int)value;
        }
    }
}