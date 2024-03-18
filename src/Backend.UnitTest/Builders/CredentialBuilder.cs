using Backend.Domain.User.contracts;
using Backend.UnitTest.TestSubclasses;

namespace Backend.UnitTest.Builders;

public class CredentialBuilder
{
    private readonly CredentialTestSubclass _credential;

    public CredentialBuilder()
    {
        _credential = BuildDefault();
    }

    public Credential Build()
    {
        return _credential;
    }

    public CredentialBuilder WithEmail(string email)
    {
        _credential.UpdateEmail(email);

        return this;
    }

    private static CredentialTestSubclass BuildDefault()
    {
        return new CredentialTestSubclass("name@test.com", "pass123");
    }
}
