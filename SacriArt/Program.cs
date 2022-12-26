using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SacriArt.Data;
using SacriArt.Services;



namespace SacriArt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //builder.Services.AddControllersWithViews();

            builder.Configuration.Bind("ConnectionStrings", new Config());

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Config.ConnectionString));

           
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "sacriartAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            builder.Services.AddControllersWithViews(x => {
				x.Conventions.Add(new AreaAuthorization("Admin", "AdminArea"));
			});

            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("UserArea", policy => { policy.RequireRole("user"); });
            });

            //builder.Services.AddControllersWithViews(x =>
            //{
            //    x.Conventions.Add(new AreaAuthorization("User", "UserArea"));
            //});



            builder.Services.AddRazorPages();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Shop/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            
            app.MapControllerRoute(
               name: "Admin",
               pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

            app.MapControllerRoute(
             name: "User",
             pattern: "{area:exists}/{controller=User}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Shop}/{action=Index}/{id?}");

            app.MapRazorPages();


            AppDbInitializer.Seed(app);
            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();


            app.Run();

        }
    }
}