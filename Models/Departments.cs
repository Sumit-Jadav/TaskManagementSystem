using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{

    [Table("departments")]
    public class Departments
    {
        public Guid DepartmentId { get; set; }

        [Column("department_name")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Department name should be between 2 to 50")]
        public string? DepartmentName { get; set; } = String.Empty;

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
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
