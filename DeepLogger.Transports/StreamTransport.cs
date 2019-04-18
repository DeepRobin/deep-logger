using System;
using System.IO;
using System.Linq;

namespace DeepLogger.Transports
{
    /// <summary>
    /// The transport for writing in streams
    /// </summary>
    public sealed class StreamTransport : ITransport
    {
        private readonly TextWriter outWriter;
        private readonly TextWriter errorWriter;

        /// <summary>
        /// The format for the printed log message
        /// </summary>
        public string Format { get; set; } = "[{0}] {1}";

        /// <summary>
        /// The constructor of StreamTransport
        /// </summary>
        /// <param name="outWriter">The writer to write logs</param>
        public StreamTransport(TextWriter outWriter) : this(outWriter, outWriter)
        {
        }

        /// <summary>
        /// The constructor of StreamTransports using 2 writers
        /// </summary>
        /// <param name="outWriter">The writer to write logs with all log levels instead of Error. <seealso cref="LogLevel"/></param>
        /// <param name="errorWriter">The writer to write logs with the log level Error. <seealso cref="LogLevel"/></param>
        public StreamTransport(TextWriter outWriter, TextWriter errorWriter)
        {
            this.outWriter = outWriter;
            this.errorWriter = errorWriter;
        }

        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="level">The log level</param>
        /// <param name="message">The message</param>
        public void Log(LogLevel level, string message)
        {
            message = string.Format(Format, GetAttribute<LogPrefixAttribute>(level), message);
            switch (level)
            {
                case LogLevel.Error:
                    errorWriter.WriteLine(message);
                    break;

                case LogLevel.Info:
                case LogLevel.Verbose:
                case LogLevel.Warning:
                default:
                    outWriter.WriteLine(message);
                    break;
            }
        }

        private TAttribute GetAttribute<TAttribute>(Enum value)
        where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
}