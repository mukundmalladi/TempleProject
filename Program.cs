using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TempleProject.Data;
using TempleProject.Model;
using TempleProject.ThirdParty;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages();

    builder.Services.AddDbContext<TempleProjectContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("TempleProjectContext")));

    builder.Services.AddTransient<ISentToSns, SentToSns>();
    builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TempleProjectContext>();
    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/Login";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    }); 
    builder.Host.UseSerilog((ctx, cfg) =>
    {
        cfg.ReadFrom.Configuration(ctx.Configuration);
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<TempleProjectContext>();
        context.Database.Migrate();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapRazorPages();
  
    Log.Information("App started Successfully");

    app.Run();    

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

