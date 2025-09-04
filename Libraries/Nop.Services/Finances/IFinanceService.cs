using Nop.Core;
using Nop.Core.Domain.Finances;

namespace Nop.Services.Finances
{
    public interface IFinanceService
    {
        /// <summary>
        /// Gets all finances
        /// </summary>
        /// <param name="applicantId">Applicant identifier; null to load all records</param>
        /// <param name="recordTypeId">Record type identifier; null to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finances
        /// </returns>
        Task<IPagedList<Finance>> GetAllFinancesAsync(int applicantId = 0, int recordTypeId = 0, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets a finance
        /// </summary>
        /// <param name="applicantId">Applicant identifier</param>
        /// <param name="recordTypeId">Record type identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance
        /// </returns>
        Task<Finance> GetFinanceByApplicantIdRecordTypeIdAsync(int applicantId, int recordTypeId);

        /// <summary>
        /// Gets an finance by finance identifier
        /// </summary>
        /// <param name="financeId">Finance identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance
        /// </returns>
        Task<Finance> GetFinanceByIdAsync(int financeId);

        /// <summary>
        /// Gets finances by identifier
        /// </summary>
        /// <param name="financeIds">Finance identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finances
        /// </returns>
        Task<IList<Finance>> GetFinancesByIdsAsync(int[] financeIds);

        /// <summary>
        /// Inserts an finance
        /// </summary>
        /// <param name="finance">Finance</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertFinanceAsync(Finance finance);

        /// <summary>
        /// Updates the finance
        /// </summary>
        /// <param name="finance">Finance</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateFinanceAsync(Finance finance);

        /// <summary>
        /// Deletes the finance
        /// </summary>
        /// <param name="finance">Finance</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteFinanceAsync(Finance finance);

        /// <summary>
        /// Deletes the finances
        /// </summary>
        /// <param name="finances">Finances</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteFinancesAsync(IList<Finance> finances);
    }
}
