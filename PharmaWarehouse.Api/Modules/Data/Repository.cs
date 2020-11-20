using System;
using System.Collections.Generic;
using PharmaWarehouse.Api.Entities;
using SqlKata;
using SqlKata.Execution;

namespace PharmaWarehouse.Api.Modules.Data
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntityBase
    {
        private readonly QueryFactory queryFactory;

        private readonly string repositoryName = (typeof(T).Name + "s").ToUpper();

        public Repository(QueryFactory queryFactory)
        {
            this.queryFactory = queryFactory;
        }

        public T Get(long id)
        {
            return this.queryFactory.Query(this.repositoryName).Where(new { Id = id }).First<T>();
        }

        public IEnumerable<T> GetPageData(int page, int recordPerPage)
        {
            return this.queryFactory.Query(this.repositoryName).ForPage(page, recordPerPage).Get<T>();
        }

        public T Add(T entity)
        {
            entity.CreatedOn = DateTime.Now;
            var id = this.queryFactory.Query(this.repositoryName).InsertGetId<long>(entity);
            entity.Id = id;

            return entity;
        }

        public T Update(T entity)
        {
            entity.UpdatedOn = DateTime.Now;
            this.queryFactory.Query(this.repositoryName).Where(new { Id = entity.Id }).Update(entity);
            return entity;
        }

        public void Remove(long id)
        {
            this.queryFactory.Query(this.repositoryName).Where(new { Id = id }).Delete();
        }

        public bool Exists(long id)
        {
            return this.queryFactory.Query(this.repositoryName).Where(new { Id = id }).Count<int>() == 1;
        }

        public void Remove(T entity)
        {
            this.queryFactory.Query(this.repositoryName).Where(new { Id = entity.Id }).Delete();
        }

        public long Count()
        {
            return this.queryFactory.Query(this.repositoryName).Count<long>();
        }

        public Query Query()
        {
            return this.queryFactory.Query(this.repositoryName);
        }
    }
}
