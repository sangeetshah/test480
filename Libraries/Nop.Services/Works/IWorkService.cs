using Nop.Core;
using Nop.Core.Domain.Works;

namespace Nop.Services.Works
{
    public interface IWorkService
    {
        /// <summary>
        /// Gets all works
        /// </summary>
        /// <param name="applicantId">Applicant identifier; null to load all records</param>
        /// <param name="employmentStatusId">Employment status identifier; null to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the works
        /// </returns>
        Task<IPagedList<Work>> GetAllWorksAsync(int applicantId = 0, int employmentStatusId = 0, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets a work
        /// </summary>
        /// <param name="applicantId">Applicant identifier</param>
        /// <param name="employmentStatusId">Employment status identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work
        /// </returns>
        Task<Work> GetWorkByApplicantIdEmploymentStatusIdAsync(int applicantId, int employmentStatusId);

        /// <summary>
        /// Gets a work by work identifier
        /// </summary>
        /// <param name="workId">Work identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work
        /// </returns>
        Task<Work> GetWorkByIdAsync(int workId);

        /// <summary>
        /// Gets works by identifier
        /// </summary>
        /// <param name="workIds">Work identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the works
        /// </returns>
        Task<IList<Work>> GetWorksByIdsAsync(int[] workIds);

        /// <summary>
        /// Inserts an work
        /// </summary>
        /// <param name="work">Work</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertWorkAsync(Work work);

        /// <summary>
        /// Updates the work
        /// </summary>
        /// <param name="work">Work</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdateWorkAsync(Work work);

        /// <summary>
        /// Deletes the work
        /// </summary>
        /// <param name="work">Work</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWorkAsync(Work work);

        /// <summary>
        /// Deletes the works
        /// </summary>
        /// <param name="works">Works</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeleteWorksAsync(IList<Work> works);
    }
}