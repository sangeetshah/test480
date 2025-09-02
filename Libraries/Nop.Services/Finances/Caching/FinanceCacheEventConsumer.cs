using Nop.Core.Domain.Finances;
using Nop.Services.Caching;

namespace Nop.Services.Finances.Caching
{
    /// <summary>
    /// Represents a finance cache event consumer
    /// </summary>
    public partial class FinanceCacheEventConsumer : CacheEventConsumer<Finance>
    {
    }
}