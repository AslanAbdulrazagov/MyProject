using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Encrypting
{
    public static class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securitykey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
        }
    }
}
