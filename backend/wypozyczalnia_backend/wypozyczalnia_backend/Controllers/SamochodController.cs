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

    // GET: api/Samochod
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var samochody = await _context.Samochody
            .Select(s => new
            {
                s.Id,
                Marka = s.Marka ?? string.Empty, // Obsługa NULL dla string
                Model = s.Model ?? string.Empty, 
                Paliwo = s.Paliwo,
                MocKm = s.MocKm, // Typ int
                RokProdukcji = s.RokProdukcji,
                IloscOsob = s.IloscOsob,
                Typ = s.Typ,
                Klimatyzacja = s.Klimatyzacja, // Typ bool
                Nawigacja = s.Nawigacja,
                CzujnikiParowania = s.CzujnikiParowania,
                CzyDostepny = s.CzyDostepny
            })
            .ToListAsync();

        if (!samochody.Any())
        {
            return NotFound("Brak samochodów w bazie.");
        }

        return Ok(samochody);
    }

    // GET: api/Samochod/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var samochod = await _context.Samochody.FindAsync(id);

        if (samochod == null)
        {
            return NotFound($"Samochód o ID {id} nie został znaleziony.");
        }

        return Ok(samochod);
    }

    // POST: api/Samochod
    [HttpPost]
    public async Task<IActionResult> Create(Samochod samochod)
    {
        if (samochod == null)
        {
            return BadRequest("Dane samochodu są nieprawidłowe.");
        }

        _context.Samochody.Add(samochod);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = samochod.Id }, samochod);
    }

    // PUT: api/Samochod/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Samochod samochod)
    {
        if (id != samochod.Id)
        {
            return BadRequest("ID samochodu w zapytaniu nie pasuje do ID obiektu.");
        }

        var existingSamochod = await _context.Samochody.FindAsync(id);
        if (existingSamochod == null)
        {
            return NotFound($"Samochód o ID {id} nie został znaleziony.");
        }

        // Aktualizacja wartości
        existingSamochod.Marka = samochod.Marka ?? existingSamochod.Marka;
        existingSamochod.Model = samochod.Model ?? existingSamochod.Model;
        existingSamochod.Paliwo = samochod.Paliwo;
        existingSamochod.MocKm = samochod.MocKm;
        existingSamochod.RokProdukcji = samochod.RokProdukcji;
        existingSamochod.IloscOsob = samochod.IloscOsob;
        existingSamochod.Typ = samochod.Typ;
        existingSamochod.Klimatyzacja = samochod.Klimatyzacja;
        existingSamochod.Nawigacja = samochod.Nawigacja;
        existingSamochod.CzujnikiParowania = samochod.CzujnikiParowania;
        existingSamochod.CzyDostepny = samochod.CzyDostepny;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Samochod/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var samochod = await _context.Samochody.FindAsync(id);

        if (samochod == null)
        {
            return NotFound($"Samochód o ID {id} nie został znaleziony.");
        }

        _context.Samochody.Remove(samochod);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    
}
