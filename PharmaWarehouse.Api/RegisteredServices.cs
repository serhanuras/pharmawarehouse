using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PharmaWarehouse.Api.Entities;
using PharmaWarehouse.Api.Modules.AbstractOriented;
using PharmaWarehouse.Api.Modules.Cache;
using PharmaWarehouse.Api.Modules.Data;
using PharmaWarehouse.Api.Services;
using PharmaWarehouse.Api.Services.Interfaces;

namespace PharmaWarehouse.Api
{
    public static class RegisteredServices
    {
        public static void AddServices(this IServiceCollection services, ServiceProvider serviceProvider, IUnitOfWork unitOfWork, ICacheStore cacheStore)
        {
            // User Service
            services.AddSingleton(opt =>
            {
                var logger = serviceProvider.GetService<ILogger<UserService>>();

                return DynamicProxy<IUserService<User>>.Create(new UserService(logger, unitOfWork, cacheStore), cacheStore);
            });
        }
    }
}
