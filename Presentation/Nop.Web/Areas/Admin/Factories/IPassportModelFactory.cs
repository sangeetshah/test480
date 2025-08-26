using Nop.Core.Domain.Passports;
using Nop.Web.Areas.Admin.Models.Passports;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the passport model factory
    /// </summary>
    public partial interface IPassportModelFactory
    {
        /// <summary>
        /// Prepare passport search model
        /// </summary>
        /// <param name="searchModel">Passport search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passport search model
        /// </returns>
        Task<PassportSearchModel> PreparePassportSearchModelAsync(PassportSearchModel searchModel);

        /// <summary>
        /// Prepare paged passport list model
        /// </summary>
        /// <param name="searchModel">Passport search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passport list model
        /// </returns>
        Task<PassportListModel> PreparePassportListModelAsync(PassportSearchModel searchModel);

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
        Task<PassportModel> PreparePassportModelAsync(PassportModel model, Passport passport);
    }
}