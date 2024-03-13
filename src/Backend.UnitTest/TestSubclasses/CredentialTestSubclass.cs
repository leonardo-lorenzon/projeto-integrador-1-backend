using Backend.Domain.User.contracts;

namespace Backend.UnitTest.TestSubclasses;

public class CredentialTestSubclass : Credential
{
    public CredentialTestSubclass(string email, string password) : base(email, password)
    {
    }

    public void UpdateEmail(string email)
    {
        Email = email;
    }
}
