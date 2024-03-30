using Backend.Domain.Authentication.Contracts;

namespace Backend.Domain.Authentication.Repositories;

public interface ICredentialRepository
{
    public Task<AuthCredential?> GetAuthCredentialByEmail(string email);
}
