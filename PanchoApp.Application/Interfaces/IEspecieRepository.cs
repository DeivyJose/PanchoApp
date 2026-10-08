using PanchoApp.Domain.Entities;

namespace PanchoApp.Application.Interfaces;

public interface IEspecieRepository
{
    Task<List<Especie>> GetAllAsync();

    Task<Especie?> GetByIdAsync(int id);

    Task AddAsync(Especie especie);

    Task UpdateAsync(Especie especie);

    Task DeleteAsync(int id);
}