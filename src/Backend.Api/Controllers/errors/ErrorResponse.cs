namespace Backend.Api.Controllers.errors;

public class ErrorResponse
{
    public string Code { get; }
    public string Message { get; }

    public ErrorResponse(string code, string message)
    {
        Code = code;
        Message = message;
    }
}
