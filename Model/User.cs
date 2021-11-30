using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TempleProject.Model
{
    public class User : IdentityUser
    {
        public string Password { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
