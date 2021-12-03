using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TempleProject.Model;

namespace TempleProject.Pages
{
    public class LoginModel : PageModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LoginModel(SignInManager<User> signInManager)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            SignInManager = signInManager;
        }

        [BindProperty]
        public Login Model { get; set; }
        public SignInManager<User> SignInManager { get; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(Model.UserName, Model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToPage("Index");
                }
                ModelState.AddModelError(string.Empty, "UserName or password is wrong.");
            }
            return Page();
        }
    }
   
}
