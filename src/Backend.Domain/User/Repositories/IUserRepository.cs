using Backend.Domain.Authentication.Contracts;
using Backend.Domain.User.contracts;

namespace Backend.Domain.User.Repositories;

public interface IUserRepository
{
    public Task<UserEntity?> FindByEmail(string email);

    public Task CreateUserWithCredential(UserEntity user, LoginCredential loginCredential);
}
