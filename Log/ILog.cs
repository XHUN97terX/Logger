using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    public interface ILog
    {
        int ThreadID { get; }
        int ProcessID { get; }
        int LineNumber { get; }
        string Message { get; }
        string Method { get; }
        string FilePath { get; }
        string FileName { get; }
        Exception Exception { get; }
        DateTime Time { get; }
        LogType Type { get; }
    }
}
