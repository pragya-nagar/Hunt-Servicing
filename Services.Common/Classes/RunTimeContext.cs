using Services.Common.Interfaces;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Services.Common.Classes
{
    /// <summary>
    /// RunTimeContext
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RunTimeContext : IRunTimeContext
    {
        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; } = (Assembly.GetEntryAssembly() ?? throw new InvalidOperationException())
           .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
           .InformationalVersion;
        /// <summary>
        /// Up time
        /// </summary>
        public TimeSpan Uptime => DateTime.Now - Process.GetCurrentProcess().StartTime;
    }
}
