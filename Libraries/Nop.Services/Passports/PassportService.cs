using Nop.Core;
using Nop.Core.Domain.Passports;
using Nop.Data;

namespace Nop.Services.Passports
{
    /// <summary>
    /// Passport service
    /// </summary>
    public partial class PassportService : IPassportService
    {
        #region Fields

        protected readonly IRepository<Passport> _passportRepository;

        #endregion

        #region Ctor

        public PassportService(IRepository<Passport> passportRepository)
        {
            _passportRepository = passportRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all passports
        /// </summary>
        /// <param name="applicantId">Applicant identifier; null to load all records</param>
        /// <param name="passportNumber">Passport number; null to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passports
        /// </returns>
        public virtual async Task<IPagedList<Passport>> GetAllPassportsAsync(int applicantId = 0, string passportNumber = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return await _passportRepository.GetAllPagedAsync(query => 
            {
                if (applicantId > 0)
                    query = query.Where(p => p.ApplicantId == applicantId);

                if (!string.IsNullOrEmpty(passportNumber))
                    query = query.Where(p => p.PassportNumber.ToLower() == passportNumber.ToLower());

                return query;
            }, pageIndex, pageSize);
        }

        /// <summary>
        /// Gets an passport by passport number
        /// </summary>
        /// <param name="passportNumber">Passport number</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passport number
        /// </returns>
        public virtual async Task<Passport> GetPassportByPassportNumberAsync(string passportNumber)
        {
            if (string.IsNullOrEmpty(passportNumber))
                return null;

            return await _passportRepository.Table.Where(p => p.PassportNumber.ToLower() == passportNumber.ToLower()).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets an passport by passport identifier
        /// </summary>
        /// <param name="passportId">Passport identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passport
        /// </returns>
        public virtual async Task<Passport> GetPassportByIdAsync(int passportId)
        {
            return await _passportRepository.GetByIdAsync(passportId, cache => default);
        }

        /// <summary>
        /// Gets passports by identifier
        /// </summary>
        /// <param name="passportIds">Passport identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passports
        /// </returns>
        public virtual async Task<IList<Passport>> GetPassportsByIdsAsync(int[] passportIds)
        {
            return await _passportRepository.GetByIdsAsync(passportIds);
        }

        /// <summary>
        /// Inserts an passport
        /// </summary>
        /// <param name="passport">Passport</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task InsertPassportAsync(Passport passport)
        {
            await _passportRepository.InsertAsync(passport);
        }

        /// <summary>
        /// Updates the passport
        /// </summary>
        /// <param name="passport">Passport</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task UpdatePassportAsync(Passport passport)
        {
            await _passportRepository.UpdateAsync(passport);
        }

        /// <summary>
        /// Deletes the passport
        /// </summary>
        /// <param name="passport">Passport</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeletePassportAsync(Passport passport)
        {
            await _passportRepository.DeleteAsync(passport);
        }

        /// <summary>
        /// Deletes the passports
        /// </summary>
        /// <param name="passports">Passports</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task DeletePassportsAsync(IList<Passport> passports)
        {
            await _passportRepository.DeleteAsync(passports);
        }

        #endregion
    }
}