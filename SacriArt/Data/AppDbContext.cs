using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SacriArt.Models.ShopModels;

namespace SacriArt.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
          
        }
               

        public DbSet<Painting> Paintings { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Style> Styles { get; set; } = null!;
        public DbSet<ExhibitionTitle> ExhibitionTitles { get; set; } = null!;



    }
}
