namespace Backend.Domain.Authentication.Contracts;

public class AuthCredential
{
    public Guid UserId { get; }
    public string HashedPassword { get; }

    public AuthCredential(Guid userId, string hashedPassword)
    {
        UserId = userId;
        HashedPassword = hashedPassword;
    }
}
