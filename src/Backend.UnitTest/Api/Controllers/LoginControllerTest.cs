using System.Security.Authentication;
using Backend.Api.Controllers.Authentication;
using Backend.Api.Controllers.Authentication.Requests;
using Backend.Api.Controllers.Authentication.Responses;
using Backend.Api.Controllers.errors;
using Backend.Domain.Authentication.Contracts;
using Backend.Domain.Authentication.services;
using Backend.Domain.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Backend.UnitTest.Api.Controllers;

public class LoginControllerTest
{
    private readonly ILogger<LoginController> _logger;
    private readonly IAuthenticationService _service;
    private readonly LoginController _controller;

    public LoginControllerTest()
    {
        _logger = Substitute.For<ILogger<LoginController>>();
        _service = Substitute.For<IAuthenticationService>();

        _controller = new LoginController(_logger, _service);
    }

    [Fact]
    public async Task ShouldReturnLoginResponseWhenAuthenticateSuccessfully()
    {
        // Arrange
        var loginRequest = new LoginRequest("test@test.com", "1234");
        var token = TokenEntity.Build(Guid.NewGuid(), 1, 2, "some_key");

        _service.Login(Arg.Any<LoginCredential>()).Returns(token);

        // Act
        var response = await _controller.Login(loginRequest);

        // Assert
        var result = response as OkObjectResult;
        var value = result?.Value as LoginResponse;

        Assert.Equal(200, result?.StatusCode);
        Assert.Equal(token.Token, value?.Token);
        Assert.Equal(token.RefreshToken, value?.RefreshToken);
    }

    [Fact]
    public async Task ShouldReturn422IfCredentialIsInvalid()
    {
        // Arrange
        var loginRequest = new LoginRequest("test@test.com", "1234");

        _service.
            When(x => x.Login(Arg.Any<LoginCredential>()))
            .Do(x => throw new InvalidCredentialException());

        // Act
        var apiResponse = await _controller.Login(loginRequest);

        // Assert
        var result = apiResponse as UnprocessableEntityObjectResult;
        var errorResponse = result?.Value as ErrorResponse;
        Assert.Equal(422, result?.StatusCode);

        Assert.Equal("INVALID_CREDENTIAL", errorResponse?.Code);
    }

    [Fact]
    public async Task ShouldReturn422IfFailToCreateToken()
    {
        // Arrange
        var loginRequest = new LoginRequest("test@test.com", "1234");

        _service.
            When(x => x.Login(Arg.Any<LoginCredential>()))
            .Do(x => throw new FailToCreateTokenException());

        // Act
        var apiResponse = await _controller.Login(loginRequest);

        // Assert
        var result = apiResponse as UnprocessableEntityObjectResult;
        var errorResponse = result?.Value as ErrorResponse;
        Assert.Equal(422, result?.StatusCode);

        Assert.Equal("FAIL_TO_CREATE_TOKEN", errorResponse?.Code);
    }
}
