using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TConstruction.Models
{
    public class JsonModelLog
    {
        public int id { get; set; }
        public string name { get; set; }
        public string operation { get; set; }
        public DateTime date { get; set; }
        public int wagonCount { get; set; } // ← новое поле

        public JsonModelLog(int id, string name, string operation, DateTime date, int wagonCount)
        {
            this.id = id;
            this.name = name;
            this.operation = operation;
            this.date = date;
            this.wagonCount = wagonCount;
        }
    }

}
