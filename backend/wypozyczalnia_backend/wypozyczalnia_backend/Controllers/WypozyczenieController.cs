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
        try
        {
            var wypozyczenia = await _context.Wypozyczenie
                .Where(w => w.Klient != null && w.Samochod != null)
                .Include(w => w.Klient)
                .Include(w => w.Samochod)
                .ToListAsync();

            return Ok(wypozyczenia);
        }
        catch
        {
            return StatusCode(500, "Wystąpił błąd podczas pobierania danych.");
        }
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var wypozyczenie = await _context.Wypozyczenie
                .Include(w => w.Klient) // Correct navigation properties
                .Include(w => w.Samochod)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (wypozyczenie == null)
                return NotFound("Nie znaleziono wypożyczenia o podanym ID.");

            return Ok(wypozyczenie);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}\n{ex.StackTrace}");
            return StatusCode(500, "Wystąpił błąd podczas pobierania danych.");
        }
    }

    // Utwórz nowe wypożyczenie
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Wypozyczenie wypozyczenie)
    {
        if (!ModelState.IsValid)
            return BadRequest("Dane wypożyczenia są nieprawidłowe.");

        try
        {
            _context.Wypozyczenie.Add(wypozyczenie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = wypozyczenie.Id }, wypozyczenie);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas tworzenia wypożyczenia: {ex.Message}\n{ex.StackTrace}");
            return StatusCode(500, "Wystąpił błąd podczas tworzenia wypożyczenia.");
        }
    }

    // Zaktualizuj istniejące wypożyczenie
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Wypozyczenie wypozyczenie)
    {
        if (id != wypozyczenie.Id)
            return BadRequest("ID wypożyczenia nie zgadza się z przesłanym obiektem.");

        try
        {
            _context.Entry(wypozyczenie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine($"Błąd podczas aktualizacji wypożyczenia: {ex.Message}\n{ex.StackTrace}");
            return NotFound("Nie znaleziono wypożyczenia do aktualizacji.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas aktualizacji wypożyczenia: {ex.Message}\n{ex.StackTrace}");
            return StatusCode(500, "Wystąpił błąd podczas aktualizacji wypożyczenia.");
        }
    }

    // Usuń wypożyczenie
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var wypozyczenie = await _context.Wypozyczenie.FindAsync(id);
            if (wypozyczenie == null)
                return NotFound("Nie znaleziono wypożyczenia do usunięcia.");

            _context.Wypozyczenie.Remove(wypozyczenie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd podczas usuwania wypożyczenia: {ex.Message}\n{ex.StackTrace}");
            return StatusCode(500, "Wystąpił błąd podczas usuwania wypożyczenia.");
        }
    }
}