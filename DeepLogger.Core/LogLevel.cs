namespace DeepLogger.Core
{
    /// <summary>
    /// The log level
    /// </summary>
    public enum LogLevel : byte
    {
        /// <summary>
        /// Logging prefix for verbose messages
        /// </summary>
        [LogPrefix("VERBOSE")]
        Verbose = 0x0,

        /// <summary>
        /// Default logging prefix
        /// </summary>
        [LogPrefix("INFO")]
        Info = 0x1,

        /// <summary>
        /// The logging prefix for warnings
        /// </summary>
        [LogPrefix("WARN")]
        Warning = 0x2,

        /// <summary>
        /// The logging prefix for errors and exceptions
        /// </summary>
        [LogPrefix("ERROR")]
        Error = 0x3,
    }
}