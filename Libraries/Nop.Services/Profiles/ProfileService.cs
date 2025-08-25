using Nop.Core.Domain.Profiles;
using Nop.Data;

namespace Nop.Services.Profiles;

/// <summary>
/// Profile service
/// </summary>
public partial class ProfileService : IProfileService
{
    #region Fields

    protected readonly IRepository<Profile> _profileRepository;

    #endregion

    #region Ctor

    public ProfileService(IRepository<Profile> profileRepository)
    {
        _profileRepository = profileRepository;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets a profile
    /// </summary>
    /// <param name="profileId">Profile identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the profile
    /// </returns>
    public virtual async Task<Profile> GetProfileByIdAsync(int profileId)
    {
        if (profileId == 0)
            return null;

        return await _profileRepository.GetByIdAsync(profileId);
    }

    /// <summary>
    /// Gets a profile
    /// </summary>
    /// <param name="applicantId">The applicant identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the profile
    /// </returns>
    public virtual async Task<Profile> GetProfileByApplicantIdAsync(string applicantId)
    {
        if (string.IsNullOrEmpty(applicantId))
            return null;

        return await _profileRepository.Table.Where(p => p.ApplicantId.ToLower() == applicantId.ToLower()).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Inserts a profile
    /// </summary>
    /// <param name="profile">Profile</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertProfileAsync(Profile profile)
    {
        await _profileRepository.InsertAsync(profile);
    }

    /// <summary>
    /// Updates the profile
    /// </summary>
    /// <param name="profile">Profile</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateProfileAsync(Profile profile)
    {
        await _profileRepository.UpdateAsync(profile);
    }

    #endregion
}