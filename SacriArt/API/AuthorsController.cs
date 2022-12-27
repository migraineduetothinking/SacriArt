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
            Author? author = await db.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
                return NotFound();
            return new ObjectResult(author);
        }


        [HttpGet("{FullName}")]
        public async Task<ActionResult<Author>> Get(string FullName)
        {
            Author? author = await db.Authors.FirstOrDefaultAsync(x => x.FullName == FullName);
            if (author == null)
                return NotFound();
            return new ObjectResult(author);
        }


        [HttpPost]
        public async Task<ActionResult<Author>> Post(Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            db.Authors.Add(author);
            await db.SaveChangesAsync();
            return Ok(author);
        }

        
        [HttpPut]
        public async Task<ActionResult<Author>> Put(Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            if (!db.Authors.Any(x => x.Id == author.Id))
            {
                return NotFound();
            }

            db.Update(author);
            await db.SaveChangesAsync();
            return Ok(author);
        }

        
        [HttpDelete("{FullName}")]
        public async Task<ActionResult<Author>> Delete(string FullName)
        {
            Author? author = db.Authors.FirstOrDefault(x => x.FullName == FullName);
            if (author == null)
            {
                return NotFound();
            }
            db.Authors.Remove(author);
            await db.SaveChangesAsync();
            return Ok(author);
        }
    }
}

