using DeepLogger.Transports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace DeepLogger.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Logger logger = new Logger();
            logger.Options = new LoggerOptions
            {
                DisableLoggingFor = { }
            };

            logger.Transports.Add(new StreamTransport(Console.Out, Console.Error));
            logger.OnLog += Logger_OnLog;
            logger.Log(Core.LogLevel.Info, "Hello, this is a test.");
        }

        private void Logger_OnLog(object source, LogEventArgs args)
        {
            MessageBox.Show(string.Format("{0}", args.Message));
        }
    }
}