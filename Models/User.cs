using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public Guid UserId { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; } = String.Empty;

        [Column("password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string HashPassword { get; set; } = String.Empty;

        [Column("role_id")]
        [Required(ErrorMessage = "Role is Required")]
        public int RoleId { get; set; }

        [Column("is_active")]
        [Required]
        public bool IsActive { get; set; } = true;
        
        [Column("created_at")]
        [Required]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        [Required]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("deactivated_at")]
        public DateTime? DeactivatedAt { get; set; } = null;

        [JsonIgnore]
        public Roles? Role { get; set; }
        [JsonIgnore]
        public UserProfile? UserProfile { get; set; }
    }
}
