using Backend.Domain.Authentication.Contracts;

namespace Backend.UnitTest.TestSubclasses;

public class LoginCredentialTestSubclass : LoginCredential
{
    public LoginCredentialTestSubclass(string email, string password) : base(email, password)
    {
    }

    public void UpdateEmail(string email)
    {
        Email = email;
    }
}
