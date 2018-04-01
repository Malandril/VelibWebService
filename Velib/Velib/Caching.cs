using System;
using System.Runtime.Caching;

namespace Velib
{
    public static class Caching
    {
        public static int lol = 0;

        public static T GetObjectFromCache<T>(string cacheItemName, int cacheTimeInMinutes,
            Func<T> objectSettingFunction)
        {
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = (T) cache[cacheItemName];
            if (cachedObject == null)
            {
                Console.WriteLine($"Not using cache for {cacheItemName}, calling {nameof(objectSettingFunction)}");
                CacheItemPolicy policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeInMinutes)
                };
                cachedObject = objectSettingFunction();
                cache.Set(cacheItemName, cachedObject, policy);
            }
            else
            {
                Console.WriteLine($"Using cache for {cacheItemName}");
            }

            return cachedObject;
        }
    }
}