using Nop.Core.Domain.Works;
using Nop.Web.Areas.Admin.Models.Works;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the work model factory
    /// </summary>
    public partial interface IWorkModelFactory
    {
        /// <summary>
        /// Prepare work search model
        /// </summary>
        /// <param name="searchModel">Work search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work search model
        /// </returns>
        Task<WorkSearchModel> PrepareWorkSearchModelAsync(WorkSearchModel searchModel);

        /// <summary>
        /// Prepare paged work list model
        /// </summary>
        /// <param name="searchModel">Work search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work list model
        /// </returns>
        Task<WorkListModel> PrepareWorkListModelAsync(WorkSearchModel searchModel);

        /// <summary>
        /// Prepare work model
        /// </summary>
        /// <param name="model">Work model</param>
        /// <param name="work">Work</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work model
        /// </returns>
        Task<WorkModel> PrepareWorkModelAsync(WorkModel model, Work work);
    }
}