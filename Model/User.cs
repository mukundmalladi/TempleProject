using Microsoft.AspNetCore.Identity;

namespace TempleProject.Model
{
    public class User : IdentityUser
    {
        public string Password { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty ;        
    }
}
