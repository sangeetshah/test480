using Nop.Core.Domain.Finances;
using Nop.Web.Areas.Admin.Models.Finances;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the finance model factory
    /// </summary>
    public partial interface IFinanceModelFactory
    {
        /// <summary>
        /// Prepare finance search model
        /// </summary>
        /// <param name="searchModel">finance search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance search model
        /// </returns>
        Task<FinanceSearchModel> PrepareFinanceSearchModelAsync(FinanceSearchModel searchModel);

        /// <summary>
        /// Prepare paged finance list model
        /// </summary>
        /// <param name="searchModel">Finance search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance list model
        /// </returns>
        Task<FinanceListModel> PrepareFinanceListModelAsync(FinanceSearchModel searchModel);

        /// <summary>
        /// Prepare finance model
        /// </summary>
        /// <param name="model">Finance model</param>
        /// <param name="finance">Finance</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance model
        /// </returns>
        Task<FinanceModel> PrepareFinanceModelAsync(FinanceModel model, Finance finance);
    }
}