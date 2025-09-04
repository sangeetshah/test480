using Nop.Core;
using Nop.Core.Domain.Healths;
using Nop.Data;

namespace Nop.Services.Healths
{
    /// <summary>
    /// Finance service
    /// </summary>
    public partial class HealthService : IHealthService
    {
        #region Fields

        protected readonly IRepository<Health> _healthRepository;

        #endregion

        #region Ctor

        public HealthService(IRepository<Health> healthRepository)
        {
            _healthRepository = healthRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all healths
        /// </summary>
        /// <param name="applicantId">Applicant identifier; null to load all records</param>
        /// <param name="relevantConditionId">Relevant condition identifier; null to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the healths
        /// </returns>
        public virtual async Task<IPagedList<Health>> GetAllHealthsAsync(int applicantId = 0, int relevantConditionId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _healthRepository.GetAllPagedAsync(query =>
            {
                if (applicantId > 0)
                    query = query.Where(p => p.ApplicantId == applicantId);

                if (relevantConditionId > 0)
                    query = query.Where(p => p.RelevantConditionId == relevantConditionId);

                return query;
            }, pageIndex, pageSize);
        }

        /// <summary>
        /// Gets a health
        /// </summary>
        /// <param name="applicantId">Applicant identifier</param>
        /// <param name="relevantConditionId">Relevant condition identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health
        /// </returns>
        public virtual async Task<Health> GetHealthByApplicantIdRelevantConditionIdAsync(int applicantId, int relevantConditionId)
        {
            if (applicantId == 0 || relevantConditionId == 0)
                return null;

            return await _healthRepository.Table.Where(x => x.ApplicantId == applicantId && x.RelevantConditionId == relevantConditionId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets an health by health identifier
        /// </summary>
        /// <param name="healthId">Health identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health
        /// </returns>
        public virtual async Task<Health> GetHealthByIdAsync(int healthId)
        {
            return await _healthRepository.GetByIdAsync(healthId, cache => default);
        }

        /// <summary>
        /// Gets healths by identifier
        /// </summary>
        /// <param name="healthIds">Health identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the healths
        /// </returns>
        public virtual async Task<IList<Health>> GetHealthsByIdsAsync(int[] healthIds)
        {
            return await _healthRepository.GetByIdsAsync(healthIds);
        }

        /// <summary>
        /// Inserts an health
        /// </summary>
        /// <param name="health">Health</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertHealthAsync(Health health)
        {
            await _healthRepository.InsertAsync(health);
        }

        /// <summary>
        /// Updates the health
        /// </summary>
        /// <param name="health">Health</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateHealthAsync(Health health)
        {
            await _healthRepository.UpdateAsync(health);
        }

        /// <summary>
        /// Deletes the health
        /// </summary>
        /// <param name="health">Health</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteHealthAsync(Health health)
        {
            await _healthRepository.DeleteAsync(health);
        }

        /// <summary>
        /// Deletes the healths
        /// </summary>
        /// <param name="healths">Healths</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteHealthsAsync(IList<Health> healths)
        {
            await _healthRepository.DeleteAsync(healths);
        }

        #endregion
    }
}