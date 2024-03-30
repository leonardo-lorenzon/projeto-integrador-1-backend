namespace Backend.Api.Controllers.Authentication.Responses;

public class LoginResponse
{
    public string Token { get; set; }

    public string RefreshToken { get; set; }

    public LoginResponse(string token, string refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }
}
