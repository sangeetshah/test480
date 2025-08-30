
namespace Nop.Core.Domain.Educations
{
    public class Education : BaseEntity
    {
        public int ApplicantId { get; set; }
        public int StandardId { get; set; }
        public string CourseName { get; set; }
        public string FieldOfStudy { get; set; }
        public string Institution { get; set; }
        public string University { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public int GraduationYear { get; set; }
        public decimal GPA { get; set; }
        public bool IsHighest { get; set; }
        public DateTime UploadedAt { get; set; }
        public string UploadedBy { get; set; }
        public int Certificate1Id { get; set; }
        public int Certificate2Id { get; set; }

        /// <summary>
        /// Gets or sets the standard
        /// </summary>
        public StandardEnum StandardEnum
        {
            get => (StandardEnum)StandardId;
            set => StandardId = (int)value;
        }
    }
}