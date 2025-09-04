using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Healths;
using Nop.Services;
using Nop.Services.Healths;
using Nop.Services.Localization;
using Nop.Services.Profiles;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Healths;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the health model factory implementation
    /// </summary>
    public partial class HealthModelFactory : IHealthModelFactory
    {
        #region Fields

        protected readonly IProfileService _profileService;
        protected readonly IHealthService _healthService;
        protected readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor

        public HealthModelFactory(IProfileService profileService,
                                  IHealthService healthService,
                                  ILocalizationService localizationService)
        {
            _profileService = profileService;
            _healthService = healthService;
            _localizationService = localizationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare health search model
        /// </summary>
        /// <param name="searchModel">Health search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health search model
        /// </returns>
        public virtual async Task<HealthSearchModel> PrepareHealthSearchModelAsync(HealthSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            searchModel.AvailableApplicants = (await _profileService.GetAllProfilesAsync()).Select(p => new SelectListItem
            {
                Text = p.ApplicantId,
                Value = p.Id.ToString()
            }).ToList();
            searchModel.AvailableApplicants.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            searchModel.AvailableRelevantConditions = (await RelevantConditionEnum.TB.ToSelectListAsync(false)).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value,
            }).ToList();
            searchModel.AvailableRelevantConditions.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged health list model
        /// </summary>
        /// <param name="searchModel">Health search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health list model
        /// </returns>
        public virtual async Task<HealthListModel> PrepareHealthListModelAsync(HealthSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            //get healths
            var healths = await _healthService.GetAllHealthsAsync(searchModel.SearchApplicantId,
                                                                  searchModel.SearchRelevantConditionId,
                                                                  searchModel.Page - 1,
                                                                  searchModel.PageSize);

            //prepare list model
            var model = await new HealthListModel().PrepareToGridAsync(searchModel, healths, () =>
            {
                //fill in model values from the entity
                return healths.SelectAwait(async health =>
                {
                    var healthModel = health.ToModel<HealthModel>();

                    var profile = await _profileService.GetProfileByIdAsync(health.ApplicantId);
                    if (profile != null)
                        healthModel.ApplicantName = profile.ApplicantId;

                    healthModel.RelevantCondition = await _localizationService.GetLocalizedEnumAsync(health.RelevantConditionEnum);

                    return healthModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare health model
        /// </summary>
        /// <param name="model">Health model</param>
        /// <param name="health">Health</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health model
        /// </returns>
        public virtual async Task<HealthModel> PrepareHealthModelAsync(HealthModel model, Health health)
        {
            //fill in model values from the entity
            if (health != null)
            {
                model ??= health.ToModel<HealthModel>();

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

            model.AvailableRelevantConditions = (await RelevantConditionEnum.TB.ToSelectListAsync(false)).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value,
            }).ToList();
            model.AvailableRelevantConditions.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            return model;
        }

        #endregion
    }
}