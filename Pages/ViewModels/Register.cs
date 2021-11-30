using System.ComponentModel.DataAnnotations;

namespace TempleProject.Pages.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not Matched")]
        public string ConfirmPassword { get; set; } = string.Empty;
       
    }
}
