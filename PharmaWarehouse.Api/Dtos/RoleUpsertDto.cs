using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaWarehouse.Api.Dtos
{
    public class RoleUpsertDto : BaseUpsertDto
    {
        [Required(ErrorMessage = "Role name is required")]
        [StringLength(50, ErrorMessage = "Must be between 2 and 50 characters", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
