using System;

namespace PharmaWarehouse.Api.Entities
{
    public interface IEntityBase
    {
        long Id { get; set; }

        DateTime? CreatedOn { get; set; }

        DateTime? UpdatedOn { get; set; }
    }
}
