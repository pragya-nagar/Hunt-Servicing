using System.ComponentModel;

namespace Services.Common.Constants
{
    /// <summary>
    /// Enums
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Certificate Status
        /// </summary>
        public enum CertificateStatus
        {
            /// <summary>
            /// The pending
            /// </summary>
            [Description("Pending Certificate")]
            Pending = 0,
            /// <summary>
            /// The generated
            /// </summary>
            [Description("Generated Certificate")]
            Generated
        }
    }
}
