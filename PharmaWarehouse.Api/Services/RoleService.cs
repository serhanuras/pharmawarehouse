using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PharmaWarehouse.Api.Entities;
using PharmaWarehouse.Api.Modules.Cache;
using PharmaWarehouse.Api.Modules.Data;
using PharmaWarehouse.Api.Services.Interfaces;

namespace PharmaWarehouse.Api.Services
{
    public class RoleService : ServiceBase<Role>, IRoleService
    {
        private readonly ILogger<RoleService> logger;
        private readonly ICacheStore cacheStore;
        private readonly IRepository<Role> repository;
        private readonly IUnitOfWork unitOfWork;

        public RoleService(ILogger<RoleService> logger, IUnitOfWork unitOfWork, ICacheStore cacheStore)
            : base(unitOfWork)
        {
            this.logger = logger;
            this.cacheStore = cacheStore;
            this.unitOfWork = unitOfWork;
            this.repository = this.unitOfWork.GetRepository<Role>();
        }
    }
}
