using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SacriArt.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SacriArt.Models.ShopModels;
using SacriArt.Models.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace SacriArt.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class UserController : Controller
    {

        AppDbContext db;


        IWebHostEnvironment _appEnvironment;

        
        public UserController(AppDbContext context, IWebHostEnvironment appEnvironment)
        {

            db = context;
            _appEnvironment = appEnvironment;


            //db.Database.EnsureCreated();

        }

        public IActionResult Index()
        {
            
            return View();
        }

        /*Adding new painting*/
        public IActionResult CreatePainting()
        {

            ViewBag.Authors = new SelectList(db.Authors, "FullName", "FullName");
            ViewBag.ExhibitionTitles = new SelectList(db.ExhibitionTitles, "Name", "Name");
            ViewBag.Styles = new SelectList(db.Styles, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePainting(Painting painting, IFormFile uploadedFile)
        {

            if (uploadedFile != null)
            {

                string path = "/img/new/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                painting.ImageUrl = path;

                db.Paintings.Add(painting);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        /*Adding new Author*/
        public IActionResult CreateAuthor()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(Author author)
        {


            db.Authors.Add(author);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        /*Adding new ExhibitionTitle*/
        public IActionResult CreateExhibitionTitle()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExhibitionTitle(ExhibitionTitle exhibitiontitle)
        {



            db.ExhibitionTitles.Add(exhibitiontitle);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        /*Adding new Style*/
        public IActionResult CreateStyle()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStyle(Style style)
        {

            db.Styles.Add(style);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }



    }
}