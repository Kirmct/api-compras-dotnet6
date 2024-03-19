using ApiCompras.Application.DTOs;
using ApiCompras.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompras.Api.Controllers;

[ApiController]
[Route("v1/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("token")]
    public async Task<ActionResult> PostAsync(
        [FromBody]UserDTO userDTO)
    {
        var result = await _userService.GenerateTokenAsync(userDTO);
        if(!result.IsSuccess)
            return BadRequest(result);

        return Ok(result.Data);
    }
}
