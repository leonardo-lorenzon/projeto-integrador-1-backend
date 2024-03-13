using Backend.Domain.User.contracts;
using Backend.Domain.User.Repositories;

namespace Backend.UnitTest.doubles.fakers;

public class InMemoryUserRepository : IUserRepository
{
    private readonly Dictionary<string, UserEntity> _users = new Dictionary<string, UserEntity>();

    public async Task CreateUserWithCredential(UserEntity user, Credential credential)
    {
        _users.Add(user.Email, user);

        await Task.CompletedTask;
    }

    public Task<UserEntity?> FindByEmail(string email)
    {
        _users.TryGetValue(email, out var user);
        return Task.FromResult(user);
    }
}
