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
    public class UserService : IUserService<User>
    {
        private readonly ILogger<UserService> logger;
        private readonly ICacheStore cacheStore;
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork, ICacheStore cacheStore)
        {
            this.logger = logger;
            this.cacheStore = cacheStore;
            this.unitOfWork = unitOfWork;
            this.repository = this.unitOfWork.GetRepository<User>();
        }

        public long Count()
        {
            return this.repository.Count();
        }

        public void Delete(long id)
        {
            this.repository.Remove(id);
        }

        public bool Exists(long id)
        {
            return this.repository.Exists(id);
        }

        public User Get(long id)
        {
            return this.repository.Get(id);
        }

        public List<User> GetPageData(int page = 1, int recordsPerPage = 100)
        {
            return this.repository.GetPageData(page, recordsPerPage).ToList();
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
    }
}
