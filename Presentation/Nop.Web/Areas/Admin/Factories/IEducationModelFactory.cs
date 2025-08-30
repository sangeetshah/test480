using Nop.Core.Domain.Educations;
using Nop.Web.Areas.Admin.Models.Educations;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the education model factory
    /// </summary>
    public partial interface IEducationModelFactory
    {
        /// <summary>
        /// Prepare education search model
        /// </summary>
        /// <param name="searchModel">Education search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the education search model
        /// </returns>
        Task<EducationSearchModel> PrepareEducationSearchModelAsync(EducationSearchModel searchModel);

        /// <summary>
        /// Prepare paged education list model
        /// </summary>
        /// <param name="searchModel">Education search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the education list model
        /// </returns>
        Task<EducationListModel> PrepareEducationListModelAsync(EducationSearchModel searchModel);

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
        Task<EducationModel> PrepareEducationModelAsync(EducationModel model, Education education);
    }
}