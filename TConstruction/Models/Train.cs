using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TConstruction.Models;

namespace TConstruction.Models
{
    public abstract class Train
    {
       public int id { get; set; }

        public string name { get; set; }

        public int speed { get; set; }

        public TrainStat status { get; set; }

        public Model model { get; set; }

        public TrainStat changestaToStop(int speed)
        {
            if(speed == null)
            {
                return status = TrainStat.EmergencyStop;
            }

            return status;
        }


        public void ChancheSpeed(int newspeed)
        {
            speed = newspeed;


        }
        
           
        
    }
}
