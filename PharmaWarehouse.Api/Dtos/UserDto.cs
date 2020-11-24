using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaWarehouse.Api.Dtos
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RoleName { get; set; }

        public long RoleId { get; set; }

        public long BirthDate { get; set; }
    }
}
