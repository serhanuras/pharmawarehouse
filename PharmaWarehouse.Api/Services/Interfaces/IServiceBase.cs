using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PharmaWarehouse.Api.Entities;
using SqlKata;

namespace PharmaWarehouse.Api.Services
{
    public interface IServiceBase<TEntity>
        where TEntity : class, IEntityBase
    {
        List<TEntity> GetPageData(int page = 1, int recordsPerPage = 100);

        TEntity Get(long id);

        TEntity Upsert(TEntity item);

        bool Exists(long id);

        long Count();

        void Delete(long id);
    }
}
