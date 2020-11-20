using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace PharmaWarehouse.Api.Modules.Cache
{
    public class RedisCacheStore : ICacheStore
    {
        private readonly IDistributedCache distributedCache;

        private readonly Dictionary<string, TimeSpan> expirationConfiguration;

        private readonly TimeSpan defaultTimeSpan;

        public RedisCacheStore(
            IDistributedCache distributedCache,
            Dictionary<string, TimeSpan> expirationConfiguration)
        {
            this.distributedCache = distributedCache;
            this.expirationConfiguration = expirationConfiguration;

            this.defaultTimeSpan = this.expirationConfiguration["*"];
        }

        public void Add(string key, object item, long duration)
        {
            var timespan = TimeSpan.FromSeconds(duration);

            var jsonData = JsonConvert.SerializeObject(item);
            this.distributedCache.SetString(key, jsonData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timespan,
            });
        }

        public void Add<TItem>(string key, TItem item)
        {
            var cachedObjectName = item.GetType().Name;

            var timespan = this.defaultTimeSpan;
            if (this.expirationConfiguration.ContainsKey(cachedObjectName))
            {
                timespan = this.expirationConfiguration[cachedObjectName];
            }

            var jsonData = JsonConvert.SerializeObject(item);
            this.distributedCache.SetString(key, jsonData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timespan,
            });
        }

        public object Get(string key)
        {
            var jsonString = this.distributedCache.GetString(key);

            var jsonData = JsonConvert.DeserializeObject(jsonString);

            return jsonData;
        }

        public TItem Get<TItem>(string key)
            where TItem : class
        {
            var jsonString = this.distributedCache.GetString(key);

            var jsonData = JsonConvert.DeserializeObject<TItem>(jsonString);

            return jsonData;
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
            this.distributedCache.Remove(key);
        }
    }
}
