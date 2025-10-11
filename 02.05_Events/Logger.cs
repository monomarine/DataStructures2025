using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._05_Events
{
    internal class Logger
    {
        private readonly string _logFile;

        public Logger(string logFile = "logs.txt")
        {
            _logFile = logFile;
        }

        public void Log(string message)
        {
            string fullMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\t{message}\n";
            File.AppendAllText(_logFile, fullMessage);
        }
    }
}
