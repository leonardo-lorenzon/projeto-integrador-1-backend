using Backend.Domain.User.errors;
using Backend.UnitTest.Builders;
using Backend.UnitTest.factories;

namespace Backend.UnitTest.Domain.Services;

public class UserRegisterServiceTest
{
    [Fact]
    public async Task ShouldCreateAUserIfItDoesNotExist()
    {
        // Arrange
        const string userEmail = "testuser@projeto.com";
        var user = new UserEntityBuilder()
            .WithEmail(userEmail)
            .Build();
        var credential = new CredentialBuilder()
            .WithEmail(userEmail)
            .Build();

        var factory = new UserRegisterServiceFactory();
        var userRegisterService = factory.Build();

        // Act
        await userRegisterService.CreateUserWithCredential(user, credential);

        // Assert
        var result = factory.UserRepository.FindByEmail(userEmail);
        Assert.True(result is not null);
    }

    [Fact]
    public async Task ShouldThrowExceptionIfUserAlreadyExist()
    {
        // Arrange
        const string userEmail = "testuser@projeto.com";
        var user = new UserEntityBuilder()
            .WithEmail(userEmail)
            .Build();
        var credential = new CredentialBuilder()
            .WithEmail(userEmail)
            .Build();

        var factory = new UserRegisterServiceFactory();
        var userRegisterService = factory.Build();

        // Act
        await userRegisterService.CreateUserWithCredential(user, credential);

        // Assert
        await Assert.ThrowsAsync<UserEmailAlreadyExistsException>(
            async () => await userRegisterService.CreateUserWithCredential(user, credential)
            );
    }
}
