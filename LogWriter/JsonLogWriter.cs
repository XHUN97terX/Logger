using Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class JsonLogWriter : LogWriter
    {
        JsonTextWriter jsonWriter;
        StreamWriter streamWriter;
        JsonSerializer serializer;

        public JsonLogWriter(string logFile)
        {
            try
            {
                streamWriter = new StreamWriter(logFile);
                streamWriter.AutoFlush = true;
                jsonWriter = new JsonTextWriter(streamWriter);
                serializer = new JsonSerializer();
                serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                jsonWriter.CloseOutput = true;
            }
            // disabling the warning as it (likely) won't ever be used other than in Visual Studio to debug
            #pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
            #pragma warning restore CS0168 // Variable is declared but never used
            { }
        }

        public override void Dispose()
        {
            jsonWriter.Close();
        }

        public async override Task Write(ILog log)
        {
            await Task.Run(() =>
            {
                serializer.Serialize(jsonWriter, log);
                jsonWriter.Flush();
                streamWriter.Write(Environment.NewLine);
            });
        }
    }
}
