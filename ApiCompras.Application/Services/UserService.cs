using ApiCompras.Application.DTOs;
using ApiCompras.Application.DTOs.Validations;
using ApiCompras.Application.Services.Interface;
using ApiCompras.Domain.Authentication;
using ApiCompras.Domain.Repositories;

namespace ApiCompras.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserService(
        IUserRepository userRepository, 
        ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO)
    {
        if (userDTO == null)
            return ResultService.Fail<dynamic>("Objeto deve ser informado");
        var validator = new UserDTOValidator().Validate(userDTO);

        if (!validator.IsValid)
            return ResultService.RequestError<dynamic>("Erros de validação", validator);

        var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDTO.Email, userDTO.Password);
        
        if(user == null)
            return ResultService.Fail<dynamic>("Usuário ou senha não encontrado!");
        return ResultService.Ok<dynamic>(_tokenGenerator.Generator(user));
    }
}
