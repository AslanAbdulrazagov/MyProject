using Business.Abstactions.Exceptions;

namespace Business.Exceptions;

public class NotFoundException : Exception, IBaseException
{
    public   NotFoundException(string message = "Not found ") : base(message)
    {

    }
}