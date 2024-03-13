using ApiCompras.Application.DTOs;

namespace ApiCompras.Application.Services.Interface;

public interface IProductService
{
    Task<ResultService<ICollection<ProductDTO>>> GetAllAsync();
    Task<ResultService<ProductDTO>> GetByIdAsync(int id);
    Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);
    Task<ResultService<ProductDTO>> UpdateAsync(ProductDTO productDTO);
    Task<ResultService> DeleteAsync(int id);
}
