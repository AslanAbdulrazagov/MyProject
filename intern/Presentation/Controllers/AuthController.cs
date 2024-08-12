using Business.Dtos;
using Business.Dtos.AuthDtos;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {

        return Ok(await _authService.RegisterAsync(dto));
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        return Ok(await _authService.LoginAsync(dto));
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateRoles()
    {
        await _authService.CreateRolesAsync();
        return Ok();
    }
}
