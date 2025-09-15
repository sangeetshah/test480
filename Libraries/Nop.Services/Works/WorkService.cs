using Nop.Core;
using Nop.Core.Domain.Works;
using Nop.Data;
using Nop.Services.Common;

namespace Nop.Services.Works
{
    /// <summary>
    /// Work service
    /// </summary>
    public partial class WorkService : IWorkService
    {
        #region Fields

        protected readonly IRepository<Work> _workRepository;

        #endregion

        #region Ctor

        public WorkService(IRepository<Work> workRepository)
        {
            _workRepository = workRepository;
        }

        #endregion

        #region Methods

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
        public virtual async Task<IPagedList<Work>> GetAllWorksAsync(int applicantId = 0, int employmentStatusId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _workRepository.GetAllPagedAsync(query =>
            {
                if (applicantId > 0)
                    query = query.Where(p => p.ApplicantId == applicantId);

                if (employmentStatusId > 0)
                    query = query.Where(p => p.EmploymentStatusId == employmentStatusId);

                return query;
            }, pageIndex, pageSize);
        }

        /// <summary>
        /// Gets a work
        /// </summary>
        /// <param name="applicantId">Applicant identifier</param>
        /// <param name="employmentStatusId">Employment status identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work
        /// </returns>
        public virtual async Task<Work> GetWorkByApplicantIdEmploymentStatusIdAsync(int applicantId, int employmentStatusId)
        {
            if (applicantId == 0 || employmentStatusId == 0)
                return null;

            return await _workRepository.Table.Where(x => x.ApplicantId == applicantId && x.EmploymentStatusId == employmentStatusId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets a work by work identifier
        /// </summary>
        /// <param name="workId">Work identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the work
        /// </returns>
        public virtual async Task<Work> GetWorkByIdAsync(int workId)
        {
            return await _workRepository.GetByIdAsync(workId, cache => default);
        }

        /// <summary>
        /// Gets works by identifier
        /// </summary>
        /// <param name="workIds">Work identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the works
        /// </returns>
        public virtual async Task<IList<Work>> GetWorksByIdsAsync(int[] workIds)
        {
            return await _workRepository.GetByIdsAsync(workIds);
        }

        /// <summary>
        /// Inserts an work
        /// </summary>
        /// <param name="work">Work</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertWorkAsync(Work work)
        {
            await _workRepository.InsertAsync(work);
        }

        /// <summary>
        /// Updates the work
        /// </summary>
        /// <param name="work">Work</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateWorkAsync(Work work)
        {
            await _workRepository.UpdateAsync(work);
        }

        /// <summary>
        /// Deletes the work
        /// </summary>
        /// <param name="work">Work</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteWorkAsync(Work work)
        {
            await _workRepository.DeleteAsync(work);
        }

        /// <summary>
        /// Deletes the works
        /// </summary>
        /// <param name="works">Works</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteWorksAsync(IList<Work> works)
        {
            await _workRepository.DeleteAsync(works);
        }

        /// <summary> 
        /// Get work completion percentage
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        public virtual async Task<double> GetWorkCompletionPercentageAsync(int applicantId)
        {
            var work = await _workRepository.Table.Where(x => x.ApplicantId == applicantId).FirstOrDefaultAsync();
            if (work == null)
                return 0;

            return EntityCompletionHelper.GetCompletionPercentage(work);
        }

        #endregion
    }
}
