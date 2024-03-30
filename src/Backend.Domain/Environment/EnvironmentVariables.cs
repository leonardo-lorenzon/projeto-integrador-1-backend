using System.Globalization;

namespace Backend.Domain.Environment;

public class EnvironmentVariables
{
    public int TokenExpirationHours { get; }
    public int RefreshTokenExpirationDays { get; }
    public string TokenSecretKey { get; }

    public EnvironmentVariables()
    {
        TokenExpirationHours = GetIntOrThrow("TOKEN_EXPIRATION_HOURS");
        RefreshTokenExpirationDays = GetIntOrThrow("REFRESH_TOKEN_EXPIRATION_DAYS");
        TokenSecretKey = GetStringOrThrow("TOKEN_SECRET_KEY");
    }

    public EnvironmentVariables(
        int tokenExpirationHours,
        int refreshTokenExpirationDays,
        string tokenSecret
        )
    {
        TokenExpirationHours = tokenExpirationHours;
        RefreshTokenExpirationDays = refreshTokenExpirationDays;
        TokenSecretKey = tokenSecret;
    }

    private static string GetStringOrThrow(string variableName)
    {
        var value = System.Environment.GetEnvironmentVariable(variableName);

        return value is null
            ? throw new ArgumentNullException(variableName, "Not defined")
            : value;
    }

    private static int GetIntOrThrow(string variableName)
    {
        var value = System.Environment.GetEnvironmentVariable(variableName);

        return value is null
            ? throw new ArgumentNullException(variableName, "Not defined")
            : int.Parse(value, NumberStyles.Integer, new NumberFormatInfo());
    }
}
