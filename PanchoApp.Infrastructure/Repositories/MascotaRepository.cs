using Microsoft.EntityFrameworkCore;
using PanchoApp.Application.Interfaces;
using PanchoApp.Domain.Entities;
using PanchoApp.Infrastructure.Data;

namespace PanchoApp.Infrastructure.Repositories;

public class MascotaRepository : IMascotaRepository
{
    private readonly PanchoDbContext _context;

    public MascotaRepository(PanchoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Mascota>> GetAllAsync()
    {
        return await _context.Mascotas
            .Include(m => m.Cliente)
            .Include(m => m.Especie)
            .Include(m => m.Raza)
            .OrderBy(m => m.Nombre)
            .ToListAsync();
    }

    public async Task<Mascota?> GetByIdAsync(int id)
    {
        return await _context.Mascotas
            .Include(m => m.Cliente)
            .Include(m => m.Especie)
            .Include(m => m.Raza)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<List<Mascota>> GetByClienteIdAsync(int clienteId)
    {
        return await _context.Mascotas
            .Include(m => m.Especie)
            .Include(m => m.Raza)
            .Where(m => m.ClienteID == clienteId)
            .OrderBy(m => m.Nombre)
            .ToListAsync();
    }

    public async Task AddAsync(Mascota mascota)
    {
        _context.Mascotas.Add(mascota);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Mascota mascota)
    {
        _context.Mascotas.Update(mascota);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var mascota = await _context.Mascotas.FindAsync(id);

        if (mascota is null)
        {
            return;
        }

        mascota.Activa = false;

        await _context.SaveChangesAsync();
    }
}