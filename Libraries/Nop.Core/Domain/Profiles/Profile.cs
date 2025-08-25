
namespace Nop.Core.Domain.Profiles;

/// <summary>
/// Represents a profile
/// </summary>
public partial class Profile : BaseEntity
{
    public string ApplicantId { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string GenderCode { get; set; }
    public string PrimaryCitizenship { get; set; }
    public string Citizenship1 { get; set; }
    public string Citizenship2 { get; set; }
    public string Email { get; set; }
    public string Mobile1 { get; set; }
    public string Mobile2 { get; set; }
    public string WhtasppMobile { get; set; }
    public string Address1Line1 { get; set; }
    public string Address1Line2 { get; set; }
    public string Address1City { get; set; }
    public string Address1StateProvince { get; set; }
    public string Address1PostalCode { get; set; }
    public string Address1Country { get; set; }
    public string Address2Line1 { get; set; }
    public string Address2Line2 { get; set; }
    public string Address2City { get; set; }
    public string Address2StateProvince { get; set; }
    public string Address2PostalCode { get; set; }
    public string Address2Country { get; set; }
    public string MaritalStatusCode { get; set; }
    public bool HasSponsor { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string AadharNo { get; set; }
    public string FacebookId1 { get; set; }
    public string FacebookId2 { get; set; }
    public string InstagramId1 { get; set; }
    public string InstagramId2 { get; set; }
    public string LinkedInURL { get; set; }
    public string TwitterId { get; set; }
    public int PhotoId { get; set; }
    public int ResumeId { get; set; }
}