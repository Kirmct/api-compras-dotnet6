using ApiCompras.Application.DTOs.PersonImage;
using ApiCompras.Domain.Entities;

namespace ApiCompras.Application.Services.Interface;

public interface IPersonImageService
{
    Task<ResultService<ICollection<PersonImageDTO>>> GetAllAsync();
    Task<ResultService<ICollection<PersonImageDTO>>> GetAllByPersonId(int personId);
    Task<ResultService<PersonImageDTO>> GetByIdAsync(int id);
    Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDto);
    Task<ResultService> CreateImageUrlAsync(PersonImageDTO personImageDto);
    Task UpdateAsync(PersonImage personImage);
}
