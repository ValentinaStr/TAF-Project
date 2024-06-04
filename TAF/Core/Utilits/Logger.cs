using NLog;
using NLog.Config;
using NLog.Targets;

namespace Core.Utilits
{
    public static class Logger
    {
        private static readonly ILogger logger;

        static Logger()
        {
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget("file")
            {
                FileName = "log.txt",
                Layout = "${longdate} ${level} ${message} ${exception:format=tostring}"
            };

            config.AddTarget(fileTarget);

            var consoleTarget = new ColoredConsoleTarget("console")
            {
                Layout = "${longdate} ${level} ${message} ${exception:format=tostring}"
            };

            config.AddTarget(consoleTarget);
            LogLevel minimumLogLevel = TestRunSettings.Instance.MinimumLogLevel;
            config.AddRule(minimumLogLevel, LogLevel.Fatal, fileTarget);
            config.AddRule(minimumLogLevel, LogLevel.Fatal, consoleTarget);
            LogManager.Configuration = config;
            logger = LogManager.GetCurrentClassLogger();
        }

        public static void LogInfo(string message)
        {
            logger.Info(message);
        }

        public static void LogWarning(string message)
        {
            logger.Warn(message);
        }

        public static void LogError(Exception error, string message)
        {
            logger.Error(error, message);
        }

        public static void LogException(string message, Exception exception)
        {
            logger.Error(exception, message);
        }
    }
}