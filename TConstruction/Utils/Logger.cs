using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TConstruction.Models;
using System.IO;
using System.Text.Json;

namespace TConstruction.Utils
{
    internal class Logger
    {
        private static readonly string logPath = "train_log.json";

        public static void Log(JsonModelLog jsonModelLog)
        {
            Console.WriteLine($"[{jsonModelLog.date:HH:mm:ss}] {jsonModelLog.name} → {jsonModelLog.operation}");

            var json = System.Text.Json.JsonSerializer.Serialize(jsonModelLog);
            File.AppendAllText(logPath, json + Environment.NewLine);
        }
    }
}
