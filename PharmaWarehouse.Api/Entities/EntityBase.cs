using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaWarehouse.Api.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        public long Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
