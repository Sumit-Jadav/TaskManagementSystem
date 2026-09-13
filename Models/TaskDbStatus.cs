using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    [Table("task_status")]
    public class TaskDbStatus
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("status")]
        [Required]
        public string Status { get; set; } = String.Empty;

        [Column("description")]
        [Required]
        [StringLength(200 , MinimumLength = 10 , ErrorMessage = "Descritpion should be between 10 to 200 character long")]
        public string Descritpion { get; set; } = String.Empty;

        [Column("created_at")]
        [Required]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        [Required]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public IEnumerable<ProjectTasks>? ProjectTasks { get; set; }
    }
}
