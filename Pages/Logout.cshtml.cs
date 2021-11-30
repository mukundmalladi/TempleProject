using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TempleProject.Model;

namespace TempleProject.Pages
{
    public class LogoutModel : PageModel
    {
        public SignInManager<User> SignInManager { get; }

        public LogoutModel(SignInManager<User> signInManager)
        {
            SignInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
           await SignInManager.SignOutAsync();

            return RedirectToPage("Login");
        }

        public  IActionResult OnPostDoNotLogout()
        {
            return RedirectToPage("Index");
        }

    }
}
