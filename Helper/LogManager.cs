using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Repo_Pattern.Interfaces;

namespace Task_Repo_Pattern
{
    public class LogManager : ILogManager
    {
        private static ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        public LogManager()
        {
        }

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
