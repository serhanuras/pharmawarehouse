using PharmaWarehouse.Api.Entities;

namespace PharmaWarehouse.Api.Modules.Data
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntityBase;
    }
}
