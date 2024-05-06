using Backend.Domain.Errors;
using Backend.Domain.Provider.Contracts;
using Backend.Domain.Provider.Repositories;
using Backend.Infrastructure.DatabaseContext;
using Backend.Infrastructure.DatabaseContext.Models;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Provider.Repositories;

public class PostgresProviderServiceRepository : IProviderServiceRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<PostgresProviderServiceRepository> _logger;

    public PostgresProviderServiceRepository(
        ApplicationDbContext dbContext,
        ILogger<PostgresProviderServiceRepository> logger
        )
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task AddService(Service service)
    {
        var serviceModel = new ServiceModel(
            service.Id,
            service.AccountId,
            service.Type,
            service.Description,
            service.City,
            service.State,
            service.Country,
            service.CreatedAt,
            service.UpdatedAt
            );

        try
        {
            await _dbContext.Services.AddAsync(serviceModel);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError(
                "PostgreSQL error while adding service: {Message}",
                exception.ToString()
            );

            throw new FailToAddServiceException();
        }
    }
}
