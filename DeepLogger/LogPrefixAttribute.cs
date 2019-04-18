using System;

namespace DeepLogger
{
    /// <summary>
    /// Attribute for the log prefix of a log level
    /// <see cref="LogLevel"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class LogPrefixAttribute : Attribute
    {
        /// <summary>
        /// The log prefix
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Attribute constructor for the log prefix
        /// </summary>
        /// <param name="value">The log prefix</param>
        public LogPrefixAttribute(string value)
        {
            Value = value;
        }

    }
}