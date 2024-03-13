using ApiCompras.Domain.Entities;

namespace ApiCompras.Application.DTOs;

public class PurchaseDetailDTO : BaseDTO
{
    public int Id { get; set; }
    public string Product { get; set; }
    public string Person { get; set; }
    public DateTime Date { get; set; }
}
