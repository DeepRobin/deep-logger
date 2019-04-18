using DeepLogger.Core;
using System;

namespace DeepLogger.Transports
{
    /// <summary>
    /// The transport for delegate methods
    /// </summary>
    public class ActionTransport : ITransport
    {
        private readonly Action<LogLevel, string> action;

        /// <summary>
        /// The constructor of ActionTransport
        /// </summary>
        /// <param name="action"></param>
        public ActionTransport(Action<LogLevel, string> action)
        {
            this.action = action;
        }

        /// <summary>
        /// Logs a message to a instance of Action
        /// </summary>
        /// <param name="level">The log level</param>
        /// <param name="message">The message</param>
        public void Log(LogLevel level, string message)
        {
            action(level, message);
        }
    }
}