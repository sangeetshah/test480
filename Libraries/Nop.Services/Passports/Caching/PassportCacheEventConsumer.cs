using Nop.Core.Domain.Passports;
using Nop.Services.Caching;

namespace Nop.Services.Passports.Caching
{
    /// <summary>
    /// Represents a passport cache event consumer
    /// </summary>
    public partial class PassportCacheEventConsumer : CacheEventConsumer<Passport>
    {
    }
}