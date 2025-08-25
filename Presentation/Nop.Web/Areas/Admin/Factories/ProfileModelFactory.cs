using Nop.Core;
using Nop.Core.Domain.Profiles;
using Nop.Services.Customers;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Profiles;

namespace Nop.Web.Areas.Admin.Factories;

/// <summary>
/// Represents the profile model factory implementation
/// </summary>
public partial class ProfileModelFactory : IProfileModelFactory
{
    #region Properties

    protected readonly IWorkContext _workContext;
    protected readonly ICustomerService _customerService;

    #endregion

    #region Ctor

    public ProfileModelFactory(IWorkContext workContext,
                               ICustomerService customerService)
    {
        _workContext = workContext;
        _customerService = customerService;
    }

    #endregion

    #region Methods

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
    public virtual async Task<ProfileModel> PrepareProfileModelAsync(ProfileModel model, Profile profile)
    {
        if (profile != null)
        {
            //fill in model values from the entity
            model = profile.ToModel<ProfileModel>();
        }

        model.IsAdmin = await _customerService.IsAdminAsync(await _workContext.GetCurrentCustomerAsync());

        return model;
    }

    #endregion
}