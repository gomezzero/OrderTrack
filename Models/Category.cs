using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderTrack.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("names")]
        public string Name { get; set; }

        [Column("descriptions")]
        public string Description { get; set; }

        public Category(string name, string description)
        {
            Name = name.ToLower().Trim();
            Description = description.ToLower().Trim();
        }

    }
}