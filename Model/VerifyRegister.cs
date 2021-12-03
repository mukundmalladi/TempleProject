using System.ComponentModel.DataAnnotations;

namespace TempleProject.Pages.ViewModels
{
    public class VerifyRegister 
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Enter valid sceret code")]
        [DataType(DataType.Text)]
        public string SecretCode { get; set; } = string.Empty;     
    }
}
