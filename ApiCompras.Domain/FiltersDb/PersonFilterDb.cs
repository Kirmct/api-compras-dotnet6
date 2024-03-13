using ApiCompras.Domain.Repositories;

namespace ApiCompras.Domain.FiltersDb;

public class PersonFilterDb : PageBaseRequest
{
    public string? Name { get; set; }
}
