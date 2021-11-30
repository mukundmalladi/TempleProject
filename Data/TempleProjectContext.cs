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

     //  public DbSet<IdentityUserClaim<string>> IdentityUserClaim { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(p => new { p.Id });

        //}

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<IdentityUser>()
        //        .ToTable("AspNetUsers").;         
        //        builder.Entity<User>()
        //        .ToTable("AspNetRoles");
        //}       


    }
}
