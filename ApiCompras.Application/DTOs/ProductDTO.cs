namespace ApiCompras.Application.DTOs;

public class ProductDTO : BaseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CodeErp { get;  set; } = string.Empty;
    public decimal Price { get;  set; }
}
