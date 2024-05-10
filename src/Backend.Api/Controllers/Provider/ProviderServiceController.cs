using Backend.Api.Controllers.errors;
using Backend.Api.Controllers.Provider.Requests;
using Backend.Domain.Errors;
using Backend.Domain.Provider.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers.Provider;

[ApiController]
[Route("provider/")]
public class ProviderServiceController : ControllerBase
{
    private readonly IProviderService _providerService;

    public ProviderServiceController(IProviderService providerService)
    {
        _providerService = providerService;
    }

    [HttpPost]
    [Route("service/{accountId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddService(string accountId, [FromBody] ServiceRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
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
