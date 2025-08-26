using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Passports;
using Nop.Services.Passports;
using Nop.Services.Profiles;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Passports;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the passport model factory implementation
    /// </summary>
    public partial class PassportModelFactory : IPassportModelFactory
    {
        #region Fields

        protected readonly IProfileService _profileService;
        protected readonly IPassportService _passportService;

        #endregion

        #region Ctor

        public PassportModelFactory(IProfileService profileService,
                                    IPassportService passportService)
        {
            _profileService = profileService;
            _passportService = passportService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare passport search model
        /// </summary>
        /// <param name="searchModel">Passport search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passport search model
        /// </returns>
        public virtual async Task<PassportSearchModel> PreparePassportSearchModelAsync(PassportSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            searchModel.AvailableApplicants = (await _profileService.GetAllProfilesAsync()).Select(p => new SelectListItem 
            {
                Text = p.ApplicantId,
                Value = p.Id.ToString()
            }).ToList();
            searchModel.AvailableApplicants.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged passport list model
        /// </summary>
        /// <param name="searchModel">Passport search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passport list model
        /// </returns>
        public virtual async Task<PassportListModel> PreparePassportListModelAsync(PassportSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            //get passports
            var passports = await _passportService.GetAllPassportsAsync(searchModel.SearchApplicantId,
                                                                        searchModel.SearchPassportNumber,
                                                                        searchModel.Page - 1,
                                                                        searchModel.PageSize);

            //prepare list model
            var model = await new PassportListModel().PrepareToGridAsync(searchModel, passports, () =>
            {
                //fill in model values from the entity
                return passports.SelectAwait(async passport =>
                {
                    var passportModel = passport.ToModel<PassportModel>();

                    var profile = await _profileService.GetProfileByIdAsync(passport.ApplicantId);
                    if (profile != null)
                        passportModel.ApplicantName = profile.ApplicantId;

                    return passportModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare passport model
        /// </summary>
        /// <param name="model">Passport model</param>
        /// <param name="passport">Passport</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passport model
        /// </returns>
        public virtual async Task<PassportModel> PreparePassportModelAsync(PassportModel model, Passport passport)
        {
            //fill in model values from the entity
            if (passport != null)
            {
                model ??= passport.ToModel<PassportModel>();

                var profile = await _profileService.GetProfileByIdAsync(model.ApplicantId);
                if (profile != null)
                    model.ApplicantName = profile.ApplicantId;
            }

            model.AvailableApplicants = (await _profileService.GetAllProfilesAsync()).Select(p => new SelectListItem
            {
                Text = p.ApplicantId,
                Value = p.Id.ToString()
            }).ToList();
            model.AvailableApplicants.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            return model;
        }

        #endregion
    }
}