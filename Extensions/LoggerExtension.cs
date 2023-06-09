using Serilog;
using Serilog.Events;

namespace StudentsCoursesManager.Extensions
{
    public  static class LoggerExtension
    {
        public static Serilog.ILogger ConfigureLogger(this LoggerConfiguration loggerConfiguration)
        {
            return loggerConfiguration
                   .MinimumLevel.Information()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                   .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                   .Enrich.FromLogContext()
                   .WriteTo.File(
                            System.IO.Path.Combine("D:\\LogFiles", "Practising", "diagnostics.txt"), //here you write your file path
                            rollingInterval: RollingInterval.Day,                                    // create new log file every day
                            fileSizeLimitBytes: 10 * 1024 * 1024,                                    // maximum file size (10 megabytes)
                            retainedFileCountLimit: 30,                                              // it will store in folder maximum 30 days
                            rollOnFileSizeLimit: true,                                               // if file size exceed 10 megabytes it will create new file
                            shared: true,                                                            // log file will  be shared among multiple processes
                            flushToDiskInterval: TimeSpan.FromSeconds(2))                            // log events will be flushed every 2 seconds
                   .CreateLogger();
        }
    }
}
