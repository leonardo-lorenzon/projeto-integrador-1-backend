using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Authentication.Repositories;
using Backend.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Authentication.Repositories;

public class PostgresCredentialRepository : ICredentialRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PostgresCredentialRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AuthCredential?> GetAuthCredentialByEmail(string email)
    {
        var userModel = await _dbContext.Users.FirstOrDefaultAsync(model => model.Email == email);

        if (userModel is null)
        {
            return null;
        }

        var credentialModel = await _dbContext.Credentials.FirstOrDefaultAsync(model => model.UserId == userModel.UserId);

        if (credentialModel is null)
        {
            return null;
        }

        var authCredential = new AuthCredential(
            credentialModel.UserId,
            credentialModel.HashedPassword
        );

        return authCredential;
    }
}
