using Nop.Core.Domain.Profiles;

namespace Nop.Services.Profiles;

/// <summary>
/// Profile service interface
/// </summary>
public partial interface IProfileService
{
    /// <summary>
    /// Gets a profile
    /// </summary>
    /// <param name="profileId">Profile identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the profile
    /// </returns>
    Task<Profile> GetProfileByIdAsync(int profileId);

    /// <summary>
    /// Gets a profile
    /// </summary>
    /// <param name="applicantId">The applicant identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the profile
    /// </returns>
    Task<Profile> GetProfileByApplicantIdAsync(string applicantId);

    /// <summary>
    /// Inserts a profile
    /// </summary>
    /// <param name="profile">Profile</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task InsertProfileAsync(Profile profile);

    /// <summary>
    /// Updates the profile
    /// </summary>
    /// <param name="profile">Profile</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task UpdateProfileAsync(Profile profile);

    /// <summary>
    /// Gets all profiles
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the profiles
    /// </returns>
    Task<IList<Profile>> GetAllProfilesAsync();
}