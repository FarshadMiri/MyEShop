using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyEShop.Data;
using MyEShop.Data.Repositories;
using MyEShop.Data.Repository;
using MyEShop.Data.Services;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
#region dbcontext
builder.Services.AddDbContext<MyEshopContext>(optionsAction: options =>
{
    options.UseSqlServer(connectionString: "Data Source=. ;Initial Catalog=Eshop_DB;Integrated Security=True;TrustServerCertificate=True");
});
 #endregion


#region IOC

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option=>
    {
        option.LoginPath = "/Account/Login";
        option.LogoutPath= "/Account/Logout";
        option.ExpireTimeSpan=TimeSpan.FromDays(10);
        
    })
    ;

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/Admin"))
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/Account/Login");

        }
        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
        {

            context.Response.Redirect("/Account/Login");

        }

    }    await next.Invoke();
});
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
