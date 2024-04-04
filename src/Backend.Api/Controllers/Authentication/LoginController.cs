using System.Security.Authentication;
using Backend.Api.Controllers.Authentication.Requests;
using Backend.Api.Controllers.Authentication.Responses;
using Backend.Api.Controllers.errors;
using Backend.Domain.Authentication.services;
using Backend.Domain.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers.Authentication;

[ApiController]
[Route("login/")]
public class LoginController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;
    private readonly IAuthenticationService _authenticationService;

    public LoginController(ILogger<LoginController> logger, IAuthenticationService authenticationService)
    {
        _logger = logger;
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [ProducesResponseType<LoginResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var loginCredential = request.ToCredential();

        using var logScope = _logger.BeginScope("Sign in for {Email}", loginCredential.Email);

        try
        {
            var token = await _authenticationService.Login(loginCredential);
            return Ok(
                new LoginResponse(token.Token, token.RefreshToken)
                );
        }
        catch (InvalidCredentialException)
        {
            return UnprocessableEntity(new ErrorResponse(
                ApplicationErrors.InvalidCredential,
                "Login or password is wrong")
            );
        }
        catch (FailToCreateTokenException)
        {
            return UnprocessableEntity(new ErrorResponse(
                ApplicationErrors.FailToCreateToken,
                "Something bad happen while creating token")
            );
        }
    }
}
