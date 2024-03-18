namespace Backend.Domain.User.errors;

public class UserEmailAlreadyExistsException : Exception
{
    public UserEmailAlreadyExistsException()
    {
    }

    public UserEmailAlreadyExistsException(string message) : base(message)
    {
    }

    public UserEmailAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
