using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wpf_app;
using wypozyczalnia_backend.Models;

namespace wypozyczalnia_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WypozyczenieController : ControllerBase
{
    private readonly AppDbContext _context;

    public WypozyczenieController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Wypozyczenia.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var wypozyczenie = await _context.Wypozyczenia.FindAsync(id);
        if (wypozyczenie == null) return NotFound();
        return Ok(wypozyczenie);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Wypozyczenie wypozyczenie)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Wypozyczenia.Add(wypozyczenie);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = wypozyczenie.Id }, wypozyczenie);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Wypozyczenie wypozyczenie)
    {
        if (id != wypozyczenie.Id) return BadRequest();
        _context.Entry(wypozyczenie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var wypozyczenie = await _context.Wypozyczenia.FindAsync(id);
        if (wypozyczenie == null) return NotFound();
        _context.Wypozyczenia.Remove(wypozyczenie);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
