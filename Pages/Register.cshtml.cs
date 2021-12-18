using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using TempleProject.Model;
using TempleProject.Pages.ViewModels;
using TempleProject.ThirdParty;

namespace TempleProject.Pages
{
    public class RegisterModel : PageModel
    {
        public RegisterModel(UserManager<User> userManger, SignInManager<User> signInManager, MyMemoryCache memoryCache)
        {
            UserManger = userManger;
            SignInManager = signInManager;
            this.memoryCache = memoryCache;
        }

        [BindProperty]
        public Register Model { get; set; }

        private MyMemoryCache memoryCache;
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
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    FirstName = Model.FirstName,
                    LastName = Model.LastName,
                    Email = Model.Email,
                    PhoneNumber = Model.Phone
                };                

                var result = await UserManger.CreateAsync(user, Model.Password);

                if (result.Succeeded)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
                    cacheEntryOptions.Size = 1;
                    memoryCache.Cache.Set(Constants.SecretKey, Constants.SecretValue, cacheEntryOptions);
                    
                    Response.Cookies.Append("UserName", user.UserName, new CookieOptions { Expires = DateTime.Now.AddSeconds(45)});

                    return RedirectToPage("VerifyRegister");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return Page();
        }
    }

    public class Constants
    {
        public const string SecretKey = "SecretCodeForTempleUsers";

        public const string SecretValue = "53484850"; //hexa decimal value of SHHP
    }
}
