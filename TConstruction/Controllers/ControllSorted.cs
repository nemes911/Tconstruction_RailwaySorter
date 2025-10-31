using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TConstruction.Models;

namespace TConstruction.Controllers
{
    public class ControllSorted
    {
        private readonly Tsorter tsorter = new Tsorter() ;

        public async Task HandleTrainAsync(Train train)
        {
            Console.WriteLine("Поезд " + train.name + " прибыл со скоростью " + train.speed + " км/ч");

            if (train.speed >= 120)
            {
                await tsorter.SendRightAsync(train.speed);
            }
            else
            {
                await tsorter.SendLeftAsync(train.speed);
            }
        }

        public void ShowStatus()
        {
            Console.WriteLine("Левый путь: " + (tsorter.LeftOpen ? "Открыт" : "Закрыт"));
            Console.WriteLine("Правый путь: " + (tsorter.RightOpen ? "Открыт" : "Закрыт"));
        }


    }
}
