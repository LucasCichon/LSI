using Serilog;

namespace ExportHistoryViewer.Configuration
{
    public static class AppConfiguration
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt",
                                rollingInterval: RollingInterval.Day,
                                retainedFileCountLimit: 7,
                                fileSizeLimitBytes: 10485760,
                              rollOnFileSizeLimit: true
                    ).CreateLogger();
        }
    }
}
