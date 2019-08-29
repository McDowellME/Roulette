using System;

namespace Roulette
{
    class Program
    {
        public static int binNumber = WheelHelper.SpinWheel();
        static void Main(string[] args)
        {            
            BetHelper.CalculateAndWriteWinningBets(binNumber);
        }
    }
}
