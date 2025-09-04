using Nop.Core.Domain.Healths;
using Nop.Services.Caching;

namespace Nop.Services.Healths.Caching
{
    /// <summary>
    /// Represents a health cache event consumer
    /// </summary>
    public partial class HealthCacheEventConsumer : CacheEventConsumer<Health>
    {
    }
}