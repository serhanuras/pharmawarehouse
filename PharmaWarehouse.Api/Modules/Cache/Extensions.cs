using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PharmaWarehouse.Api.Modules.Cache
{
    public static class Extensions
    {
        public static IServiceCollection AddInMemoryCache(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMemoryCache();

            var children = configuration.GetSection("Caching").GetSection("Objects").GetChildren();

            services.AddSingleton<ICacheStore>(x =>
            {
                Dictionary<string, TimeSpan> timeoutConfiguration =
                    children.ToDictionary(
                        child =>
                        child.Key, child => TimeSpan.Parse(child.Value));

                return new MemoryCacheStore(x.GetService<IMemoryCache>(), timeoutConfiguration);
            });

            return services;
        }

        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            var children = configuration.GetSection("Caching").GetSection("Objects").GetChildren();
            Dictionary<string, TimeSpan> timeoutConfiguration =
                children.ToDictionary(child => child.Key, child => TimeSpan.Parse(child.Value));

            RedisCacheOptions redisCacheOptions = new RedisCacheOptions
            {
                Configuration = configuration["Caching:DistributedUri"],
                InstanceName = "Connecta",
            };
            RedisCache redisCache = new RedisCache(redisCacheOptions);

            services.AddSingleton<ICacheStore>(x =>
            {
                Dictionary<string, TimeSpan> configuration =
                    children.ToDictionary(child => child.Key, child => TimeSpan.Parse(child.Value));

                return new RedisCacheStore(redisCache, configuration);
            });

            return services;
        }
    }
}
