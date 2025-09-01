using Nop.Core.Domain.Works;
using Nop.Services.Caching;

namespace Nop.Services.Works.Caching
{
    /// <summary>
    /// Represents a work cache event consumer
    /// </summary>
    public partial class WorkCacheEventConsumer : CacheEventConsumer<Work>
    {
    }
}