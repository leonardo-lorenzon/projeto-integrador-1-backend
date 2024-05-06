namespace Backend.Domain.Errors;

public class FailToAddServiceException : Exception
{
    public FailToAddServiceException()
    {
    }

    public FailToAddServiceException(string message) : base(message)
    {
    }

    public FailToAddServiceException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
