using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TempleProject.Data;
using TempleProject.ThirdParty;

namespace TempleProject.Model
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly TempleProjectContext _context;
        private readonly ISentToSns sentToSns;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(TempleProjectContext context, ISentToSns sentToSns, ILogger<CreateModel> logger)
        {
            _context = context;
            this.sentToSns = sentToSns;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                var currentuser = Request.HttpContext.User;
                if (currentuser != null && !string.IsNullOrEmpty(currentuser.Identity?.Name) && ModelState.IsValid)
                {
                    Person.UpdatedBy = currentuser.Identity.Name;
                    Person.CreateDate = DateTime.Now;
                    Person.UpdateDate = DateTime.Now;

                    var result = await sentToSns.SendToSnsAsync(Person.PhoneNumber, Person.TypeOfSeva);
                    Person.SmsSubmission = result;
                    _context.Person.Add(Person);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }
            }

            catch (Exception ex)
            {
                string message = ex.Message;
                _logger.LogError(ex, message);
                ModelState.AddModelError("", "Failed To Create Person. Please try again later");
                return Page();
            }            
            ModelState.AddModelError(string.Empty, "Cannot add user without login credentials");
            return Page();
        }
    }
}
