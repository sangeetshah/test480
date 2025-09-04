using Nop.Core.Domain.Healths;
using Nop.Web.Areas.Admin.Models.Healths;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the health model factory
    /// </summary>
    public partial interface IHealthModelFactory
    {
        /// <summary>
        /// Prepare health search model
        /// </summary>
        /// <param name="searchModel">Health search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health search model
        /// </returns>
        Task<HealthSearchModel> PrepareHealthSearchModelAsync(HealthSearchModel searchModel);

        /// <summary>
        /// Prepare paged health list model
        /// </summary>
        /// <param name="searchModel">Health search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health list model
        /// </returns>
        Task<HealthListModel> PrepareHealthListModelAsync(HealthSearchModel searchModel);

        /// <summary>
        /// Prepare health model
        /// </summary>
        /// <param name="model">Health model</param>
        /// <param name="health">Health</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health model
        /// </returns>
        Task<HealthModel> PrepareHealthModelAsync(HealthModel model, Health health);
    }
}