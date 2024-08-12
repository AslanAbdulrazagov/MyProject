using Business.Abstactions.Exceptions;

namespace Business.Exceptions;

public class AlreadyExistException:Exception,IBaseException
{
    public AlreadyExistException(string message="Already exist"):base(message)
    {
        
    }
}
