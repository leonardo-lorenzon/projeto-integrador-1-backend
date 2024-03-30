using Backend.Api.Controllers.errors;
using Backend.Api.Controllers.User.Requests;
using Backend.Domain.User.errors;
using Backend.Domain.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers.User;

[ApiController]
[Route("user/")]
public class RegisterUserController : ControllerBase
{
    private readonly ILogger<RegisterUserController> _logger;
    private readonly IUserRegisterService _userRegisterService;

    public RegisterUserController(
        ILogger<RegisterUserController> logger,
        IUserRegisterService userRegisterService
    )
    {
        _logger = logger;
        _userRegisterService = userRegisterService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> CreateUserWithCredentials([FromBody] UserRequest userRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userEntity = userRequest.ToUserEntity();
        using var logScope = _logger.BeginScope("Creating user with userId {UserId}", userEntity.UserId);

        try
        {
            await _userRegisterService.CreateUserWithCredential(userEntity, userRequest.ToCredential());
        }
        catch (UserEmailAlreadyExistsException)
        {
            return UnprocessableEntity(new ErrorResponse(ApplicationErrors.UserEmailAlreadyExists,
                "User with given email already exists"));
        }
        catch (FailToCreateUserWithCredentialException)
        {
            return UnprocessableEntity(new ErrorResponse(ApplicationErrors.FailToCreateUserWithCredential,
                "Something went wrong when trying to create a user with credential"));
        }

        return Ok();
    }
}
