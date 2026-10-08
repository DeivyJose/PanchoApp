using PanchoApp.Domain.Entities;

namespace PanchoApp.Application.Interfaces;

public interface IRazaRepository
{
    Task<List<Raza>> GetAllAsync();

    Task<Raza?> GetByIdAsync(int id);

    Task<List<Raza>> GetByEspecieIdAsync(int especieId);

    Task AddAsync(Raza raza);

    Task UpdateAsync(Raza raza);

    Task DeleteAsync(int id);
}