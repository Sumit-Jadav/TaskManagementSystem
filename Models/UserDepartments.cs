using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.Models
{
    [Table("department_admins")]
    public class UserDepartments
    {
        [Column("department_id")]
        [Required]
        public Guid DepartmentId { get; set; }

        [Column("user_id")]
        [Required]
        public Guid UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public Departments? Department { get; set; }
    }
}
