using CoreLibrary.Interfaces;
using NLog;
using System;

namespace CoreLibrary.Services
{
    public class LoggerService : ILoggerService
    {
        public readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public LoggerService()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = $"file{DateTime.Now.ToString("d")}.txt" };

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }

        Logger ILoggerService.Logger => NLog.LogManager.GetCurrentClassLogger();

        public string GetLog()
        {
            throw new NotImplementedException();
        }
    }
}
