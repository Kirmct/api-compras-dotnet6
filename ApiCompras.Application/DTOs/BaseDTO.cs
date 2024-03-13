namespace ApiCompras.Application.DTOs
{
    public abstract class BaseDTO
    {
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public DateTime? UpdateDate { get; private set; }
    }
}
