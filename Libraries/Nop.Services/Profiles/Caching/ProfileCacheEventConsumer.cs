using Nop.Core.Domain.Profiles;
using Nop.Services.Caching;

namespace Nop.Services.Profiles.Caching
{
    /// <summary>
    /// Represents a profile cache event consumer
    /// </summary>
    public partial class ProfileCacheEventConsumer : CacheEventConsumer<Profile>
    {
    }
}