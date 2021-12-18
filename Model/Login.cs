using System.ComponentModel.DataAnnotations;

namespace TempleProject.Model
{
    public class Login
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
