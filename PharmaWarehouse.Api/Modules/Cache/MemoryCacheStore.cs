using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace PharmaWarehouse.Api.Modules.Cache
{
    public class MemoryCacheStore : ICacheStore
    {
        private static IMemoryCache inMemoryCache;

        private readonly IMemoryCache memoryCache;
        private readonly Dictionary<string, TimeSpan> expirationConfiguration;

        private readonly TimeSpan defaultTimeSpan;

        public MemoryCacheStore(
            IMemoryCache memoryCache,
            Dictionary<string, TimeSpan> expirationConfiguration)
        {
            this.memoryCache = memoryCache;
            this.expirationConfiguration = expirationConfiguration;

            this.defaultTimeSpan = this.expirationConfiguration["*"];

            if (inMemoryCache == null)
            {
                inMemoryCache = this.memoryCache;
            }
            else
            {
                this.memoryCache = inMemoryCache;
            }
        }

        public void Add(string key, object item, long duration)
        {
            var timespan = TimeSpan.FromSeconds(duration);

            this.memoryCache.Set(key, item, timespan);
        }

        public void Add<TItem>(string key, TItem item)
        {
            var cachedObjectName = item.GetType().Name;

            var timespan = this.defaultTimeSpan;
            if (this.expirationConfiguration.ContainsKey(cachedObjectName))
            {
                timespan = this.expirationConfiguration[cachedObjectName];
            }

            this.memoryCache.Set(key, item, timespan);
        }

        public object Get(string key)
        {
            if (this.memoryCache.TryGetValue(key, out object value))
            {
                return value;
            }

            return null;
        }

        public TItem Get<TItem>(string key)
            where TItem : class
        {
            if (this.memoryCache.TryGetValue(key, out TItem value))
            {
                return value;
            }

            return null;
        }

        public bool Contains<TItem>(string key)
            where TItem : class
        {
            if (this.Get<TItem>(key) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Remove(string key)
        {
            this.memoryCache.Remove(key);
        }
    }
}
