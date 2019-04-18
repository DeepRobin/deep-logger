namespace DeepLogger.Core
{
    /// <summary>
    /// The interface for transports
    /// </summary>
    public interface ITransport
    {
        /// <summary>
        /// Prints a log message in the transport
        /// </summary>
        /// <param name="level">The log level</param>
        /// <param name="message">The message</param>
        void Log(LogLevel level, string message);
    }
}