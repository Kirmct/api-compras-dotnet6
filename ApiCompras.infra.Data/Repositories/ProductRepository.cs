using ApiCompras.Domain.Entities;
using ApiCompras.Domain.Repositories;
using ApiCompras.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCompras.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApiDbContext _context;

    public ProductRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Product>> GetAllAsync()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();
        return products;
    }

    public async Task<int> GetIdByCodeErp(string codeErp)
    {        
        return (await _context.Products.FirstOrDefaultAsync(
            x => x.CodeErp == codeErp))?.Id ?? 0;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);        
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }
}
