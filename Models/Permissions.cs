using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    public class Permissions
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; } = String.Empty;
        [Column("description")]
        [Required]

        public string Description { get; set; } = String.Empty;
        [Column("category")]
        [Required]
        public string Category { get; set; } = String.Empty;
        public IEnumerable<RolePermissions>? RolePermissions;

    }
}
