using System.ComponentModel.DataAnnotations;
using Backend.Domain.User.contracts;

namespace Backend.Api.Controllers.User.Requests;

public class UserRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

    public UserRequest(
        string name,
        string surname,
        string email,
        string password
    )
    {
        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
    }

    public UserEntity ToUserEntity()
    {
        return new UserEntity(
            Guid.NewGuid(),
            Name,
            Surname,
            Email,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

    public Credential ToCredential()
    {
        return new Credential(
            Email,
            Password
        );
    }
}
