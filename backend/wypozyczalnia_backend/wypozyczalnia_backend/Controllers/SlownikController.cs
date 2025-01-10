using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wypozyczalnia_backend.Models;

namespace wypozyczalnia_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SlownikController : ControllerBase
{
    private readonly AppDbContext _context;

    public SlownikController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Slowniki.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var slownik = await _context.Slowniki.FindAsync(id);
        if (slownik == null) return NotFound();
        return Ok(slownik);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Slownik slownik)
    {
        _context.Slowniki.Add(slownik);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = slownik.Id }, slownik);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Slownik slownik)
    {
        if (id != slownik.Id) return BadRequest();
        _context.Entry(slownik).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var slownik = await _context.Slowniki.FindAsync(id);
        if (slownik == null) return NotFound();
        _context.Slowniki.Remove(slownik);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}