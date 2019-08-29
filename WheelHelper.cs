using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    public class WheelHelper
    {
        public static int SpinWheel()
        {
            Random random = new Random();
            return random.Next(0, 37);
        }
    }
}

