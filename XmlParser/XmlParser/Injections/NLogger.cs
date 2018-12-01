using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    public class NLogger : ILogger
    {

        const string STANDARD_PATH = "logfile.txt";

        string path = string.Empty;

        NLog.Logger logger;

        public NLogger() => AddLogger();

        public NLogger(string path)
        {
            this.path = path ?? throw new ArgumentNullException($"{nameof(path)} can't be equal to null.");

            AddLogger();
        }

        void AddLogger()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();

            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = path };

            config.AddRule(NLog.LogLevel.Warn, NLog.LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }

        public void Warn(string message) => logger.Warn(message);
    }
}
