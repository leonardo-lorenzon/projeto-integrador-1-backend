using Backend.Domain.User.contracts;
using Backend.Domain.User.errors;
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

        await _userRepository.CreateUserWithCredential(user, loginCredential);
    }
}
