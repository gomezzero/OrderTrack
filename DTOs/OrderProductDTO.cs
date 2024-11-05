using System.ComponentModel.DataAnnotations;

namespace OrderTrack.DTOs
{
    public class OrderProductDTO
    {
        [Required(ErrorMessage = "Product Id is required")]
        public required int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public required int Quantity { get; set; }
    }
}