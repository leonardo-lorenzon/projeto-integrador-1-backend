namespace Backend.Api;

public static class Dotenv
{
    public static void Load()
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        var projectRoot = currentDirectory[..^16];

        var filePath = Path.Combine(projectRoot, ".env");

        if (!File.Exists(filePath))
        {
            return;
        }

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split("=", 2, StringSplitOptions.RemoveEmptyEntries);

            System.Environment.SetEnvironmentVariable(
                parts[0],
                parts[1].Trim('"')
                );
        }
    }
}
