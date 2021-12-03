using Microsoft.Extensions.Caching.Memory;

namespace TempleProject.ThirdParty
{
    public class MyMemoryCache
    {
        public MemoryCache Cache { get; } = new MemoryCache(
            new MemoryCacheOptions
            {
                SizeLimit = 1024
            });
    }
}
