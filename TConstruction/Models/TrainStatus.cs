using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TConstruction.Models
{
    public enum TrainStat
    {
        InTransit,        // В пути (движется по маршруту)
        Cancelled,        // Отменён
        EmergencyStop      // Аварийная остановка
    }
}

