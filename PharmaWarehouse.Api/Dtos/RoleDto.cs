using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaWarehouse.Api.Dtos
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }
    }
}
