using Newtonsoft.Json;

namespace Core.Utilits
{
    public static class TestDataReader<T>
    {
        public static IEnumerable<T> GetTestData(string testDataFile)
        {
            var projectRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..");
            var jsonFilePath = Path.Combine(projectRoot, "Core", "TestData", testDataFile);

            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException("Test data file not found.", jsonFilePath);
            }

            var json = File.ReadAllText(jsonFilePath);
            var testData = JsonConvert.DeserializeObject<List<T>>(json);
            return testData;
        }
    }
}
