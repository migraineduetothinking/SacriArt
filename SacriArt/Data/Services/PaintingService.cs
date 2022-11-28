using SacriArt.Domain;
using SacriArt.Models.ViewModels;
using SacriArt.Models.ShopModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eTickets.Data.Services
{
    public class PaintingService : EntityBaseRepository<Painting>, IPaintingService
    {
        private readonly AppDbContext _context;
        public PaintingService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Painting> GetPaintingByIdAsync(int id)
        {
            var paintingDetails = await _context.Paintings
              .Include(c => c.Author)
              .Include(p => p.ExhibitionTitle)
              .Include(am => am.Style)
              .FirstOrDefaultAsync(n => n.Id == id);

            return paintingDetails;
        }




    }
}
