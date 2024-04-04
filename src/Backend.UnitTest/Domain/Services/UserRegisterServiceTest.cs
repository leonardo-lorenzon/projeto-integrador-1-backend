using Backend.Domain.Errors;
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
        var credential = new LoginCredentialBuilder()
            .WithEmail(userEmail)
            .Build();

        var factory = new UserRegisterServiceFactory();
        var userRegisterService = factory.Build();

        // Act
        await userRegisterService.CreateUserWithCredential(user, credential);

        // Assert
        var result = await factory.UserRepository.FindByEmail(userEmail);
        Assert.Equal(userEmail, result?.Email);
    }

    [Fact]
    public async Task ShouldCreateCredentialWithSaltHashedPassword()
    {
        // Arrange
        const string userEmail = "testuser@projeto.com";
        var user = new UserEntityBuilder()
            .WithEmail(userEmail)
            .Build();
        var credential = new LoginCredentialBuilder()
            .WithEmail(userEmail)
            .Build();

        var factory = new UserRegisterServiceFactory();
        var userRegisterService = factory.Build();

        // Act
        await userRegisterService.CreateUserWithCredential(user, credential);

        // Assert
        var hashedPassword = await factory.UserRepository.GetHashedPasswordByEmail(userEmail);

        Assert.NotNull(hashedPassword);

        // Successive calls to HashedPassword generate different hash because of automatic salt generation handled by BCrypt
        Assert.NotEqual(credential.HashedPassword(), hashedPassword);

        // But any given hash returned by the HashedPassword can be used to verify the password.
        Assert.True(credential.VerifyPasswordAgainstHash("$2a$11$hGiJzoSSX.zbFOVLdRLyKu5T/opweug8rh1e/0M93zJjYw76uweAa"));
    }

    [Fact]
    public async Task ShouldThrowExceptionIfUserAlreadyExist()
    {
        // Arrange
        const string userEmail = "testuser@projeto.com";
        var user = new UserEntityBuilder()
            .WithEmail(userEmail)
            .Build();
        var credential = new LoginCredentialBuilder()
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
