namespace ApiCompras.Application.DTOs;

public class PageBaseResponseDTO<T>
{
    public PageBaseResponseDTO(int totalRegisters, List<T> data)
    {
        TotalRegisters = totalRegisters;
        Data = data;
    }

    public int TotalRegisters { get; private set; }
    public List<T> Data { get; private set; }
}
