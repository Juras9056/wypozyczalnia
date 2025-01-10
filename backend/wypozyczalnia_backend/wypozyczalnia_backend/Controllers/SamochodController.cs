using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wypozyczalnia_backend.Models;

namespace wypozyczalnia_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SamochodController : ControllerBase
{
    private readonly AppDbContext _context;

    public SamochodController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Samochody.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var samochod = await _context.Samochody.FindAsync(id);
        if (samochod == null) return NotFound();
        return Ok(samochod);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Samochod samochod)
    {
        _context.Samochody.Add(samochod);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = samochod.Id }, samochod);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Samochod samochod)
    {
        if (id != samochod.Id) return BadRequest();
        _context.Entry(samochod).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var samochod = await _context.Samochody.FindAsync(id);
        if (samochod == null) return NotFound();
        _context.Samochody.Remove(samochod);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}