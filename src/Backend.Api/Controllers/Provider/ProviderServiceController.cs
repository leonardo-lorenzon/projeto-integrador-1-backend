using Backend.Api.Controllers.errors;
using Backend.Api.Controllers.Provider.Requests;
using Backend.Domain.Authentication.services;
using Backend.Domain.Errors;
using Backend.Domain.Provider.Servides;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers.Provider;

[ApiController]
[Route("provider/")]
public class ProviderServiceController : ControllerBase
{
    private readonly IProviderService _providerService;
    private readonly IAuthenticationService _authenticationService;

    public ProviderServiceController(IProviderService providerService, IAuthenticationService authenticationService)
    {
        _providerService = providerService;
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [Route("service/{accountId}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddService(
        string accountId,
        [FromBody] ServiceRequest request,
        [FromHeader(Name = "Authorization")] string authorization
        )
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isAuthenticated = await _authenticationService.IsAuthenticated(authorization);
        if (!isAuthenticated)
        {
            return Unauthorized(new ErrorResponse(
                ApplicationErrors.NotAuthenticated,
                "User is not authenticated")
            );
        }

        try
        {
            await _providerService.AddService(request.ToDomain(accountId));
        }
        catch (FailToAddServiceException)
        {
            return UnprocessableEntity(new ErrorResponse(
                ApplicationErrors.FailToAddService,
                "Something went wrong when trying to add a service")
            );
        }

        return Ok();
    }
}
