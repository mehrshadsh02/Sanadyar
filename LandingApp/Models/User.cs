using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandingApp.Models
{
    [Table("Users", Schema = "BaseInfo")]
    public class User
    {
      
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
