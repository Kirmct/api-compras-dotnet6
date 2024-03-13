namespace ApiCompras.Domain.Repositories;

public class PageBaseRequest
{
    public PageBaseRequest()
    {
        Page = 1;
        PageSize = 10;
        OrderBy = "Id";
    }

    public int Page { get; set; }
    public int PageSize { get; set; } 
    public string OrderBy { get; set; }
}
