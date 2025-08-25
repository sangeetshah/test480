using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Profiles;

/// <summary>
/// Represents a profile model
/// </summary>
public partial record ProfileModel : BaseNopEntityModel
{
    public bool IsAdmin { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.ApplicantId")]
    public string SearchApplicantId { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.ApplicantId")]
    public string ApplicantId { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.GivenName")]
    public string GivenName { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.FamilyName")]
    public string FamilyName { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.DateOfBirth")]
    [UIHint("DateTimeNullable")]
    public DateTime? DateOfBirth { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.GenderCode")]
    public string GenderCode { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.PrimaryCitizenship")]
    public string PrimaryCitizenship { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Citizenship1")]
    public string Citizenship1 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Citizenship2")]
    public string Citizenship2 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Email")]
    public string Email { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Mobile1")]
    public string Mobile1 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Mobile2")]
    public string Mobile2 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.WhtasppMobile")]
    public string WhtasppMobile { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address1Line1")]
    public string Address1Line1 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address1Line2")]
    public string Address1Line2 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address1City")]
    public string Address1City { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address1StateProvince")]
    public string Address1StateProvince { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address1PostalCode")]
    public string Address1PostalCode { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address1Country")]
    public string Address1Country { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address2Line1")]
    public string Address2Line1 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address2Line2")]
    public string Address2Line2 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address2City")]
    public string Address2City { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address2StateProvince")]
    public string Address2StateProvince { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address2PostalCode")]
    public string Address2PostalCode { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.Address2Country")]
    public string Address2Country { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.MaritalStatusCode")]
    public string MaritalStatusCode { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.HasSponsor")]
    public bool HasSponsor { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.CreatedAt")]
    public DateTime CreatedAt { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.UpdatedAt")]
    public DateTime UpdatedAt { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.CreatedBy")]
    public string CreatedBy { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.UpdatedBy")]
    public string UpdatedBy { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.AadharNo")]
    public string AadharNo { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.FacebookId1")]
    public string FacebookId1 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.FacebookId2")]
    public string FacebookId2 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.InstagramId1")]
    public string InstagramId1 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.InstagramId2")]
    public string InstagramId2 { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.LinkedInURL")]
    public string LinkedInURL { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.TwitterId")]
    public string TwitterId { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.PhotoId")]
    [UIHint("Picture")]
    public int PhotoId { get; set; }

    [NopResourceDisplayName("Admin.Profile.Fields.ResumeId")]
    [UIHint("Download")]
    public int ResumeId { get; set; }
}