using System;
using System.Diagnostics;
using Services.Common.Classes;
using Xunit;

namespace Services.Common.TestCases.ClassTestCases
{
    public class RunTimeContextTest
    {
        [Fact]
        public void Version_success()
        {
            var context = new RunTimeContext();
            var version = context.Version;
            Assert.True(version.Length > 0);
        }

        [Fact]
        public void UpTime_success()
        {
            var context = new RunTimeContext();
            var upTime = context.Uptime;
            var time = DateTime.Now - Process.GetCurrentProcess().StartTime;
            Assert.NotEqual(time, upTime);
        }
    }
}
