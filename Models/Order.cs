using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderTrack.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_date")]
        [Required]
        public DateTime OrderDate { get; set; }

        // Relación con el cliente (User)
        [Column("user_id")]
        [Required]
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }

        // Lista de productos en el pedido
        public List<Product> Products { get; set; }

        // Información de contacto del cliente
        [NotMapped]
        public string? CustomerName => User?.Name;

        [NotMapped]
        public string? CustomerAddress => User?.Address;

        [NotMapped]
        public string? CustomerEmail => User?.Email;

        public Order()
        {
            Products = new List<Product>();
        }
    }
}