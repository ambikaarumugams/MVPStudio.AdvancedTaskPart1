using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsAdvancedTaskPart1.Framework.Models;

namespace MarsAdvancedTaskPart1.Framework.Helpers;

public static class ExtentManager
{
    private static readonly object Lock = new();
    private static ExtentReports? _extent;
    private static string? _reportPath;

    public static ExtentReports GetExtent(Settings config)
    {
        if (_extent != null) return _extent;

        lock (Lock)
        {
            if (_extent != null) return _extent;

            // Build report file path (timestamped)
            var reportsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
            Directory.CreateDirectory(reportsDirectory);

            var timeStamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
            var id = System.Diagnostics.Process.GetCurrentProcess().Id;  //unique id
            _reportPath = Path.Combine(reportsDirectory, $"TestReport_{timeStamp}_p{id}.html");
            
            var reporter = new ExtentSparkReporter(_reportPath);
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark; 
            reporter.Config.DocumentTitle = config.Report.Title;                         
            reporter.Config.ReportName = config.Report.Title;

            var extent = new ExtentReports();
            extent.AttachReporter(reporter);

            // System info
            extent.AddSystemInfo("Environment", config.Environment.TestingEnvironment);
            extent.AddSystemInfo("Tester", config.Environment.Tester);
            extent.AddSystemInfo("OS", config.Environment.OS);
            extent.AddSystemInfo("Browser", config.Browser.Type);
            extent.AddSystemInfo("BaseUrl", config.Environment.BaseUrl);
            
            _extent = extent;
            return _extent;
        }
    }

    public static void Flush()
    {
        _extent?.Flush();
    }

    public static string? ReportPath => _reportPath;  // expose for logging/printing
}