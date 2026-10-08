using Microsoft.EntityFrameworkCore;
using PanchoApp.Application.Interfaces;
using PanchoApp.Domain.Entities;
using PanchoApp.Infrastructure.Data;

namespace PanchoApp.Infrastructure.Repositories;

public class EspecieRepository : IEspecieRepository
{
    private readonly PanchoDbContext _context;

    public EspecieRepository(PanchoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Especie>> GetAllAsync()
    {
        return await _context.Especies
            .Include(e => e.Razas)
            .OrderBy(e => e.Nombre)
            .ToListAsync();
    }

    public async Task<Especie?> GetByIdAsync(int id)
    {
        return await _context.Especies
            .Include(e => e.Razas)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(Especie especie)
    {
        _context.Especies.Add(especie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Especie especie)
    {
        _context.Especies.Update(especie);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var especie = await _context.Especies.FindAsync(id);

        if (especie is null)
        {
            return;
        }

        especie.Activa = false;

        await _context.SaveChangesAsync();
    }
}