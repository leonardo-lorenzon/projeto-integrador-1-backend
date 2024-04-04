using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Authentication.Repositories;

namespace Backend.UnitTest.doubles.fakers;

public class InMemoryCredentialRepository : ICredentialRepository
{
    private readonly Dictionary<string, AuthCredential> _credentials = new Dictionary<string, AuthCredential>();

    public Task<AuthCredential?> GetAuthCredentialByEmail(string email)
    {
        _credentials.TryGetValue(email, out var credential);

        return Task.FromResult(credential);
    }

    // only for test purposes
    public void SetAuthCredential(string email, AuthCredential authCredential)
    {
        _credentials.Add(email, authCredential);
    }
}
