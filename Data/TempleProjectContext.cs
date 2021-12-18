using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TempleProject.Model;

namespace TempleProject.Data
{
    public class TempleProjectContext : IdentityDbContext<User>
    {
        public TempleProjectContext(DbContextOptions<TempleProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
    }
}
