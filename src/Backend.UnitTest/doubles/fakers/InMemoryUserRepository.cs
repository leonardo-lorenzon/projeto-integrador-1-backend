using Backend.Domain.User.contracts;
using Backend.Domain.User.Repositories;

namespace Backend.UnitTest.doubles.fakers;

public class InMemoryUserRepository : IUserRepository
{
    private readonly Dictionary<string, UserEntity> _users = new Dictionary<string, UserEntity>();
    private readonly Dictionary<string, string> _credentials = new Dictionary<string, string>();

    public async Task CreateUserWithCredential(UserEntity user, Credential credential)
    {
        _credentials.Add(credential.Email, credential.HashedPassword());
        _users.Add(user.Email, user);

        await Task.CompletedTask;
    }

    public Task<UserEntity?> FindByEmail(string email)
    {
        _users.TryGetValue(email, out var user);
        return Task.FromResult(user);
    }

    // only for tests
    public Task<string?> GetHashedPasswordByEmail(string email)
    {
        _credentials.TryGetValue(email, out var password);

        return Task.FromResult(password);
    }
}
