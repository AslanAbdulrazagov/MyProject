using Microsoft.IdentityModel.Tokens;

namespace Business.Security.Encrypting
{
    public static class SigninCredentialsHelper
    {
        public static SigningCredentials CreateSigninCredentials(SecurityKey securityKey)
        {
            return new(securityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
