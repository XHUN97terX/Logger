using Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public abstract class LogWriter : ILogWriter
    {
        public abstract Task Write(ILog log);
        public abstract void Dispose();

        async Task WriteEventHandler(object sender, LogEventArgs e)
        {
            try
            {
                await Write(e.Log);
            }
            // disabling the warning as it (likely) won't ever be used other than in Visual Studio to debug
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            { }
        }

        public void Subscribe(ILogger logger)
        {
            logger.Logged += WriteEventHandler;
        }

        public void Unsubscribe(ILogger logger)
        {
            logger.Logged -= WriteEventHandler;
        }
    }
}
