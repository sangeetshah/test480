
namespace Nop.Core.Domain.Works
{
    /// <summary>
    /// Represents a work
    /// </summary>
    public partial class Work : BaseEntity
    {
        public int ApplicantId { get; set; }

        public int EmploymentStatusId { get; set; }

        public string JobTitle { get; set; }

        public string EmployerOrBusiness { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal AnnunalIncomeAmount { get; set; }

        public bool TaxFiled { get; set; }

        public decimal TaxDeclaredIncome { get; set; }

        public string TaxCurrency { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public int OfferLetterId { get; set; }

        public int RelievingLetterId { get; set; }

        /// <summary>
        /// Gets or sets the employment status
        /// </summary>
        public EmploymentStatusEnum EmploymentStatusEnum
        {
            get => (EmploymentStatusEnum)EmploymentStatusId;
            set => EmploymentStatusId = (int)value;
        }
    }
}