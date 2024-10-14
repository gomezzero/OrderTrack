using System.ComponentModel.DataAnnotations;

namespace OrderTrack.DTOs
{
    public class ProductDTO
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Name must be 10 characters or less")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        public required string Name { get; set; }

        [MaxLength(300, ErrorMessage = "Description must be 10 characters or less")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        public required int Stock { get; set; }

        // foreing key
        [Required(ErrorMessage = "the categoria Id is required")]
        public required int CategoryId { get; set; }

    }
}