using AventStack.ExtentReports;
using MarsAdvancedTaskPart1.Framework.Models;

namespace MarsAdvancedTaskPart1.Framework.Helpers
{
    public static class ExtentTestManager
    {
        private static readonly ThreadLocal<ExtentTest?> _current = new();

        public static ExtentTest CreateTest(ExtentReports report,string name)
        {
            var test = report.CreateTest(name);
            _current.Value = test;
            return test;
        }

        public static ExtentTest GetTest() => _current.Value!;
    }
}
