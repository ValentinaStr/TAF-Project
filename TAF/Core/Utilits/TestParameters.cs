using Core.BrowserImplementation;
using Newtonsoft.Json;
using NLog;

public class TestRunSettings
{
    private static readonly Lazy<TestRunSettings> lazyInstance = new Lazy<TestRunSettings>(LoadSettings);
    public required string Url { get; set; }
    public BrowserType Browser { get; set; }
    public int WebDriverTimeOut { get; set; }
    public required LogLevel MinimumLogLevel { get; set; }
    public bool Headless { get; set; }

    public static TestRunSettings Instance => lazyInstance.Value;

    private static TestRunSettings LoadSettings()
    {
        var projectRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..");
        var jsonFilePath = Path.Combine(projectRoot, "Core", "test.runsettings.json");

        if (!File.Exists(jsonFilePath))
        {
            throw new FileNotFoundException($"The file {jsonFilePath} does not exist.");
        }

        string jsonContent = File.ReadAllText(jsonFilePath);
        return JsonConvert.DeserializeObject<TestRunSettings>(jsonContent);
    }
}
