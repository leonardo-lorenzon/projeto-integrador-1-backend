namespace Backend.Domain.Errors;

public class FailToCreateTokenException : Exception
{
    public FailToCreateTokenException()
    {
    }

    public FailToCreateTokenException(string message) : base(message)
    {
    }

    public FailToCreateTokenException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
