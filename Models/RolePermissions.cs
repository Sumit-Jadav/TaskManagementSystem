using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    [Table("role_permissions")]
    public class RolePermissions
    {
        [Column("role_id")]
        [Required]
        public int RoleId { get; set; }
        [Column("permission_id")]
        [Required]
        public int PermissionId { get; set; }
        public Roles? Role { get; set; }
        public Permissions? Permission { get; set; }


    }
}
