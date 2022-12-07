using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aeon.Core
{

    public abstract class Cache
    {
        protected readonly SemaphoreManager<CacheEnum> _semaphoreManager = new();
        protected readonly MemoryCacheOptions _cacheOptions = new(); 
        protected readonly MemoryCache _internalCache;
        protected readonly TimeSpan _defaultCacheExpirationTime = TimeSpan.FromSeconds(60);

        public Cache()
        {

            _cacheOptions.ExpirationScanFrequency = _defaultCacheExpirationTime;

            _internalCache = new(_cacheOptions);
        }

        public async Task<T> GetFromCache<T>(CacheEnum key, TimeSpan? cacheExpirationTime = null)
        {
            var semaphore = _semaphoreManager[key];
            try
            {
                T? item = (T?) _internalCache.Get(key);
                if (item != null) { return item; }
                await semaphore.WaitAsync();
                item = (T?) _internalCache.Get(key);
                if (item != null) { return item; }
                item = await FetchItem<T>(key);
                _internalCache.Set(key, item, cacheExpirationTime ?? _defaultCacheExpirationTime);
                return item;

            }
            finally
            {
                semaphore.Release();
            }
        }

        protected abstract Task<T> FetchItem<T>(CacheEnum key);
    }
}
