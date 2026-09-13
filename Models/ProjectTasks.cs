using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.Models
{
    [Table("project_tasks")]
    public class ProjectTasks
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("project_id")]
        [Required]
        public Guid ProjectId { get; set; }

        [Column("title")]
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Task Title should be between 10 to 100 characters")]
        public string Title { get; set; } = String.Empty;

        [Column("description")]
        [Required]
        public string Description { get; set; } = String.Empty;

        [Column("assign_to")]
        [Required]
        public Guid AssignTo { get; set; }

        [Column("created_by")]
        [Required]
        public Guid CreatedBy { get; set; }

        [Column("updated_by")]
        [Required]
        public Guid UpdatedBy { get; set; }

        [Column("task_status")]
        [Required]
        public int StatusId { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        [Required]
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public User? AssignUser { get; set; }

        [JsonIgnore]
        public Projects? Project {  get; set; }
        [JsonIgnore]
        public TaskDbStatus? Status { get; set; }

    }
}
