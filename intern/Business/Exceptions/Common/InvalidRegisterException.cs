using Business.Abstactions.Exceptions;

public class InvalidRegisterException : Exception, IBaseException
{
    public InvalidRegisterException(string message = "register failed ") : base(message)
    {

    }
}
