using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderTrack.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }

        [Column("descriptions")]
        [MaxLength(300)]
        public string? Description { get; set; }

        [Column("stock")]
        [Required]
        public int Stock { get; set; }

        // foreing key
        [Column("category_id")]
        [Required]
        public int CategoryId { get; set; }

        // foreing key conection
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public Product(string name, string? description, int stock, int categoryId)
        {
            Name = name.ToLower().Trim();
            Description = description.ToLower().Trim();
            Stock = stock;
            CategoryId = categoryId;
        }
    }
}