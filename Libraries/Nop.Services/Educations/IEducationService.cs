using Nop.Core;
using Nop.Core.Domain.Educations;

namespace Nop.Services.Educations
{
    public interface IEducationService
    {
        /// <summary>
        /// Gets all educations
        /// </summary>
        /// <param name="applicantId">Applicant identifier; null to load all records</param>
        /// <param name="standardId">Standard identifier; null to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the educations
        /// </returns>
        Task<IPagedList<Education>> GetAllEducationsAsync(int applicantId = 0, int standardId = 0, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets an education by education identifier
        /// </summary>
        /// <param name="educationId">Education identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the education
        /// </returns>
        Task<Education> GetEducationByIdAsync(int educationId);

        /// <summary>
        /// Gets educations by identifier
        /// </summary>
        /// <param name="educationIds">Education identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the educations
        /// </returns>
        Task<IList<Education>> GetEducationsByIdsAsync(int[] educationIds);

        /// <summary>
        /// Inserts an education
        /// </summary>
        /// <param name="education">Education</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertEducationAsync(Education education);

        /// <summary>
        /// Updates the education
        /// </summary>
        /// <param name="education">Education</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateEducationAsync(Education education);

        /// <summary>
        /// Deletes the education
        /// </summary>
        /// <param name="education">Education</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteEducationAsync(Education education);

        /// <summary>
        /// Deletes the educations
        /// </summary>
        /// <param name="educations">Educations</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteEducationsAsync(IList<Education> educations);
    }
}