using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Educations;
using Nop.Services;
using Nop.Services.Educations;
using Nop.Services.Localization;
using Nop.Services.Profiles;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Educations;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the education model factory implementation
    /// </summary>
    public partial class EducationModelFactory : IEducationModelFactory
    {
        #region Fields

        protected readonly IProfileService _profileService;
        protected readonly IEducationService _educationService;
        protected readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor

        public EducationModelFactory(IProfileService profileService,
                                     IEducationService educationService,
                                     ILocalizationService localizationService)
        {
            _profileService = profileService;
            _educationService = educationService;
            _localizationService = localizationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare education search model
        /// </summary>
        /// <param name="searchModel">Education search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the education search model
        /// </returns>
        public virtual async Task<EducationSearchModel> PrepareEducationSearchModelAsync(EducationSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            searchModel.AvailableApplicants = (await _profileService.GetAllProfilesAsync()).Select(p => new SelectListItem
            {
                Text = p.ApplicantId,
                Value = p.Id.ToString()
            }).ToList();
            searchModel.AvailableApplicants.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            searchModel.AvailableStandards = (await StandardEnum.Tenth.ToSelectListAsync(false)).Select(x => new SelectListItem 
            {
                Text = x.Text,
                Value = x.Value,
            }).ToList();
            searchModel.AvailableStandards.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged education list model
        /// </summary>
        /// <param name="searchModel">Education search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the education list model
        /// </returns>
        public virtual async Task<EducationListModel> PrepareEducationListModelAsync(EducationSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            //get educations
            var educations = await _educationService.GetAllEducationsAsync(searchModel.SearchApplicantId,
                                                                           searchModel.SearchStandardId,
                                                                           searchModel.Page - 1,
                                                                           searchModel.PageSize);

            //prepare list model
            var model = await new EducationListModel().PrepareToGridAsync(searchModel, educations, () =>
            {
                //fill in model values from the entity
                return educations.SelectAwait(async education =>
                {
                    var educationModel = education.ToModel<EducationModel>();

                    var profile = await _profileService.GetProfileByIdAsync(education.ApplicantId);
                    if (profile != null)
                        educationModel.ApplicantName = profile.ApplicantId;

                    educationModel.Standard = await _localizationService.GetLocalizedEnumAsync(education.StandardEnum);

                    return educationModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare education model
        /// </summary>
        /// <param name="model">Education model</param>
        /// <param name="education">Education</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the education model
        /// </returns>
        public virtual async Task<EducationModel> PrepareEducationModelAsync(EducationModel model, Education education)
        {
            //fill in model values from the entity
            if (education != null)
            {
                model ??= education.ToModel<EducationModel>();

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

            model.AvailableStandards = (await StandardEnum.Tenth.ToSelectListAsync(false)).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value,
            }).ToList();
            model.AvailableStandards.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            return model;
        }

        #endregion
    }
}