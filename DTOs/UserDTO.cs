using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderTrack.DTOs
{
    public class UserDTO
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Name must be 10 characters or less")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(30, ErrorMessage = "The Email must be 30 characters")]
        public required string Email { get; set; }

        [Required]
        [MaxLength(120, ErrorMessage = "The address must be 120 characters")]
        public required string Address { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "The password must be 80 characters")]
        [MinLength(4,  ErrorMessage = "The password must be last 2 characters")]
        public required string Password { get; set; }
    }
}