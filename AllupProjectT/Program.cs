using AllupProjectT.DataAccessLayer;
using AllupProjectT.Interfaces;
using AllupProjectT.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    //options.Cookie.Expiration = TimeSpan.FromSeconds(5);
});



builder.Services.AddScoped<ILayoutService, LayoutService>();
//builder.Services.AddTransient<>
//builder.Services.AddSingleton<>
//builder.Services.AddScoped<>

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.UseSession();
app.Run();
