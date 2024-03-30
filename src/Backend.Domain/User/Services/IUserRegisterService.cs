using Backend.Domain.Authentication.Contracts;
using Backend.Domain.User.contracts;

namespace Backend.Domain.User.Services;

public interface IUserRegisterService
{
    public Task CreateUserWithCredential(UserEntity user, LoginCredential loginCredential);
}
