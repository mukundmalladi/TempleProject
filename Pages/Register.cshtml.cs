using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TempleProject.Model;
using TempleProject.Pages.ViewModels;

namespace TempleProject.Pages
{
    public class RegisterModel : PageModel
    {
        public RegisterModel(UserManager<User> userManger, SignInManager<User> signInManager)
        {
            UserManger = userManger;
            SignInManager = signInManager;
        }

        [BindProperty]
        public Register Model { get; set; }

        public UserManager<User> UserManger { get; }
        public SignInManager<User> SignInManager { get; }

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = Model.UserName,
                    NormalizedUserName = Model.UserName.ToUpper()
                };                

                var result = await UserManger.CreateAsync(user, Model.Password);

                if (result.Succeeded)
                {
                   await SignInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", new { });
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return Page();
        }
    }
}
