using ApiCompras.Domain.Entities;
using ApiCompras.Domain.Repositories;
using ApiCompras.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCompras.Infra.Data.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly ApiDbContext _context;

    public PurchaseRepository(ApiDbContext context)
    {
        _context = context;
    }

    private IQueryable<Purchase> Query() 
    {
        return  _context.Purchases
            .Include(p => p.Person)
            .Include(p => p.Product);
    }

    public async Task<Purchase> CreateAsync(Purchase purchase)
    {
        _context.Purchases.Add(purchase);
        await _context.SaveChangesAsync();
        return purchase;
    }

    public async Task DeleteAsync(Purchase purchase)
    {
        _context.Purchases.Remove(purchase);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Purchase>> GetAllAsync()
    {
        return await Query()
                     .AsNoTracking()
                     .ToListAsync();
    }

    public async Task<Purchase> GetByIdAsync(int id)
    {
        return await Query()
                     .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Purchase purchase)
    {
        _context.Purchases.Update(purchase);
        await _context.SaveChangesAsync();
    }
}
