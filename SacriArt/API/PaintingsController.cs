using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SacriArt.Data;
using SacriArt.Models.ShopModels;

namespace SacriArt.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaintingsController : ControllerBase
    {
        AppDbContext db;

        public PaintingsController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Painting>>> Get()
        {
            return await db.Paintings.ToListAsync();
        }

        // GET api/goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Painting>> Get(int id)
        {
            Painting? painting = await db.Paintings.FirstOrDefaultAsync(x => x.Id == id);
            if (painting == null)
                return NotFound();
            return new ObjectResult(painting);
        }

        // POST api/goods
        [HttpPost]
        public async Task<ActionResult<Painting>> Post(Painting painting)
        {
            if (painting == null)
            {
                return BadRequest();
            }

            db.Paintings.Add(painting);
            await db.SaveChangesAsync();
            return Ok(painting);
        }

        // PUT api/goods/
        [HttpPut]
        public async Task<ActionResult<Painting>> Put(Painting painting)
        {
            if (painting == null)
            {
                return BadRequest();
            }
            if (!db.Paintings.Any(x => x.Id == painting.Id))
            {
                return NotFound();
            }

            db.Update(painting);
            await db.SaveChangesAsync();
            return Ok(painting);
        }

        // DELETE api/goods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Painting>> Delete(int id)
        {
            Painting? painting = db.Paintings.FirstOrDefault(x => x.Id == id);
            if (painting == null)
            {
                return NotFound();
            }
            db.Paintings.Remove(painting);
            await db.SaveChangesAsync();
            return Ok(painting);
        }
    }
}

