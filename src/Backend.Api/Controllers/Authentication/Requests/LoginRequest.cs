using System.ComponentModel.DataAnnotations;
using Backend.Domain.Authentication.Contracts;

namespace Backend.Api.Controllers.Authentication.Requests;

public class LoginRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

    public LoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public LoginCredential ToCredential()
    {
        return new LoginCredential(
            Email,
            Password
        );
    }
}
