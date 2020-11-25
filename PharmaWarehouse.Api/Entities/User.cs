using System;
using System.ComponentModel.DataAnnotations;

namespace PharmaWarehouse.Api.Entities
{
    public class User : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(512)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string SecretKey { get; set; }

        public long RoleId { get; set; }

        [SqlKata.Ignore]
        public Role Role { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
