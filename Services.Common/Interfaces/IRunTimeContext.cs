using System;

namespace Services.Common.Interfaces
{
    /// <summary>
    /// IRunTimeContext
    /// </summary>
    public interface IRunTimeContext
    {
        /// <summary>
        /// Version
        /// </summary>
        string Version { get; }
        /// <summary>
        /// Up time
        /// </summary>
        TimeSpan Uptime { get; }
    }
}
