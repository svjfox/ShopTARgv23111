using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARgv23.Data;
using ShopTARgv23.Models.Kindergarten;

[ApiController]
[Route("api/[controller]")]
public class KindergartenController : ControllerBase
{
    private readonly ShopTARgv23Context _context;

    public KindergartenController(ShopTARgv23Context context)
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
    public async Task<IActionResult> Create([FromBody] ShopTARgv23.Core.Domain.Kindergarten kindergarten) // Change the parameter type
    {
        kindergarten.CreatedAt = DateTime.UtcNow;
        _context.Kindergartens.Add(kindergarten);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = kindergarten.Id }, kindergarten);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ShopTARgv23.Core.Domain.Kindergarten kindergarten) // Change the parameter type
    {
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
