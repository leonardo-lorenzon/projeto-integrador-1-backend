using Backend.Domain.User.Services;
using Backend.UnitTest.doubles.fakers;

namespace Backend.UnitTest.factories;

public class UserRegisterServiceFactory
{
    public InMemoryUserRepository UserRepository { get; }

    public UserRegisterServiceFactory()
    {
        UserRepository = new InMemoryUserRepository();
    }

    public UserRegisterService Build()
    {
        return new UserRegisterService(UserRepository);
    }
}
