using System;
using System.Collections.Generic;

using PharmaWarehouse.Api.Entities;
using SqlKata;

namespace PharmaWarehouse.Api.Modules.Data
{
    public interface IRepository<T>
        where T : class, IEntityBase
    {
        T Get(long id);

        IEnumerable<T> GetPageData(int page, int recordPerPage);

        T Add(T entity);

        T Update(T entity);

        void Remove(long id);

        bool Exists(long id);

        void Remove(T entity);

        long Count();

        Query Query();

        string GetRepositoryTableName();
    }
}
