using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SacriArt.Models.ShopModels;

namespace SacriArt.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Painting> Paintings { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Style> Styles { get; set; } = null!;
        public DbSet<ExhibitionTitle> ExhibitionTitles { get; set; } = null!;



    }
}
