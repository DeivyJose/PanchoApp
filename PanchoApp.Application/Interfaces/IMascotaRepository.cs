using PanchoApp.Domain.Entities;

namespace PanchoApp.Application.Interfaces;

public interface IMascotaRepository
{
    Task<List<Mascota>> GetAllAsync();

    Task<Mascota?> GetByIdAsync(int id);

    Task<List<Mascota>> GetByClienteIdAsync(int clienteId);

    Task AddAsync(Mascota mascota);

    Task UpdateAsync(Mascota mascota);

    Task DeleteAsync(int id);
}