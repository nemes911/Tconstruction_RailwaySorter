using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TConstruction.Models
{
    public class TModel
    {
        public const int Length = 10;

        public bool LeftOpen { get; set; }

        public bool RightOpen { get; set; }

        public TModel()
        {
            LeftOpen = true;
            RightOpen = true;
        }

        // Метод переключения левого пути
        public void SetLeft(bool isOpen)
        {
            LeftOpen = isOpen;
        }

        // Метод переключения правого пути
        public void SetRight(bool isOpen)
        {
            RightOpen = isOpen;
        }
    }
}
