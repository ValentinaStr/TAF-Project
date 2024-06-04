namespace Core.Utilits
{
    public static class FileAndDirectoryHelper
    {
        public static bool CheckFileExistence(string defaultDownloadDirectory, string fileName)
        {
            string filePath = Path.Combine(defaultDownloadDirectory, fileName);

            if (File.Exists(filePath))
            {
                Logger.LogInfo($"File '{fileName}' exists at path: '{filePath}'.");
                return true;
            }
            else
            {
                Logger.LogInfo($"File '{fileName}' does not exist at path: '{filePath}'.");
                return false;
            }
        }

        public static void ClearDefaultDownloadDirectory(string defaultDownloadDirectory)
        {
            if (!Directory.Exists(defaultDownloadDirectory))
            {
                Logger.LogInfo("Default Download Directory does not exist. No need to clear.");
                return;
            }

            try
            {
                Directory.Delete(defaultDownloadDirectory, true);
                Logger.LogInfo("Default Download Directory is clean");
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.LogError(ex, $"Unauthorized access to Default Download Directory '{defaultDownloadDirectory}'.");
            }
            catch (IOException ex)
            {
                Logger.LogError(ex, $"An error occurred while deleting Default Download Directory '{defaultDownloadDirectory}'.");
            }
        }
    }
}