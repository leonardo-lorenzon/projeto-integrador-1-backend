using System.Security.Authentication;
using Backend.UnitTest.Builders;
using Backend.UnitTest.factories;

namespace Backend.UnitTest.Domain.Services;

public class AuthenticationServiceTest
{
    [Fact]
    public async Task ShouldThrowInvalidCredentialIfCredentialDoesNotExist()
    {
        // Arrange
        var email = "test@test.com";
        var loginCredential = new LoginCredentialBuilder()
            .WithEmail(email)
            .Build();

        var factory = new AuthenticationServiceFactory();

        // Act
        var authenticationService = factory.Build();

        // Assert
        await Assert.ThrowsAsync<InvalidCredentialException>(
            async () => await authenticationService.Login(loginCredential)
            );
    }

    [Fact]
    public async Task ShouldThrowInvalidCredentialIfCredentialHashedPasswordIsInvalid()
    {
        // Arrange
        var userId = Guid.NewGuid();
        const string email = "test@test.com";
        const string wrongHashPassword = "wrongPassword";
        var loginCredential = new LoginCredentialBuilder()
            .WithEmail(email)
            .Build();

        var factory = new AuthenticationServiceFactory();
        factory.SetCredential(email, userId, wrongHashPassword);

        // Act
        var authenticationService = factory.Build();

        // Assert
        await Assert.ThrowsAsync<InvalidCredentialException>(
            async () => await authenticationService.Login(loginCredential)
        );
    }

    [Fact]
    public async Task ShouldReturnPersistedTokenIfPasswordIsValid()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var email = "test@test.com";
        var loginCredential = new LoginCredentialBuilder()
            .WithEmail(email)
            .Build();

        var factory = new AuthenticationServiceFactory();
        factory.SetCredential(email, userId, loginCredential.HashedPassword());

        // Act
        var authenticationService = factory.Build();
        var token = await authenticationService.Login(loginCredential);

        // Assert
        var persistedToken = factory.GetTokenByUserId(userId);

        Assert.NotNull(token);
        Assert.Equal(token.Token, persistedToken?.Token);
    }
}
