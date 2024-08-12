using Core.Entities;
using System.Security.Claims;

namespace Business.Abstactions.Helpers;

public interface ITokenHelper
{
    AccessToken CreateToken(List<Claim> claims);

}
