using Nop.Core;
using Nop.Core.Domain.Passports;

namespace Nop.Services.Passports
{
    /// <summary>
    /// Education service interface
    /// </summary>
    public partial interface IPassportService
    {
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
        Task<IPagedList<Passport>> GetAllPassportsAsync(int applicantId = 0, string passportNumber = null, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets an passport by passport number
        /// </summary>
        /// <param name="passportNumber">Passport number</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passport number
        /// </returns>
        Task<Passport> GetPassportByPassportNumberAsync(string passportNumber);

        /// <summary>
        /// Gets an passport by passport identifier
        /// </summary>
        /// <param name="passportId">Passport identifier</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passport
        /// </returns>
        Task<Passport> GetPassportByIdAsync(int passportId);

        /// <summary>
        /// Gets passports by identifier
        /// </summary>
        /// <param name="passportIds">Passport identifiers</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the passports
        /// </returns>
        Task<IList<Passport>> GetPassportsByIdsAsync(int[] passportIds);

        /// <summary>
        /// Inserts an passport
        /// </summary>
        /// <param name="passport">Passport</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InsertPassportAsync(Passport passport);

        /// <summary>
        /// Updates the passport
        /// </summary>
        /// <param name="passport">Passport</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UpdatePassportAsync(Passport passport);

        /// <summary>
        /// Deletes the passport
        /// </summary>
        /// <param name="passport">Passport</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeletePassportAsync(Passport passport);

        /// <summary>
        /// Deletes the passports
        /// </summary>
        /// <param name="passports">Passports</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task DeletePassportsAsync(IList<Passport> passports);
    }
}