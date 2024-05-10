using Backend.Api.Controllers.errors;
using Backend.Api.Controllers.Taker.Responses;
using Backend.Domain.Errors;
using Backend.Domain.Provider.Contracts;
using Backend.Domain.Provider.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers.Provider;

[ApiController]
[Route("taker/")]
public class TakerServiceController : ControllerBase
{
    private readonly IProviderService _providerService;

    public TakerServiceController(IProviderService providerService)
    {
        _providerService = providerService;
    }

    [HttpGet]
    [Route("service/{serviceType}")]
    [ProducesResponseType<List<ServiceResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> SearchServices(string serviceType)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var searchService = new SearchService(serviceType);

        try
        {
            var services = await _providerService.ListServices(searchService);

            var servicesResponse = services.Select(item => new ServiceResponse(
                    item.Id,
                    item.AccountId,
                    item.Type,
                    item.Description,
                    item.City,
                    item.State,
                    item.Country
                )
            );

            return Ok(servicesResponse);
        }
        catch (FailToAddServiceException)
        {
            return UnprocessableEntity(new ErrorResponse(
                ApplicationErrors.FailToAddService,
                "Something went wrong when trying to add a service")
            );
        }
    }
}
