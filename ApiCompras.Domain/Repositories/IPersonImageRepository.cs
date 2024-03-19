using ApiCompras.Domain.Entities;

namespace ApiCompras.Domain.Repositories;

public interface IPersonImageRepository
{
    Task<ICollection<PersonImage>> GetAllAsync();
    Task<ICollection<PersonImage>> GetAllByPersonId(int personId);
    Task<PersonImage> GetByIdAsync(int id);
    Task<PersonImage> CreateAsync(PersonImage personImage);
    Task UpdateAsync(PersonImage personImage);
}
