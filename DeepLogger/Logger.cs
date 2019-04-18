using System.Collections.Generic;

namespace DeepLogger
{
    /// <summary>
    /// The logger instance of DeepLogger
    /// </summary>
    public sealed class Logger
    {
        /// <summary>
        /// Transports are the "log functions". E.g. Log in File, Log in Console, ...
        /// </summary>
        public readonly List<ITransport> Transports = new List<ITransport>();

        /// <summary>
        /// The options for this logger
        /// </summary>
        public LoggerOptions Options { get; set; } = new LoggerOptions
        {
            DisableLoggingFor = {
#if RELEASE
                LogLevel.VERBOSE,
#endif
            },
        };

        /// <summary>
        /// The log event will be raised on log
        /// </summary>
        public event LogEventHandler OnLog;

        /// <summary>
        /// Logs a message to a log level
        /// </summary>
        /// <param name="level">The log level</param>
        /// <param name="message">The message</param>
        public void Log(LogLevel level, string message)
        {
            foreach (ITransport transport in Transports)
            {
                if (OnLog != null)
                {
                    LogEventArgs args = new LogEventArgs(level, message);
                    OnLog(this, args);
                    if (args.Cancel)
                        return;
                }
                transport.Log(level, message);
            }
        }

        /// <summary>
        /// Logs a message using the info log level
        /// <seealso cref="Log(LogLevel, string)"/>
        /// </summary>
        /// <param name="message">The message</param>
        public void Info(string message) => Log(LogLevel.Info, message);

        /// <summary>
        /// Logs a message using the warning log level
        /// <seealso cref="Log(LogLevel, string)"/>
        /// </summary>
        /// <param name="message">The message</param>
        public void Warning(string message) => Log(LogLevel.Warning, message);

        /// <summary>
        /// Logs a message using the error log level
        /// <seealso cref="Log(LogLevel, string)"/>
        /// </summary>
        /// <param name="message">The message</param>
        public void Error(string message) => Log(LogLevel.Error, message);
    }
}