using ApiCompras.Domain.Entities;
using ApiCompras.Domain.FiltersDb;

namespace ApiCompras.Domain.Repositories;

public interface IPersonRepository
{
    Task<Person> GetByIdAsync(int id);
    Task<ICollection<Person>> GetAll();
    Task<Person> CreateAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(Person person);
    Task<int> GetIdByDocument(string document);
    Task<PageBaseResponse<Person>> GetPagedAsync(PersonFilterDb request);
}
