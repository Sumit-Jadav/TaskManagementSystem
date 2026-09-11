using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.Models
{
    [Table("roles")]
    public class Roles
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("role")]
        [Required]
        public string Role { get; set; } = String.Empty;


        [Column("created_at")]
        [Required]
        public DateTime? CreatedAt = DateTime.UtcNow;

        [Column("updated_at")]
        [Required]
        public DateTime? UpdatedAt = DateTime.UtcNow;

        [JsonIgnore]
        public IEnumerable<User>? Users { get; set; }
    }
}
