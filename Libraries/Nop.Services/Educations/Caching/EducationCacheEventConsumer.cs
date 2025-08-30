using Nop.Core.Domain.Educations;
using Nop.Services.Caching;

namespace Nop.Services.Educations.Caching
{
    /// <summary>
    /// Represents a education cache event consumer
    /// </summary>
    public partial class EducationCacheEventConsumer : CacheEventConsumer<Education>
    {
    }
}