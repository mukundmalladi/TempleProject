using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TempleProject.Model
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Data.TempleProjectContext _context;

        public IndexModel(Data.TempleProjectContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.Person.ToListAsync();
        }
    }
}
