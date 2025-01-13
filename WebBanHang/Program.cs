using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using WebBanHang.Model;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.ConfigureServices(builder.Configuration);

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Use routing, authentication, and session middleware
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

// Set up the endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "Home",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

// Run the application
app.Run();

// Extension method to configure services
public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Connect to the database
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<WebBanHangContext>(options => options.UseSqlServer(connectionString));

        // Set up HTML encoder to allow all unicode ranges
        services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

        // Add services to the container
        services.AddControllersWithViews();
        services.AddControllersWithViews().AddRazorRuntimeCompilation();

        // Add toast notification configuration
        services.AddNotyf(config =>
        {
            config.DurationInSeconds = 10;
            config.IsDismissable = true;
            config.Position = NotyfPosition.BottomRight;
        });

        // Add session support
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout duration
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true; // Required for GDPR compliance
        });

        // Add authentication and cookie configuration
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = new PathString("/Home/Index");
            });
    }
}
