using Nop.Core;
using Nop.Core.Domain.Healths;

namespace Nop.Services.Healths
{
    public interface IHealthService
    {
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
        Task<IPagedList<Health>> GetAllHealthsAsync(int applicantId = 0, int relevantConditionId = 0, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets a health
        /// </summary>
        /// <param name="applicantId">Applicant identifier</param>
        /// <param name="relevantConditionId">Relevant condition identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health
        /// </returns>
        Task<Health> GetHealthByApplicantIdRelevantConditionIdAsync(int applicantId, int relevantConditionId);

        /// <summary>
        /// Gets an health by health identifier
        /// </summary>
        /// <param name="healthId">Health identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the health
        /// </returns>
        Task<Health> GetHealthByIdAsync(int healthId);

        /// <summary>
        /// Gets healths by identifier
        /// </summary>
        /// <param name="healthIds">Health identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the healths
        /// </returns>
        Task<IList<Health>> GetHealthsByIdsAsync(int[] healthIds);

        /// <summary>
        /// Inserts an health
        /// </summary>
        /// <param name="health">Health</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertHealthAsync(Health health);

        /// <summary>
        /// Updates the health
        /// </summary>
        /// <param name="health">Health</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateHealthAsync(Health health);

        /// <summary>
        /// Deletes the health
        /// </summary>
        /// <param name="health">Health</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteHealthAsync(Health health);

        /// <summary>
        /// Deletes the healths
        /// </summary>
        /// <param name="healths">Healths</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteHealthsAsync(IList<Health> healths);
    }
}