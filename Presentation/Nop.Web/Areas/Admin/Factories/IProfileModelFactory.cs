using Nop.Core.Domain.Profiles;
using Nop.Web.Areas.Admin.Models.Profiles;

namespace Nop.Web.Areas.Admin.Factories;

/// <summary>
/// Represents the profile model factory
/// </summary>
public partial interface IProfileModelFactory
{
    /// <summary>
    /// Prepare profile model
    /// </summary>
    /// <param name="model">Profile model</param>
    /// <param name="profile">Profile</param>
    /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the profile model
    /// </returns>
    Task<ProfileModel> PrepareProfileModelAsync(ProfileModel model, Profile profile);
}