using ApiCompras.Domain.Entities;
using ApiCompras.Domain.FiltersDb;
using ApiCompras.Domain.Repositories;
using ApiCompras.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCompras.Infra.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ApiDbContext _db;

    public PersonRepository(ApiDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<Person>> GetAll()
    {
        return await _db.People.ToListAsync();
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Person> CreateAsync(Person person)
    {
        await _db.People.AddAsync(person);
        await _db.SaveChangesAsync();
        return person;
    }
    public async Task UpdateAsync(Person person)
    {
         _db.People.Update(person);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Person person)
    {
        _db.People.Remove(person);
        await _db.SaveChangesAsync();
    }

    public async Task<int> GetIdByDocument(string document)
    {
        return (await _db.People.FirstOrDefaultAsync(
            x => x.Document == document))?.Id ?? 0;
    }

    public async Task<PageBaseResponse<Person>> GetPagedAsync(PersonFilterDb request)
    {
        var people = _db.People.AsQueryable();
        if (!string.IsNullOrEmpty(request.Name))
            people = people.Where(x => x.Name.Contains(request.Name));

        return await PageBaseResponseHelper
            .GetResponseAsync<PageBaseResponse<Person>, Person>(people, request);
    }
}
