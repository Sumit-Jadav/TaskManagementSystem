using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    public class UserProfile
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        [Required]
        public Guid UserId { get; set; }

        [Column("first_name")]
        [Required]
        [StringLength(50 , MinimumLength = 2 , ErrorMessage = "FirstName should be between 2 to 50 character")]
        public string FirstName { get; set; } = String.Empty;

        [Column("last_name")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "LastName should be between 2 to 50 character")]
        public string LastName { get; set; } = String.Empty;


        [Column("created_by")]
        [Required]
        public Guid CreatedBy { get; set; }

        [Column("updated_by")]
        public Guid UpdatedeBy { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        [Required]
        public DateTime? UpdatedAt { get; set; }

        public User? User { get; set; }
    }
}
