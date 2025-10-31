using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TConstruction.Models
{
    public class SpeedTrain : Train
    {
        public int max_speed { get; set; }

        public string ServiceClass { get; set; }

        public int wagonCount { get; set; }
    }
}
