using ApiCompras.Application.DTOs;

namespace ApiCompras.Application.Services.Interface;

public interface IUserService
{
    Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO);
}
