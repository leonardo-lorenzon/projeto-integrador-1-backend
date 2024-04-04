using Backend.Domain.Authentication.Contracts;
using Backend.UnitTest.TestSubclasses;

namespace Backend.UnitTest.Builders;

public class LoginCredentialBuilder
{
    private readonly LoginCredentialTestSubclass _loginCredential;

    public LoginCredentialBuilder()
    {
        _loginCredential = BuildDefault();
    }

    public LoginCredential Build()
    {
        return _loginCredential;
    }

    public LoginCredentialBuilder WithEmail(string email)
    {
        _loginCredential.UpdateEmail(email);

        return this;
    }

    private static LoginCredentialTestSubclass BuildDefault()
    {
        return new LoginCredentialTestSubclass("name@test.com", "pass123");
    }
}
