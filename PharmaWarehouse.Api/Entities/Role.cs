using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SqlKata;

namespace PharmaWarehouse.Api.Entities
{
    public class Role : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [SqlKata.Ignore]
        public List<User> Users { get; set; }
    }
}
