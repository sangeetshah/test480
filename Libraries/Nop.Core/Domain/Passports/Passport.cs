
namespace Nop.Core.Domain.Passports
{
    /// <summary>
    /// Represents a passport
    /// </summary>
    public partial class Passport : BaseEntity
    {
        public int ApplicantId { get; set; }

        public string PassportNumber { get; set; }

        public string IssuingCountry { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string BirthPlace { get; set; }

        public string PlaceOfIssue { get; set; }

        public bool IsPrimary { get; set; }

        public DateTime UploadedAt { get; set; }

        public string UploadedBy { get; set; }

        public int FileId { get; set; }
    }
}