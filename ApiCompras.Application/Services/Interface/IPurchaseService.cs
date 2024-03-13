using ApiCompras.Application.DTOs;

namespace ApiCompras.Application.Services.Interface;

public interface IPurchaseService
{
    Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAllAsync();
    Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id);
    Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
    Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO purchaseDTO);
    Task<ResultService> DeleteAsync(int id);
}
