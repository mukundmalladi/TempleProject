using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TempleProject.Model;
using TempleProject.Pages.ViewModels;
using TempleProject.ThirdParty;

namespace TempleProject.Pages
{
    public class VerifyRegisterModel : PageModel
    {
        private MyMemoryCache memoryCache;
        public UserManager<User> UserManager { get; }

        public VerifyRegisterModel(UserManager<User> userManager, MyMemoryCache memoryCache)
        {

            UserManager = userManager;
            this.memoryCache = memoryCache;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public VerifyRegister Model { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userName = Request.Cookies["UserName"];
                if (!string.IsNullOrEmpty(userName))
                {
                    if (memoryCache.Cache.TryGetValue(Constants.SecretKey, out var secretCode) && !string.IsNullOrEmpty(secretCode.ToString()) && Model.SecretCode == secretCode.ToString())
                    {
                        var user = await UserManager.FindByNameAsync(userName);
                        if (user != null)
                        {
                            user.EmailConfirmed = true;
                            await UserManager.UpdateAsync(user);
                        }
                        return RedirectToPage("Login");
                    }
                    else
                    {
                        var user = await UserManager.FindByNameAsync(userName);
                        if (user != null)
                        {
                            user.EmailConfirmed = true;
                            await UserManager.DeleteAsync(user);
                        }
                    }
                    ModelState.AddModelError(string.Empty, "Secret Code not found! Please register again!");
                    return Page();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "UserName not found. Please register again!");
                }
                
            }
            return Page();


        }
    }
}
