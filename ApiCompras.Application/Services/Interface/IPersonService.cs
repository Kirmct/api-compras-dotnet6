using ApiCompras.Application.DTOs;
using ApiCompras.Domain.FiltersDb;

namespace ApiCompras.Application.Services.Interface;

public interface IPersonService
{
    Task<ResultService<ICollection<PersonDTO>>> GetAsync();
    Task<ResultService<PersonDTO>> GetByIdAsync(int id);
    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
    Task<ResultService<PersonDTO>> UpdateAsync(PersonDTO personDTO);
    Task<ResultService> DeleteAsync(int id);
    Task<ResultService<PageBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb);
}
