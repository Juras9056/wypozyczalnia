using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wypozyczalnia_backend.Models;

namespace wypozyczalnia_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UzytkownikController : ControllerBase
{
    private readonly AppDbContext _context;

    public UzytkownikController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Uzytkownicy.ToListAsync());
    }

    [HttpGet("{login}")]
    public async Task<IActionResult> GetByLogin(string login)
    {
        var uzytkownik = await _context.Uzytkownicy.FirstOrDefaultAsync(u => u.Login == login);
        if (uzytkownik == null) return NotFound();
        return Ok(uzytkownik);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Uzytkownik uzytkownik)
    {
        _context.Uzytkownicy.Add(uzytkownik);
        await _context.SaveChangesAsync();
        return Ok(uzytkownik);
    }

    [HttpPut("{login}")]
    public async Task<IActionResult> Update(string login, Uzytkownik uzytkownik)
    {
        var existingUser = await _context.Uzytkownicy.FirstOrDefaultAsync(u => u.Login == login);
        if (existingUser == null) return NotFound();
        existingUser.Haslo = uzytkownik.Haslo;
        existingUser.Rola = uzytkownik.Rola;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{login}")]
    public async Task<IActionResult> Delete(string login)
    {
        var uzytkownik = await _context.Uzytkownicy.FirstOrDefaultAsync(u => u.Login == login);
        if (uzytkownik == null) return NotFound();
        _context.Uzytkownicy.Remove(uzytkownik);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}