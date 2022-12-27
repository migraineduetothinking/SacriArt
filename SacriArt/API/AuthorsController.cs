using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SacriArt.Data;
using SacriArt.Models.ShopModels;

namespace SacriArt.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        AppDbContext db;
        
        public AuthorsController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            return await db.Authors.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            Author? authors = await db.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (authors == null)
                return NotFound();
            return new ObjectResult(authors);
        }


        [HttpGet("{FullName}")]
        public async Task<ActionResult<Author>> Get(string FullName)
        {
            Author? authors = await db.Authors.FirstOrDefaultAsync(x => x.FullName == FullName);
            if (authors == null)
                return NotFound();
            return new ObjectResult(authors);
        }


        [HttpPost]
        public async Task<ActionResult<Author>> Post(Author authors)
        {
            if (authors == null)
            {
                return BadRequest();
            }

            db.Authors.Add(authors);
            await db.SaveChangesAsync();
            return Ok(authors);
        }

        
        [HttpPut]
        public async Task<ActionResult<Author>> Put(Author authors)
        {
            if (authors == null)
            {
                return BadRequest();
            }
            if (!db.Authors.Any(x => x.Id == authors.Id))
            {
                return NotFound();
            }

            db.Update(authors);
            await db.SaveChangesAsync();
            return Ok(authors);
        }

        
        [HttpDelete("{FullName}")]
        public async Task<ActionResult<Author>> Delete(string FullName)
        {
            Author? authors = db.Authors.FirstOrDefault(x => x.FullName == FullName);
            if (authors == null)
            {
                return NotFound();
            }
            db.Authors.Remove(authors);
            await db.SaveChangesAsync();
            return Ok(authors);
        }
    }
}

