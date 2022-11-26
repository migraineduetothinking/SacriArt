using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SacriArt.Domain;
using SacriArt.Models.ShopModels;
using SacriArt.Models.ViewModels;
using System.Diagnostics;
using System.Reflection.Emit;

namespace SacriArt.Controllers
{
    public class ShopController : Controller
    {
        AppDbContext db;
        private readonly ILogger<ShopController> _logger;

        IWebHostEnvironment _appEnvironment;

        //private readonly IPaintingService _paintService;

        public ShopController(ILogger<ShopController> logger, AppDbContext context, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            db = context;
            _appEnvironment = appEnvironment;
            //_paintService = paintService;

            //db.Database.EnsureCreated();
           
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string name, int category = 0, int page = 1, SortOption sortOrder = SortOption.NameAsc)
        {
            int pageSize = 8;

            IQueryable<Painting> paintings = db.Paintings; 

            if (category != 0)
            {
                paintings = paintings.Where(p => p.AuthorId == category);
            }

            //if (!string.IsNullOrEmpty(name))
            //{
            //    paintings = paintings.Where(p => p.Name!.Contains(name));
            //}
            
            
            switch (sortOrder)
            {
                case SortOption.NameDesc:
                    paintings = paintings.OrderByDescending(s => s.Name);
                    break;
                case SortOption.PriceAsc:
                    paintings = paintings.OrderBy(s => s.Price);
                    break;
                case SortOption.PriceDesc:
                    paintings = paintings.OrderByDescending(s => s.Price);
                    break;
               
                default:
                    paintings = paintings.OrderBy(s => s.Name);
                    break;
            }

           
            var count = await paintings.CountAsync();
            var items = await paintings.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

           
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(db.Authors.ToList(), db.ExhibitionTitles.ToList(), db.Styles.ToList(), category),
                new SortViewModel(sortOrder)
            );

            return View(viewModel);

                       
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}