using Backend.Domain.User.contracts;
using Backend.UnitTest.TestSubclasses;

namespace Backend.UnitTest.Builders;

public class UserEntityBuilder
{
    private readonly UserEntityTestSubclass _user;

    public UserEntityBuilder()
    {
        _user = BuildDefault();
    }

    public UserEntity Build()
    {
        return _user;
    }

    public UserEntityBuilder WithEmail(string email)
    {
        _user.UpdateEmail(email);

        return this;
    }

    private static UserEntityTestSubclass BuildDefault()
    {
        return new UserEntityTestSubclass(
                Guid.NewGuid(),
            "José",
            "Carlos",
            "jcarlos@test.com",
                DateTime.UtcNow,
                DateTime.UtcNow
        );
    }
}
