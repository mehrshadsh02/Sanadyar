using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandingApp.Models
{
    [Table("Roles", Schema = "BaseInfo")]
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string DisplayName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
