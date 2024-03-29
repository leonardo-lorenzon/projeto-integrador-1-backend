namespace Backend.Domain.User.errors;

public class FailToCreateUserWithCredentialException : Exception
{
    public FailToCreateUserWithCredentialException()
    {
    }

    public FailToCreateUserWithCredentialException(string message) : base(message)
    {
    }

    public FailToCreateUserWithCredentialException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
