using Microsoft.AspNetCore.Mvc.Rendering;
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
    protected readonly IBaseAdminModelFactory _baseAdminModelFactory;

    #endregion

    #region Ctor

    public ProfileModelFactory(IWorkContext workContext,
                               ICustomerService customerService,
                               IBaseAdminModelFactory baseAdminModelFactory)
    {
        _workContext = workContext;
        _customerService = customerService;
        _baseAdminModelFactory = baseAdminModelFactory;
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

        var genders = new List<string>() { "Male", "Female" };
        model.AvailableGenders = genders.Select(x => new SelectListItem 
        {
            Text = x,
            Value = x,
        }).ToList();
        model.AvailableGenders.Insert(0, new SelectListItem { Text = "Select", Value = "" });

        await _baseAdminModelFactory.PrepareCountriesAsync(model.AvailableCitizenship1Countries);
        await _baseAdminModelFactory.PrepareCountriesAsync(model.AvailableCitizenship2Countries);
        
        await _baseAdminModelFactory.PrepareCountriesAsync(model.AvailableAddress1Countries);
        await _baseAdminModelFactory.PrepareStatesAndProvincesAsync(model.AvailableAddress1States, model.Address1CountryId == 0 ? null : (int?)model.Address1CountryId);

        await _baseAdminModelFactory.PrepareCountriesAsync(model.AvailableAddress2Countries);
        await _baseAdminModelFactory.PrepareStatesAndProvincesAsync(model.AvailableAddress2States, model.Address2CountryId == 0 ? null : (int?)model.Address2CountryId);

        return model;
    }

    #endregion
}