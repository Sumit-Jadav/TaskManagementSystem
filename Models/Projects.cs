using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.Models
{
    [Table("projects")]
    public class Projects
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("project_name")]
        [Required]
        public string Name { get; set; } = String.Empty;

        [Column("description")]
        [Required]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "Project Description should be between 20 to 200 character long")]
        public string Description { get; set; } = String.Empty;


        [Column("department_id")]
        [Required]
        public Guid DepartmentId { get; set; }

        [Column("start_date")]
        [Required]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [Column("expected_end_date")]
        [Required]
        public DateTime ExpectedEndDate { get; set; }

        [Column("end_date")]
        [Required]
        public DateTime? EndDate { get; set; }

        [Column("is_deleted")]
        [Required]
        public bool IsDeleted { get; set; } = false;

        [Column("created_by")]
        [Required]
        public Guid CreatedBy { get; set; } 
        [Column("updated_by")]
        [Required]
        public Guid UpdatedBy { get; set; } 


        [Column("created_at")]
        [Required]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        [Required]
        public DateTime? UpdatedAt { get; set;} = DateTime.UtcNow;

        [Column("deleted_at")]
        [Required]
        public DateTime? DeletedAt { get; set; } = null;

        [JsonIgnore]
        public Departments? Departmnt { get; set; }

        [JsonIgnore]
        public IEnumerable<ProjectTasks>? Tasks { get; set; }

    }
}
