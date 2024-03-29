using BC = BCrypt.Net.BCrypt;

namespace Backend.Domain.User.contracts;

// WARNING: Changes on this class can break login for all users
public class Credential
{
    private const int WorkFactor = 11;

    public string Email { get; protected set; }
    private string Password { get; }


    public Credential(string email, string password)
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
        return BC.EnhancedVerify(Password, hashStored);
    }
}
