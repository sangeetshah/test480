using Nop.Core;
using Nop.Core.Domain.Educations;
using Nop.Data;

namespace Nop.Services.Educations
{
    /// <summary>
    /// Education service
    /// </summary>
    public partial class EducationService : IEducationService
    {
        #region Fields

        protected readonly IRepository<Education> _educationRepository;

        #endregion

        #region Ctor

        public EducationService(IRepository<Education> educationRepository)
        {
            _educationRepository = educationRepository;
        }

        #endregion

        #region Methods

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
        public virtual async Task<IPagedList<Education>> GetAllEducationsAsync(int applicantId = 0, int standardId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _educationRepository.GetAllPagedAsync(query =>
            {
                if (applicantId > 0)
                    query = query.Where(p => p.ApplicantId == applicantId);

                if (standardId > 0)
                    query = query.Where(p => p.StandardId == standardId);

                return query;
            }, pageIndex, pageSize);
        }

        /// <summary>
        /// Gets an education by education identifier
        /// </summary>
        /// <param name="educationId">Education identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the education
        /// </returns>
        public virtual async Task<Education> GetEducationByIdAsync(int educationId)
        {
            return await _educationRepository.GetByIdAsync(educationId, cache => default);
        }

        /// <summary>
        /// Gets educations by identifier
        /// </summary>
        /// <param name="educationIds">Education identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the educations
        /// </returns>
        public virtual async Task<IList<Education>> GetEducationsByIdsAsync(int[] educationIds)
        {
            return await _educationRepository.GetByIdsAsync(educationIds);
        }

        /// <summary>
        /// Inserts an education
        /// </summary>
        /// <param name="education">Education</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertEducationAsync(Education education)
        {
            await _educationRepository.InsertAsync(education);
        }

        /// <summary>
        /// Updates the education
        /// </summary>
        /// <param name="education">Education</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdateEducationAsync(Education education)
        {
            await _educationRepository.UpdateAsync(education);
        }

        /// <summary>
        /// Deletes the education
        /// </summary>
        /// <param name="education">Education</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteEducationAsync(Education education)
        {
            await _educationRepository.DeleteAsync(education);
        }

        /// <summary>
        /// Deletes the educations
        /// </summary>
        /// <param name="educations">Educations</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeleteEducationsAsync(IList<Education> educations)
        {
            await _educationRepository.DeleteAsync(educations);
        }
    }

    #endregion
}