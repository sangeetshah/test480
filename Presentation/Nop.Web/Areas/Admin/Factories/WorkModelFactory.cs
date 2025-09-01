using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Works;
using Nop.Services;
using Nop.Services.Localization;
using Nop.Services.Profiles;
using Nop.Services.Works;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Works;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the work model factory implementation
    /// </summary>
    public partial class WorkModelFactory : IWorkModelFactory
    {
        #region Fields

        protected readonly IProfileService _profileService;
        protected readonly IWorkService _workService;
        protected readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor

        public WorkModelFactory(IProfileService profileService,
                                     IWorkService workService,
                                     ILocalizationService localizationService)
        {
            _profileService = profileService;
            _workService = workService;
            _localizationService = localizationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare work search model
        /// </summary>
        /// <param name="searchModel">Work search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work search model
        /// </returns>
        public virtual async Task<WorkSearchModel> PrepareWorkSearchModelAsync(WorkSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            searchModel.AvailableApplicants = (await _profileService.GetAllProfilesAsync()).Select(p => new SelectListItem
            {
                Text = p.ApplicantId,
                Value = p.Id.ToString()
            }).ToList();
            searchModel.AvailableApplicants.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            searchModel.AvailableEmploymentStatuses = (await EmploymentStatusEnum.Employed.ToSelectListAsync(false)).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value,
            }).ToList();
            searchModel.AvailableEmploymentStatuses.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged work list model
        /// </summary>
        /// <param name="searchModel">Work search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work list model
        /// </returns>
        public virtual async Task<WorkListModel> PrepareWorkListModelAsync(WorkSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            //get works
            var works = await _workService.GetAllWorksAsync(searchModel.SearchApplicantId,
                                                            searchModel.SearchEmploymentStatusId,
                                                            searchModel.Page - 1,
                                                            searchModel.PageSize);

            //prepare list model
            var model = await new WorkListModel().PrepareToGridAsync(searchModel, works, () =>
            {
                //fill in model values from the entity
                return works.SelectAwait(async work =>
                {
                    var workModel = work.ToModel<WorkModel>();

                    var profile = await _profileService.GetProfileByIdAsync(work.ApplicantId);
                    if (profile != null)
                        workModel.ApplicantName = profile.ApplicantId;

                    workModel.EmploymentStatus = await _localizationService.GetLocalizedEnumAsync(work.EmploymentStatusEnum);

                    return workModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare work model
        /// </summary>
        /// <param name="model">Work model</param>
        /// <param name="education">Work</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work model
        /// </returns>
        public virtual async Task<WorkModel> PrepareWorkModelAsync(WorkModel model, Work work)
        {
            //fill in model values from the entity
            if (work != null)
            {
                model ??= work.ToModel<WorkModel>();

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

            model.AvailableEmploymentStatuses = (await EmploymentStatusEnum.Employed.ToSelectListAsync(false)).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value,
            }).ToList();
            model.AvailableEmploymentStatuses.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            return model;
        }

        #endregion
    }
}