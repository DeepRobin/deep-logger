using System;

namespace DeepLogger
{
    /// <summary>
    /// The log event handler
    /// </summary>
    /// <param name="source">The source object</param>
    /// <param name="args">The detailed information of the log entry</param>
    public delegate void LogEventHandler(object source, LogEventArgs args);

    /// <summary>
    /// Event Args for LogEvent
    /// </summary>
    public sealed class LogEventArgs : EventArgs, ICancelable
    {
        /// <summary>
        /// The log level of the log entry
        /// </summary>
        public LogLevel Level { get; private set; }

        /// <summary>
        /// It is the log message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Cancel logging
        /// </summary>
        public bool Cancel { get; set; } = false;

        /// <summary>
        /// Constructor of LogEventArgs
        /// </summary>
        /// <param name="level">The log level of the log entry</param>
        /// <param name="message">The message of the log entry</param>
        public LogEventArgs(LogLevel level, string message)
        {
            Level = level;
            Message = message;
        }
    }
}