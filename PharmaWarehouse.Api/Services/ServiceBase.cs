using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmaWarehouse.Api.Entities;
using PharmaWarehouse.Api.Modules.Data;
using SqlKata;

namespace PharmaWarehouse.Api.Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>
        where TEntity : class, IEntityBase
    {
        private readonly IRepository<TEntity> repository;

        private readonly IUnitOfWork unitOfWork;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = this.unitOfWork.GetRepository<TEntity>();
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

        public List<TEntity> GetPageData(int page = 1, int recordsPerPage = 100)
        {
            return this.repository.GetPageData(page, recordsPerPage).ToList();
        }

        public TEntity Get(long id)
        {
            return this.repository.Get(id);
        }

        public TEntity Upsert(TEntity item)
        {
            if (item.Id == 0)
            {
                return this.repository.Add(item);
            }
            else
            {
                return this.repository.Update(item);
            }
        }

        public Query Query()
        {
            return this.repository.Query();
        }
    }
}
