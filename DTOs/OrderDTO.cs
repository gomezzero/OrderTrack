using System.ComponentModel.DataAnnotations;
using OrderTrack.Models;

namespace OrderTrack.DTOs
{
    public class OrderDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }

        // Información del cliente
        [Required]
        [MaxLength(20, ErrorMessage = "Customer Name must be 20 characters or less")]
        [MinLength(2, ErrorMessage = "Customer Name must be at least 2 characters")]
        public required string CustomerName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(30, ErrorMessage = "Email must be 30 characters or less")]
        public required string CustomerEmail { get; set; }

        [Required]
        [MaxLength(120, ErrorMessage = "Address must be 120 characters or less")]
        public required string CustomerAddress { get; set; }

        // Lista de productos en el pedido
        [Required(ErrorMessage = "At least one product is required")]
        public required List<OrderProductDTO> Products { get; set; }
    }
}