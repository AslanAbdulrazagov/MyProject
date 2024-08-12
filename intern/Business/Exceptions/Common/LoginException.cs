using Business.Abstactions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions.Common
{
    public class LoginException : Exception, IBaseException
    {
        public LoginException(string message = "Email or password is wrong!") : base(message)
        {

        }
    }
}
