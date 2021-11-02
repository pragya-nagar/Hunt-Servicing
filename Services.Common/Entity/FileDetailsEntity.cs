using System.Diagnostics.CodeAnalysis;

namespace Services.Common.Entity
{
    /// <summary>
    /// FileDetailsEntity
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FileDetailsEntity
    {
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// FileData
        /// </summary>
        public string FileData { get; set; }
    }
}
