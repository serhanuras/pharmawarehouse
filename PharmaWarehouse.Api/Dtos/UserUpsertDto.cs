using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaWarehouse.Api.Dtos
{
    public class UserUpsertDto : IUpsertDto
    {
        public long? Id { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public long RoleId { get; set; }

        [Required]
        public long BirthDate { get; set; }
    }
}
