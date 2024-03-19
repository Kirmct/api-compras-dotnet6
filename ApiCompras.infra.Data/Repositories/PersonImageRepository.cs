using ApiCompras.Domain.Entities;
using ApiCompras.Domain.Repositories;
using ApiCompras.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCompras.Infra.Data.Repositories;

public class PersonImageRepository : IPersonImageRepository
{
    private readonly ApiDbContext _db;

    public PersonImageRepository(ApiDbContext db)
    {
        _db = db;
    }

    public async Task<PersonImage> CreateAsync(PersonImage personImage)
    {
        await _db.PersonImages.AddAsync(personImage);
        await _db.SaveChangesAsync();
        return personImage;
    }

    public async Task<ICollection<PersonImage>> GetAllAsync()
    {
        return await _db.PersonImages.ToListAsync();
    }

    public async Task<ICollection<PersonImage>> GetAllByPersonId(int personId)
    {
        return await _db.PersonImages
            .AsNoTracking()
            .Where(x => x.PersonId == personId)
            .ToListAsync();
    }

    public async Task<PersonImage> GetByIdAsync(int id)
    {
        return await _db.PersonImages
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(PersonImage personImage)
    {
        await UpdateAsync(personImage);
        await _db.SaveChangesAsync();
    }
}
