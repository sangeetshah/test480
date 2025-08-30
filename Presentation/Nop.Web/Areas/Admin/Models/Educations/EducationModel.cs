using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Educations
{
    /// <summary>
    /// Represents a education model
    /// </summary>
    public partial record EducationModel : BaseNopEntityModel
    {
        public EducationModel()
        {
            AvailableApplicants = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Education.Fields.ApplicantId")]
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.StandardId")]
        public int StandardId { get; set; }
        public string Standard { get; set; }
        public IList<SelectListItem> AvailableStandards { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.CourseName")]
        public string CourseName { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.FieldOfStudy")]
        public string FieldOfStudy { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.Institution")]
        public string Institution { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.University")]
        public string University { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.Address")]
        public string Address { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.City")]
        public string City { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.CountryCode")]
        public string CountryCode { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.GraduationYear")]
        public int GraduationYear { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.GPA")]
        public decimal GPA { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.IsHighest")]
        public bool IsHighest { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.UploadedAt")]
        public DateTime UploadedAt { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.UploadedBy")]
        public string UploadedBy { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.Certificate1Id")]
        [UIHint("Download")]
        public int Certificate1Id { get; set; }

        [NopResourceDisplayName("Admin.Education.Fields.Certificate2Id")]
        [UIHint("Download")]
        public int Certificate2Id { get; set; }
    }
}