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

namespace SacriArt.Areas.User.Controllers
{


    [Area("User")]
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

    


    }
}