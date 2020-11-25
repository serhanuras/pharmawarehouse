using System.ComponentModel.DataAnnotations;

namespace PharmaWarehouse.Api.Entities
{
    public class Role : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
