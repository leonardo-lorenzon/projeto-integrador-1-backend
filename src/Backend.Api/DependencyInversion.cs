using Backend.Domain.Authentication.Repositories;
using Backend.Domain.Authentication.services;
using Backend.Domain.Environment;
using Backend.Domain.Provider.Repositories;
using Backend.Domain.Provider.Services;
using Backend.Domain.User.Repositories;
using Backend.Domain.User.Services;
using Backend.Infrastructure.Authentication.Repositories;
using Backend.Infrastructure.DatabaseContext;
using Backend.Infrastructure.Provider.Repositories;
using Backend.Infrastructure.User.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api;

public class DependencyInversion
{
    private readonly IServiceCollection _serviceCollection;

    public DependencyInversion(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public void AddServices()
    {
        _serviceCollection.AddScoped<IUserRegisterService, UserRegisterService>();
        _serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
        _serviceCollection.AddScoped<IProviderService, ProviderService>();
    }

    public void AddRepositories()
    {
        _serviceCollection.AddScoped<IUserRepository, PostgresUserRepository>();
        _serviceCollection.AddScoped<ICredentialRepository, PostgresCredentialRepository>();
        _serviceCollection.AddScoped<IAuthenticationRepository, PostgresAuthenticationRepository>();
        _serviceCollection.AddScoped<IProviderServiceRepository, PostgresProviderServiceRepository>();
    }

    public void AddPostgreSqlContext()
    {
        _serviceCollection.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING"))
        );
    }

    public void SetEnvironmentVariables()
    {
        _serviceCollection.AddSingleton(new EnvironmentVariables());
    }
}
