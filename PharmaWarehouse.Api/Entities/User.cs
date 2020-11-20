using System;

namespace PharmaWarehouse.Api.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public long RoleId { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
