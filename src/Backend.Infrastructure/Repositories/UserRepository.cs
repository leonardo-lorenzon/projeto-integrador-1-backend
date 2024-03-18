using Backend.Domain.User.contracts;
using Backend.Domain.User.Repositories;
using Backend.Infrastructure.DatabaseContext;
using Backend.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(
        ApplicationDbContext dbContext
        )
    {
        _dbContext = dbContext;
    }

    public async Task CreateUserWithCredential(UserEntity user, Credential credential)
    {
        var userModel = new UserModel(
                user.UserId,
                user.Name,
                user.Surname,
                user.Email,
                user.CreatedAt,
                user.UpdatedAt
            );

        await _dbContext.Users.AddAsync(userModel);

        await _dbContext.SaveChangesAsync();
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
