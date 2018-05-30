using Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public interface ILogWriter : IDisposable
    {
        void Subscribe(ILogger logger);
        void Unsubscribe(ILogger logger);
        Task Write(ILog log);
    }
}
