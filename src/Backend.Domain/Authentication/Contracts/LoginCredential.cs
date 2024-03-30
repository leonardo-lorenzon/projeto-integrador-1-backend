using BCrypt.Net;
using BC = BCrypt.Net.BCrypt;

namespace Backend.Domain.Authentication.Contracts;

// WARNING: Changes on this class can break login for all users
public class LoginCredential
{
    private const int WorkFactor = 11;

    public string Email { get; protected set; }
    private string Password { get; }


    public LoginCredential(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string HashedPassword()
    {
        return BC.EnhancedHashPassword(Password, WorkFactor);
    }

    public bool VerifyPasswordAgainstHash(string hashStored)
    {
        try
        {
            return BC.EnhancedVerify(Password, hashStored);
        }
        catch (SaltParseException)
        {
            return false;
        }
    }
}
