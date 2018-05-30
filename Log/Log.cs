using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Logging
{
    public class Log : ILog
    {
        public Exception Exception
        { get; }
        public LogType Type
        { get; }
        public int LineNumber
        { get; }
        public string Message
        { get; }
        public string FilePath
        { get; }
        public string FileName
        { get; }
        public string Method
        { get; }
        public int ProcessID
        { get; }
        public int ThreadID
        { get; }
        public DateTime Time
        { get; }

        public Log(LogType logType, string message, Exception exception = null, [CallerMemberName] string caller = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = 0)
        {
            if (!Enum.IsDefined(typeof(LogType), logType))
                throw new ArgumentException($"Log type is invalid! There is no LogType with value: {logType}", nameof(logType));
            Time = DateTime.Now;
            ProcessID = Process.GetCurrentProcess().Id;
            ThreadID = Thread.CurrentThread.ManagedThreadId;
            this.Message = message;
            this.Type = logType;
            this.Exception = exception;
            this.Method = caller;
            this.LineNumber = line;
            this.FilePath = file;
            this.FileName = Path.GetFileName(file);
        }

        public override string ToString()
        {
            var builder = new StringBuilder($"[{Time.ToString("dd-MM-yyyy HH:mm:ss")}][{ProcessID}][{ThreadID}][{FileName} at {Method} ({LineNumber})][{Type}] - ");
            if (Message != "")
            {
                builder.Append($"{Message} ");
                if (Exception != null)
                    builder.Append("| ");
            }
            if (Exception != null)
                builder.Append(Exception);

            return builder.ToString();
        }
    }
}
