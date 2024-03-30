using Backend.Api;

const string developmentCorsPolicy = "developmentCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

Dotenv.Load();

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddCors(options =>
    {
        options.AddPolicy(
            name: developmentCorsPolicy,
            policyBuilder => policyBuilder
                .AllowAnyHeader()
                .AllowAnyOrigin()
        );
    }
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
var dependencyInversion = new DependencyInversion(builder.Services);
dependencyInversion.SetEnvironmentVariables();
dependencyInversion.AddServices();
dependencyInversion.AddRepositories();
dependencyInversion.AddPostgreSqlContext();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// UseCors must be called in the correct order. See https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0#enable-cors
if (app.Environment.IsDevelopment())
{
    app.UseCors(developmentCorsPolicy);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
