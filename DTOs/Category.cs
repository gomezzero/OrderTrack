using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderTrack.DTOs
{
    public class Category
    {
        [Required]
        [MaxLength(20, ErrorMessage="Name must be 10 characters or less")]
        [MinLength(2, ErrorMessage="Name must be at least 2 characters")]
        public required string Name { get; set; }

        [MaxLength(300, ErrorMessage="Name must be 10 characters or less")]
        public string? Description { get; set; }
    }
}