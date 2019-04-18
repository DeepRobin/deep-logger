using System;
using DeepLogger.Transports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            }

            logger.Transports.Add(new StreamTransport(Console.Out, Console.Error));
        }
    }
}