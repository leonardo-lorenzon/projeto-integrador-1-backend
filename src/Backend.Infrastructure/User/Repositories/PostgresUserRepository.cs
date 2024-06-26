using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Errors;
using Backend.Domain.User.contracts;
using Backend.Domain.User.Repositories;
using Backend.Infrastructure.DatabaseContext;
using Backend.Infrastructure.DatabaseContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.User.Repositories;

public class PostgresUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<PostgresUserRepository> _logger;

    public PostgresUserRepository(
        ApplicationDbContext dbContext,
        ILogger<PostgresUserRepository> logger
        )
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task CreateUserWithCredential(UserEntity user, LoginCredential loginCredential, Account account)
    {
        var userModel = new UserModel(
                user.UserId,
                user.Name,
                user.Surname,
                user.Email,
                user.CreatedAt,
                user.UpdatedAt
            );

        var accountModel = new AccountModel(
            account.AccountId,
            account.UserId,
            account.Type.ToString(),
            account.CreatedAt,
            account.UpdatedAt
            );

        var credentialModel = new CredentialModel(
            user.UserId,
            loginCredential.HashedPassword(),
            DateTime.UtcNow,
            DateTime.UtcNow
            );

        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await _dbContext.Users.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();

            await _dbContext.Accounts.AddAsync(accountModel);
            await _dbContext.SaveChangesAsync();

            await _dbContext.Credentials.AddAsync(credentialModel);
            await _dbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError(
                "PostgreSQL error while creating user with credential: {Message}",
                exception.ToString()
                );

            throw new FailToCreateUserWithCredentialException();
        }
    }

    public async Task<UserEntity?> FindByEmail(string email)
    {
        var userModel = await _dbContext.Users.FirstOrDefaultAsync(model => model.Email == email);

        if (userModel is null)
        {
            return null;
        }

        return new UserEntity(
            userModel.UserId,
            userModel.Name,
            userModel.Surname,
            userModel.Email,
            userModel.CreatedAt,
            userModel.UpdatedAt
        );
    }
}
