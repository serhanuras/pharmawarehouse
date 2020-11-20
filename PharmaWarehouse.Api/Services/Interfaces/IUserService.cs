using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmaWarehouse.Api.Entities;

namespace PharmaWarehouse.Api.Services.Interfaces
{
    public interface IUserService<TEntity> : IServiceBase<TEntity>
        where TEntity : class, IEntityBase
    {
    }
}
