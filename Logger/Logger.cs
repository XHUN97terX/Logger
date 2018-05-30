using Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Logging
{
    public class Logger : ILogger
    {
        public event AsyncEventHandler<LogEventArgs> Logged;

        public LoggingLevelFlag LoggingLevel
        { get; }

        public Logger(LoggingLevelFlag loggingLevel)
        {
            this.LoggingLevel = loggingLevel;
        }

        public void Log(ILog log)
        {
            if (LoggingLevel.HasFlag((LoggingLevelFlag)log.Type))
                Logged?.Invoke(this, new LogEventArgs(log));
        }

        public void Debug(string message, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            Log(new Log(LogType.Debug, message, null, caller, file, line));
        }

        public void Info(string message, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            Log(new Log(LogType.Info, message, null, caller, file, line));
        }

        public void Warning(string message, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            Log(new Log(LogType.Warning, message, null, caller, file, line));
        }

        public void Error(Exception e, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            Log(new Log(LogType.Error, "", e, caller, file, line));
        }

        public void Fatal(Exception e, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            Log(new Log(LogType.Fatal, "", e, caller, file, line));
        }

        public void Dispose()
        {
            Logged = null;
        }
    }
}
