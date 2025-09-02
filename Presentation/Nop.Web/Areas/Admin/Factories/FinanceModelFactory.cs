using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Finances;
using Nop.Services;
using Nop.Services.Finances;
using Nop.Services.Localization;
using Nop.Services.Profiles;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Finances;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the finance model factory implementation
    /// </summary>
    public partial class FinanceModelFactory : IFinanceModelFactory
    {
        #region Fields

        protected readonly IProfileService _profileService;
        protected readonly IFinanceService _financeService;
        protected readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor

        public FinanceModelFactory(IProfileService profileService,
                                   IFinanceService financeService,
                                   ILocalizationService localizationService)
        {
            _profileService = profileService;
            _financeService = financeService;
            _localizationService = localizationService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare finance search model
        /// </summary>
        /// <param name="searchModel">finance search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance search model
        /// </returns>
        public virtual async Task<FinanceSearchModel> PrepareFinanceSearchModelAsync(FinanceSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            searchModel.AvailableApplicants = (await _profileService.GetAllProfilesAsync()).Select(p => new SelectListItem
            {
                Text = p.ApplicantId,
                Value = p.Id.ToString()
            }).ToList();
            searchModel.AvailableApplicants.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            searchModel.AvailableRecordTypes = (await RecordTypeEnum.BankAccount.ToSelectListAsync(false)).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value,
            }).ToList();
            searchModel.AvailableRecordTypes.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare paged finance list model
        /// </summary>
        /// <param name="searchModel">Finance search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance list model
        /// </returns>
        public virtual async Task<FinanceListModel> PrepareFinanceListModelAsync(FinanceSearchModel searchModel)
        {
            ArgumentNullException.ThrowIfNull(searchModel);

            //get finances
            var finances = await _financeService.GetAllFinancesAsync(searchModel.SearchApplicantId,
                                                                     searchModel.SearchRecordTypeId,
                                                                     searchModel.Page - 1,
                                                                     searchModel.PageSize);

            //prepare list model
            var model = await new FinanceListModel().PrepareToGridAsync(searchModel, finances, () =>
            {
                //fill in model values from the entity
                return finances.SelectAwait(async finance =>
                {
                    var financeModel = finance.ToModel<FinanceModel>();

                    var profile = await _profileService.GetProfileByIdAsync(finance.ApplicantId);
                    if (profile != null)
                        financeModel.ApplicantName = profile.ApplicantId;

                    financeModel.RecordType = await _localizationService.GetLocalizedEnumAsync(finance.RecordTypeEnum);
                    financeModel.AssetType = await _localizationService.GetLocalizedEnumAsync(finance.AssetTypeEnum);

                    return financeModel;
                });
            });

            return model;
        }

        /// <summary>
        /// Prepare finance model
        /// </summary>
        /// <param name="model">Finance model</param>
        /// <param name="finance">Finance</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance model
        /// </returns>
        public virtual async Task<FinanceModel> PrepareFinanceModelAsync(FinanceModel model, Finance finance)
        {
            //fill in model values from the entity
            if (finance != null)
            {
                model ??= finance.ToModel<FinanceModel>();

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

            model.AvailableRecordTypes = (await RecordTypeEnum.BankAccount.ToSelectListAsync(false)).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value,
            }).ToList();
            model.AvailableRecordTypes.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            model.AvailableAssetTypes = (await AssetTypeEnum.Savings.ToSelectListAsync(false)).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value,
            }).ToList();
            model.AvailableAssetTypes.Insert(0, new SelectListItem { Text = "Select", Value = 0.ToString() });

            return model;
        }

        #endregion
    }
}