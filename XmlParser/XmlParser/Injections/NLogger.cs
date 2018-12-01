using System;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    /// <summary>
    /// Class which is an adapter for NLogger.
    /// </summary>
    public class NLogger : ILogger
    {
        const string STANDARD_PATH = "logfile.txt";

        string path = string.Empty;

        NLog.Logger logger;

        /// <summary>
        /// Constructor without arguments.
        /// </summary>
        public NLogger() => AddLogger();

        /// <summary>
        /// Constructor with 1 argument.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        public NLogger(string path)
        {
            this.path = path ?? throw new ArgumentNullException($"{nameof(path)} can't be equal to null.");

            AddLogger();
        }

        /// <summary>
        /// Writes warn into file.
        /// </summary>
        /// <param name="message">Message which will be written.</param>
        public void Warn(string message) => logger.Warn(message);

        void AddLogger()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();

            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = path };

            config.AddRule(NLog.LogLevel.Warn, NLog.LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }
    }
}
