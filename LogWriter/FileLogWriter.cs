using Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logging
{
    public class FileLogWriter : LogWriter
    {
        StreamWriter writer;

        public FileLogWriter(string logFile)
        {
            try
            {
                writer = new StreamWriter(logFile);
                writer.AutoFlush = true;
            }
            // disabling the warning as it (likely) won't ever be used other than in Visual Studio to debug
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            { }
        }

        public override void Dispose()
        {
            writer.Close();
        }

        public async override Task Write(ILog log)
        {
            await writer.WriteLineAsync(Regex.Replace(log.ToString(), "(\r\n|\r|\n)", ""));
        }
    }
}
