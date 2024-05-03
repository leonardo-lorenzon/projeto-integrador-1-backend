using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Errors;
using Backend.Domain.User.contracts;
using Backend.Domain.User.Repositories;

namespace Backend.Domain.User.Services;

public class UserRegisterService : IUserRegisterService
{
    private readonly IUserRepository _userRepository;

    public UserRegisterService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateUserWithCredential(UserEntity user, LoginCredential loginCredential)
    {
        var existingUser = await _userRepository.FindByEmail(user.Email);

        if (existingUser is not null)
        {
            throw new UserEmailAlreadyExistsException("User already exist");
        }

        var defaultTakerAccount = new Account(
            Guid.NewGuid(),
            user.UserId,
            AccountType.Taker,
            user.CreatedAt,
            user.UpdatedAt
        );

        await _userRepository.CreateUserWithCredential(user, loginCredential, defaultTakerAccount);
    }
}
