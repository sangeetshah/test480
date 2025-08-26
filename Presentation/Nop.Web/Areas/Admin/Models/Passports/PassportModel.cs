using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Passports
{
    /// <summary>
    /// Represents a passport model
    /// </summary>
    public partial record PassportModel : BaseNopEntityModel
    {
        public PassportModel()
        {
            AvailableApplicants = new List<SelectListItem>();
        }

        [NopResourceDisplayName("Admin.Passport.Fields.ApplicantId")]
        public int ApplicantId { get; set; }        
        public string ApplicantName { get; set; }
        public IList<SelectListItem> AvailableApplicants { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.PassportNumber")]
        public string PassportNumber { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.IssuingCountry")]
        public string IssuingCountry { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.IssueDate")]
        [UIHint("DateTimeNullable")]
        public DateTime IssueDate { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.ExpiryDate")]
        [UIHint("DateTimeNullable")]
        public DateTime ExpiryDate { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.DateOfBirth")]
        [UIHint("DateTimeNullable")]
        public DateTime? DateOfBirth { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.BirthPlace")]
        public string BirthPlace { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.PlaceOfIssue")]
        public string PlaceOfIssue { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.IsPrimary")]
        public bool IsPrimary { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.UploadedAt")]
        public DateTime UploadedAt { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.UploadedBy")]
        public string UploadedBy { get; set; }

        [NopResourceDisplayName("Admin.Passport.Fields.FileId")]
        [UIHint("Download")]
        public int FileId { get; set; }
    }
}