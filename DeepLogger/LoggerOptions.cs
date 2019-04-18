using DeepLogger.Core;

namespace DeepLogger
{
    /// <summary>
    /// The logging options for the Logger
    /// <see cref="Logger"/>
    /// </summary>
    public struct LoggerOptions
    {
        /// <summary>
        /// Disables logging for specific log levels
        /// <see cref="LogLevel"/>
        /// </summary>
        public LogLevel[] DisableLoggingFor;
    }
}