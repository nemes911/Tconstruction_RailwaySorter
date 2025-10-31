using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TConstruction.Utils
{
    internal class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
            // Дополнительно: запись в файл 
        }
    }
}
