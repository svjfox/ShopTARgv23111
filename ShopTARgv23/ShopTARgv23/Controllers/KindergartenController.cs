using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;


namespace ShopTARgv23.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KindergartenController : Controller
    {




        private readonly ApplicationDbContext _context;

        public KindergartenController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Kindergartens.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var kindergarten = await _context.Kindergartens.FindAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }
            return Ok(kindergarten);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Kindergarten kindergarten)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            kindergarten.CreatedAt = DateTime.UtcNow;
            _context.Kindergartens.Add(kindergarten);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = kindergarten.Id }, kindergarten);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Kindergarten kindergarten)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingKindergarten = await _context.Kindergartens.FindAsync(id);
            if (existingKindergarten == null)
            {
                return NotFound();
            }

            existingKindergarten.GroupName = kindergarten.GroupName;
            existingKindergarten.ChildrenCount = kindergarten.ChildrenCount;
            existingKindergarten.KindergartenName = kindergarten.KindergartenName;
            existingKindergarten.Teacher = kindergarten.Teacher;
            existingKindergarten.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kindergarten = await _context.Kindergartens.FindAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }

            _context.Kindergartens.Remove(kindergarten);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
