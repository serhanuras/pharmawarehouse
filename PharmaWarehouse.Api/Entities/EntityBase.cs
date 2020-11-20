using System;

namespace PharmaWarehouse.Api.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public long Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
