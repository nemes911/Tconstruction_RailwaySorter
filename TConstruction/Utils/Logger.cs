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

        public static void Log(JsonModelLog logEntry)
        {
            Console.WriteLine($"[{logEntry.date:HH:mm:ss}] {logEntry.name} → {logEntry.operation} ({logEntry.wagonCount} вагонов)");

            var json = JsonSerializer.Serialize(logEntry);
            File.AppendAllText(logPath, json + Environment.NewLine);
        }

    }
}
