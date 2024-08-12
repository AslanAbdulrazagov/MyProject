using AutoMapper;
using Business.Abstactions.Helpers;
using Business.Dtos.AuthDtos;
using Business.Exceptions.Common;
using Business.Services.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Business.Services.Implementations;

public class AuthService : IAuthService
{

    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    /* private readonly SignInManager<AppUser> _signInManager;*/ //remove
    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;

    public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, ITokenHelper tokenHelper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        //_signInManager = signInManager;

        _mapper = mapper;
        _tokenHelper = tokenHelper;
    }

    public async Task<AccessToken> RegisterAsync(RegisterDto dto)
    {
        AppUser appUser = _mapper.Map<AppUser>(dto);

        var result = await _userManager.CreateAsync(appUser, dto.Password);

        if (!result.Succeeded)
        {
            throw new InvalidRegisterException(string.Join(" ", result.Errors.Select(e => e.Description)));
        }
        await _userManager.AddToRoleAsync(appUser, IdentityRoles.User.ToString());

        List<Claim> Claims = await ClaimsCreateAsync(appUser);

        await _userManager.AddClaimsAsync(appUser, Claims);

        var accessToken = _tokenHelper.CreateToken(Claims);

        return accessToken;

    }
    public async Task<AccessToken> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
            throw new LoginException();
        var result = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!result)
        {
            throw new LoginException();
        }
        var claims = (await _userManager.GetClaimsAsync(user)).ToList();
        var accessToken = _tokenHelper.CreateToken(claims);
        return accessToken;
    }

    private async Task<List<Claim>> ClaimsCreateAsync(AppUser user)
    {
        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        var claims = new List<Claim>() {

            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Role, role?.ToString() ?? "")

        };


        return claims;
    }


    public async Task CreateRolesAsync()
    {
        foreach (var role in Enum.GetNames(typeof(IdentityRoles)))
        {
            await _roleManager.CreateAsync(new() { Name = role.ToString() });
        }
    }


}
