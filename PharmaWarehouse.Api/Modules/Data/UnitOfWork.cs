using System.Collections.Generic;
using PharmaWarehouse.Api.Entities;
using SqlKata.Execution;

namespace PharmaWarehouse.Api.Modules.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<string, object> repositories;
        private readonly QueryFactory queryFactory;

        public UnitOfWork(QueryFactory queryFactory)
        {
            this.repositories = new Dictionary<string, object>();
            this.queryFactory = queryFactory;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntityBase
        {
            var repositoryName = typeof(TEntity).Name;

            var repository = new Repository<TEntity>(this.queryFactory);

            if (!this.repositories.ContainsKey(repositoryName))
            {
                this.repositories.Add(repositoryName, repository);
            }

            return (Repository<TEntity>)this.repositories[repositoryName];
        }
    }
}
