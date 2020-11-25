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
        public static void AddServices(this IServiceCollection services, IUnitOfWork unitOfWork, ICacheStore cacheStore)
        {
            services.AddSingleton<IRoleService>(opt =>
            {
                var serviceProvider = services.BuildServiceProvider();

                var logger = serviceProvider.GetService<ILogger<RoleService>>();

                return DynamicProxy<IRoleService>.Create(new RoleService(logger, unitOfWork, cacheStore), cacheStore);
            });

            // User Service
            services.AddSingleton<IUserService>(opt =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var logger = serviceProvider.GetService<ILogger<UserService>>();

                var roleService = serviceProvider.GetService<IRoleService>();

                return DynamicProxy<IUserService>.Create(new UserService(logger, unitOfWork, cacheStore, roleService), cacheStore);
            });
        }
    }
}
