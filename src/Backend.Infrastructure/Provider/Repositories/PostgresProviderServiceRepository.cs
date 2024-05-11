using Backend.Domain.Errors;
using Backend.Domain.Provider.Contracts;
using Backend.Domain.Provider.Repositories;
using Backend.Infrastructure.DatabaseContext;
using Backend.Infrastructure.DatabaseContext.Models;
using Microsoft.EntityFrameworkCore;
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

    public async Task AddService(ServiceEntity serviceEntity)
    {
        var serviceModel = new ServiceModel(
            serviceEntity.Id,
            serviceEntity.AccountId,
            serviceEntity.Type,
            serviceEntity.Description,
            serviceEntity.City,
            serviceEntity.State,
            serviceEntity.Country,
            serviceEntity.CreatedAt,
            serviceEntity.UpdatedAt
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

    public Task<IEnumerable<ServiceEntity>> ListServices(SearchService searchService)
    {
        var serviceModel = _dbContext.Services
            .FromSql($"SELECT * FROM \"Services\"")
            .Where(model => model.Type == searchService.Type)
            .ToArray();

        var services = serviceModel.Select(model => new ServiceEntity(
                model.Id,
                model.AccountId,
                model.Type,
                model.Description,
                model.City,
                model.State,
                model.Country,
                model.CreatedAt,
                model.UpdatedAt
            )
        );

        return Task.FromResult(services);
    }
}
