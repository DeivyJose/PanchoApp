using Microsoft.EntityFrameworkCore;
using PanchoApp.Application.Interfaces;
using PanchoApp.Domain.Entities;
using PanchoApp.Infrastructure.Data;

namespace PanchoApp.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly PanchoDbContext _context;

    public ClienteRepository(PanchoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .Include(c => c.Mascotas)
            .OrderBy(c => c.Nombre)
            .ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _context.Clientes
            .Include(c => c.Mascotas)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente is null)
        {
            return;
        }

        cliente.Activo = false;

        await _context.SaveChangesAsync();
    }
}