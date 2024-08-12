using Business.Dtos.AuthDtos;
using Core.Entities;

namespace Business.Services.Interfaces;

public interface IAuthService
{
    Task<AccessToken> RegisterAsync(RegisterDto dto);
    Task<AccessToken> LoginAsync(LoginDto dto);
    Task CreateRolesAsync();
}
