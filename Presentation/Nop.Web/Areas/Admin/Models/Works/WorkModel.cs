using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Works
{
    /// <summary>
    /// Represents a work model
    /// </summary>
    public partial record WorkModel : BaseNopEntityModel
    {
        public WorkModel()
        {
            AvailableApplicants = new List<SelectListItem>();
            AvailableEmploymentStatuses = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Work.Fields.ApplicantId")]
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.EmploymentStatusId")]
        public int EmploymentStatusId { get; set; }
        public string EmploymentStatus { get; set; }
        public IList<SelectListItem> AvailableEmploymentStatuses { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.JobTitle")]
        public string JobTitle { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.EmployerOrBusiness")]
        public string EmployerOrBusiness { get; set; }        

        [NopResourceDisplayName("Admin.Work.Fields.Address")]
        public string Address { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.City")]
        public string City { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.CountryCode")]
        public string CountryCode { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.StartDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartDate { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.EndDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? EndDate { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.AnnunalIncomeAmount")]
        public decimal AnnunalIncomeAmount { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.TaxFiled")]
        public bool TaxFiled { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.TaxDeclaredIncome")]
        public decimal TaxDeclaredIncome { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.TaxCurrency")]
        public string TaxCurrency { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.UpdatedBy")]
        public string UpdatedBy { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.OfferLetterId")]
        [UIHint("Download")]
        public int OfferLetterId { get; set; }

        [NopResourceDisplayName("Admin.Work.Fields.RelievingLetterId")]
        [UIHint("Download")]
        public int RelievingLetterId { get; set; }
    }
}