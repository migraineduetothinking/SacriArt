
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SacriArt.Domain;

namespace SacriArt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();

            builder.Configuration.Bind("ConnectionStrings", new Config());

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Config.ConnectionString));

            //builder.Services.AddScoped<IPaintingService, PaintingService>();


            //builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            //{
            //    opts.User.RequireUniqueEmail = true;
            //    opts.Password.RequiredLength = 6;
            //    opts.Password.RequireNonAlphanumeric = false;
            //    opts.Password.RequireLowercase = false;
            //    opts.Password.RequireUppercase = false;
            //    opts.Password.RequireDigit = false;
            //}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            //builder.Services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "sacriartAuth";
            //    options.Cookie.HttpOnly = true;
            //    options.LoginPath = "/account/login";
            //    options.AccessDeniedPath = "/account/accessdenied";
            //    options.SlidingExpiration = true;
            //});


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Shop/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Shop}/{action=Index}/{id?}");

            //AppDbInitializer.Seed(app);

            app.Run();
        }
    }
}