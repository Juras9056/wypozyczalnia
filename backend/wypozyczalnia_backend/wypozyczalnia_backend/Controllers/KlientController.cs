using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wypozyczalnia_backend.Models;

namespace wypozyczalnia_backend.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class KlientController : ControllerBase
{
    private readonly AppDbContext _context;

    public KlientController(AppDbContext context)
    {
        _context = context;
    }

    // api/Klient
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var klienci = await _context.Klienci
            .Select(k => new
            {
                k.Id,
                Imie = k.Imie ?? string.Empty, // Obsługa NULL
                Nazwisko = k.Nazwisko ?? string.Empty, // Obsługa NULL
                Nazwa = k.Nazwa ?? string.Empty,
                PESEL = k.PESEL ?? 0,
                NIP = k.NIP ?? 0,
                NrTelefonu = k.NrTelefonu ?? string.Empty,
                DowodOsobisty = k.DowodOsobisty ?? string.Empty
            })
            .ToListAsync();

        if (klienci.Count == 0)
        {
            return NotFound(); //404
        }
        
        return Ok(klienci); //200
    }

    // api/Klient/{id} np api/klient/2
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var klient = await _context.Klienci.FindAsync(id);
        if (klient == null) return NotFound();
        return Ok(klient);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Klient klient)
    {
        _context.Klienci.Add(klient);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = klient.Id }, klient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Klient klient)
    {
        if (id != klient.Id) return BadRequest();
        _context.Entry(klient).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var klient = await _context.Klienci.FindAsync(id);
        if (klient == null) return NotFound();
        _context.Klienci.Remove(klient);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}