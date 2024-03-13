using ApiCompras.Domain.Entities;

namespace ApiCompras.Domain.Repositories;

public interface IPurchaseRepository
{
    Task<Purchase> GetByIdAsync(int id);
    Task<ICollection<Purchase>> GetAllAsync();
    Task<Purchase> CreateAsync(Purchase purchase);
    Task UpdateAsync(Purchase purchase);
    Task DeleteAsync(Purchase purchase);
}
