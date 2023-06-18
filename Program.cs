using Microsoft.AspNetCore.Hosting;
 using ProfileManagement.Models;
using Microsoft.EntityFrameworkCore;
using ProfileManagement.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //builder.Services.AddSingleton 
        builder.Services.AddScoped<IProfileDetails, SqliteRepository>();
        builder.Services.AddDbContextPool<ProfileDetailsContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("ProfileManagementDB")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}