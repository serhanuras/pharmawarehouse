using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PharmaWarehouse.Api.Entities;
using PharmaWarehouse.Api.Modules.Cache;
using PharmaWarehouse.Api.Modules.Data;
using PharmaWarehouse.Api.Services.Interfaces;
using SqlKata;

namespace PharmaWarehouse.Api.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly ICacheStore cacheStore;
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoleService roleService;

        public UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork, ICacheStore cacheStore, IRoleService roleService)
            : base(unitOfWork)
        {
            this.logger = logger;
            this.cacheStore = cacheStore;
            this.unitOfWork = unitOfWork;
            this.repository = this.unitOfWork.GetRepository<User>();
            this.roleService = roleService;
        }

        public new List<User> GetPageData(int page = 1, int recordsPerPage = 100)
        {
            List<Role> roles = this.roleService.GetPageData();

            List<User> users = base.GetPageData(page, recordsPerPage);

            users.All(user =>
            {
                user.Role = roles.FirstOrDefault(r => r.Id == user.RoleId);
                return true;
            });

            return users;
        }

        public User Upsert(User user)
        {
            if (user.Id == 0)
            {
                return this.repository.Add(user);
            }
            else
            {
                var userCurrentData = this.Get(user.Id);
                user.Password = userCurrentData.Password;

                return this.repository.Update(user);
            }
        }

        [CacheIt(DurationIn.Days, 1)]
        public DateTime GetCachedDateTime()
        {
            return DateTime.Now;
        }
    }
}
