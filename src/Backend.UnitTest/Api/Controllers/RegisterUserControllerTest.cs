using Backend.Api.Controllers.errors;
using Backend.Api.Controllers.User;
using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Errors;
using Backend.Domain.User.contracts;
using Backend.Domain.User.Services;
using Backend.UnitTest.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Backend.UnitTest.Api.Controllers;

public class RegisterUserControllerTest
{
    private readonly ILogger<RegisterUserController> _logger;
    private readonly IUserRegisterService _userRegisterService;
    private readonly RegisterUserController _controller;

    public RegisterUserControllerTest()
    {
        _logger = Substitute.For<ILogger<RegisterUserController>>();
        _userRegisterService = Substitute.For<IUserRegisterService>();
        _controller = new RegisterUserController(_logger, _userRegisterService);
    }

    [Fact]
    public async Task ShouldReturn200StatusCodeWhenSuccessful()
    {
        // Arrange
        var userRequest = new UserRequestBuilder().Build();

        // Act
        var response = await _controller.CreateUserWithCredentials(userRequest);

        // Assert
        var result = response as OkResult;
        Assert.Equal(200, result?.StatusCode);
    }

    [Fact]
    public async Task ShouldReturn422StatusCodeWhenUserEmailAlreadyExists()
    {
        // Arrange
        _userRegisterService
            .When(x => x.CreateUserWithCredential(Arg.Any<UserEntity>(), Arg.Any<LoginCredential>()))
            .Do(x => throw new UserEmailAlreadyExistsException());

        var userRequest = new UserRequestBuilder().Build();

        // Act
        var apiResponse = await _controller.CreateUserWithCredentials(userRequest);

        // Assert
        var result = apiResponse as UnprocessableEntityObjectResult;
        var errorResponse = result?.Value as ErrorResponse;
        Assert.Equal(422, result?.StatusCode);

        Assert.Equal("USER_EMAIL_EXISTS", errorResponse?.Code);
    }
}
