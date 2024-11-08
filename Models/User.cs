using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderTrack.Models
{
    [Table("users")]
    public class User
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
        
        [Column("email")]
        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string Email { get; set; }
    
        [Column("address")]
        [Required]
        [MaxLength(120)]
        public string Address { get; set; }

        [Column("password")]
        [Required]
        [MaxLength(80)]
        [MinLength(4)]
        public string Password { get; set; }

        public User(string name, string email, string address, string password)
        {
            Name = name.ToLower().Trim();
            Email = email.ToLower().Trim();
            Address = address.ToLower().Trim();
            Password = password;
        }
    }
}