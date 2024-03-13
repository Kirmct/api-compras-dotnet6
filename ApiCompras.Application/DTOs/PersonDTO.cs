namespace ApiCompras.Application.DTOs;

public class PersonDTO : BaseDTO
{
    public int Id { get; set; }
    public string Document { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
