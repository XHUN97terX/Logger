using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
    public class LogEventArgs : EventArgs
    {
        public ILog Log { get; private set; }

        public LogEventArgs(ILog log)
        {
            this.Log = log;
        }
    }
}
