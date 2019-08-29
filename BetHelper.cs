using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Roulette
{
    public static class BetHelper
    {        
        public static void CalculateAndWriteWinningBets(int binNumber)
        {
            if (binNumber != 0 && binNumber != 37)
            {
                CheckAndWriteWinningBets(binNumber);               
            }
            else if (binNumber == 37)
            {
                Console.WriteLine("00");                
            }
            else
            {
                Console.WriteLine("0");
            }            
        }
        private static void CheckAndWriteWinningBets(int binNumber)
        {
            Console.WriteLine($"The winning bin Number is {binNumber}\nOther winning bets would be:");
            Console.WriteLine(BinHelper.EvenOrOdd(binNumber));
            Console.WriteLine(BinHelper.RedOrBlack(binNumber));
            Console.WriteLine(BinHelper.LowHigh(binNumber));
            Console.WriteLine(BinHelper.Dozen(binNumber));
            Console.WriteLine(BinHelper.Column(binNumber));
            BinHelper.Street(binNumber);
            BinHelper.DoubleRow(binNumber);
            BinHelper.Split(binNumber);
            BinHelper.Corners(binNumber);
        }

        
    }
}

