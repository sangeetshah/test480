using Nop.Core;
using Nop.Core.Domain.Finances;
using Nop.Data;

namespace Nop.Services.Finances
{
    /// <summary>
    /// Finance service
    /// </summary>
    public partial class FinanceService : IFinanceService
    {
        #region Fields

        protected readonly IRepository<Finance> _financeRepository;

        #endregion

        #region Ctor

        public FinanceService(IRepository<Finance> financeRepository)
        {
            _financeRepository = financeRepository;
        }

        #endregion

        #region Methods

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
        public virtual async Task<IPagedList<Finance>> GetAllFinancesAsync(int applicantId = 0, int recordTypeId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _financeRepository.GetAllPagedAsync(query =>
            {
                if (applicantId > 0)
                    query = query.Where(p => p.ApplicantId == applicantId);

                if (recordTypeId > 0)
                    query = query.Where(p => p.RecordTypeId == recordTypeId);

                return query;
            }, pageIndex, pageSize);
        }

        /// <summary>
        /// Gets a finance
        /// </summary>
        /// <param name="applicantId">Applicant identifier</param>
        /// <param name="recordTypeId">Record type identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance
        /// </returns>
        public virtual async Task<Finance> GetFinanceByApplicantIdRecordTypeIdAsync(int applicantId, int recordTypeId)
        {
            if (applicantId == 0 || recordTypeId == 0)
                return null;

            return await _financeRepository.Table.Where(x => x.ApplicantId == applicantId && x.RecordTypeId == recordTypeId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets an finance by finance identifier
        /// </summary>
        /// <param name="financeId">Finance identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finance
        /// </returns>
        public virtual async Task<Finance> GetFinanceByIdAsync(int financeId)
        {
            return await _financeRepository.GetByIdAsync(financeId, cache => default);
        }

        /// <summary>
        /// Gets finances by identifier
        /// </summary>
        /// <param name="financeIds">Finance identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the finances
        /// </returns>
        public virtual async Task<IList<Finance>> GetFinancesByIdsAsync(int[] financeIds)
        {
            return await _financeRepository.GetByIdsAsync(financeIds);
        }

        /// <summary>
        /// Inserts an finance
        /// </summary>
        /// <param name="finance">Finance</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertFinanceAsync(Finance finance)
        {
            await _financeRepository.InsertAsync(finance);
        }

        /// <summary>
        /// Updates the finance
        /// </summary>
        /// <param name="finance">Finance</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateFinanceAsync(Finance finance)
        {
            await _financeRepository.UpdateAsync(finance);
        }

        /// <summary>
        /// Deletes the finance
        /// </summary>
        /// <param name="finance">Finance</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteFinanceAsync(Finance finance)
        {
            await _financeRepository.DeleteAsync(finance);
        }

        /// <summary>
        /// Deletes the finances
        /// </summary>
        /// <param name="finances">Finances</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteFinancesAsync(IList<Finance> finances)
        {
            await _financeRepository.DeleteAsync(finances);
        }

        #endregion
    }
}