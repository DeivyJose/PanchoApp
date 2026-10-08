using Microsoft.EntityFrameworkCore;
using PanchoApp.Application.Interfaces;
using PanchoApp.Domain.Entities;
using PanchoApp.Infrastructure.Data;

namespace PanchoApp.Infrastructure.Repositories;

public class RazaRepository : IRazaRepository
{
    private readonly PanchoDbContext _context;

    public RazaRepository(PanchoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Raza>> GetAllAsync()
    {
        return await _context.Razas
            .Include(r => r.Especie)
            .OrderBy(r => r.Nombre)
            .ToListAsync();
    }

    public async Task<Raza?> GetByIdAsync(int id)
    {
        return await _context.Razas
            .Include(r => r.Especie)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Raza>> GetByEspecieIdAsync(int especieId)
    {
        return await _context.Razas
            .Where(r => r.EspecieId == especieId)
            .OrderBy(r => r.Nombre)
            .ToListAsync();
    }

    public async Task AddAsync(Raza raza)
    {
        _context.Razas.Add(raza);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Raza raza)
    {
        _context.Razas.Update(raza);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var raza = await _context.Razas.FindAsync(id);

        if (raza is null)
        {
            return;
        }

        raza.Activa = false;

        await _context.SaveChangesAsync();
    }
}