namespace Backend.Domain.User.contracts;

public class Credential
{
    public string Email { get; protected set; }
    public string Password { get; }


    public Credential(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
