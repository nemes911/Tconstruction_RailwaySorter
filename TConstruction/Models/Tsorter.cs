using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TConstruction.Models
{
    public class Tsorter
    {
        public const int SafeDistance = 1;//км

        public bool LeftOpen { get; private set; } = true;

        public bool RightOpen { get; private set;} = true;

        public async Task SendLeftAsync(int speed)
        {
            if (!LeftOpen)
            {
                return;
            }
            LeftOpen = false;

            double timeSec = SafeDistance / (speed / 3600.0);

            await Task.Delay(TimeSpan.FromSeconds(timeSec));

            LeftOpen = true;
        }

        public async Task SendRightAsync(double speedKmH)
        {
            if (!RightOpen)
            {
                Console.WriteLine("Правый путь закрыт!");
                return;
            }

            RightOpen = false;
            Console.WriteLine("Поезд ушёл вправо, путь закрыт.");

            double timeSec = SafeDistance / (speedKmH / 3600.0);
            await Task.Delay(TimeSpan.FromSeconds(timeSec));

            RightOpen = true;
            Console.WriteLine("Правый путь снова открыт.");
        }

    }
}
