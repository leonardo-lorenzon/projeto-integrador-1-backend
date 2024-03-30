using Backend.Domain.Environment;

namespace Backend.UnitTest.Builders;

public class EnvironmentVariablesBuilder
{
    private readonly EnvironmentVariables _environmentVariables;

    public EnvironmentVariablesBuilder()
    {
        _environmentVariables = BuildDefault();
    }

    public EnvironmentVariables Build()
    {
        return _environmentVariables;
    }

    private static EnvironmentVariables BuildDefault()
    {
        return new EnvironmentVariables(
            1,
            7,
            "a_secret"
            );
    }
}
