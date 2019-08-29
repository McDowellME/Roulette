using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Roulette
{
    public class BinHelper
    {        
        //determines if bin is even or odd
        public static string EvenOrOdd(int binNumber)
        {
            if (binNumber % 2 == 0)
            {
                return "Even";
            }
            return "Odd";
        }
        
        public static int[] red = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        // defining black may not be necessary
        //public int[] black = new int[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

            
        //determines whether bin is red or black        
        public static string RedOrBlack(int binNumber)
        {
            if (red.Contains(binNumber))
            {
                return "Red";
            }
            return "Black";
        }
        //determines whether bin is Low or High
        public static string LowHigh(int binNumber)
        {
            if (binNumber <= 18)
            {
                return "Low";
            }
            return "High";
        }
        //determines what dozen bin number is in
        public static string Dozen(int binNumber)
        {
            if (binNumber <= 12)
            {
                return "1st Dozen";
            }
            if (binNumber > 24)
            {
                return "3rd Dozen";
            }
            return "2nd Dozen";
        }
        public static int[] firstColumn = new int[] { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
        public static int[] secondColumn = new int[] { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
        //public int[] thirdColumn = new int[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
        public static string Column(int binNumber) //TODO: Is there a formula to determine column?
        {
            if (firstColumn.Contains(binNumber))
            {
                return "1st Column";
            }
            if (secondColumn.Contains(binNumber))
            {
                return "2nd Column";
            }
            return "3rd Column";
        }
                
        public static int streetBin1;
        public static int streetBin2;
        public static int streetBin3;
        //Would rather this be an array
        //public static int[] street = new int[] { streetBin1, streetBin2, streetBin3 };


        public static void Street(int binNumber)
        {
            if (firstColumn.Contains(binNumber))
            {
                streetBin1 = binNumber;
                streetBin2 = binNumber + 1;
                streetBin3 = binNumber + 2;
                
            }
            else if (secondColumn.Contains(binNumber))
            {
                streetBin1 = binNumber - 1;
                streetBin2 = binNumber;
                streetBin3 = binNumber + 1;
            }
            else
            {
                streetBin1 = binNumber - 2;
                streetBin2 = binNumber - 1;
                streetBin3 = binNumber;
            }
            Console.WriteLine($"Street: {streetBin1}, {streetBin2}, {streetBin3}");              
        }        
        
        public static void DoubleRow(int binNumber)
        {
            int streetBin1Below = streetBin1 - 3;
            int streetBin2Below = streetBin2 - 3;
            int streetBin3Below = streetBin3 - 3;
            int streetBin1Above = streetBin1 + 3;
            int streetBin2Above = streetBin2 + 3;
            int streetBin3Above = streetBin3 + 3;
            //would rather this be an array
            
            if (streetBin1 == 1)
            {
                Console.WriteLine($"Double Row Above: {streetBin1}, {streetBin2}, {streetBin3}, {streetBin1Above}, {streetBin2Above}, {streetBin3Above} ");
            }
            else if (streetBin1 == 34)
            {
                Console.WriteLine($"Double Row Below: {streetBin1Below}, {streetBin2Below}, {streetBin3Below}, {streetBin1}, {streetBin2}, {streetBin3} ");
            }
            else
            {
                Console.Write($"Double Row - Below: ({streetBin1Below}, {streetBin2Below}, {streetBin3Below}, {streetBin1}, {streetBin2}, {streetBin3}) ");
                Console.WriteLine($"Above: ({streetBin1}, {streetBin2}, {streetBin3}, {streetBin1Above}, {streetBin2Above}, {streetBin3Above})");
            }            
        }
        public static int splitBinBelow;
        public static int splitBinAbove;
        public static int splitBinRight;
        public static int splitBinLeft;
                
        public static void Split(int binNumber) //use arrays
        {
            splitBinBelow = binNumber + 3;
            splitBinAbove = binNumber - 3;
            splitBinRight = binNumber + 1;
            splitBinLeft = binNumber - 1;

            if (binNumber > 3 && binNumber < 34)
            {
                Console.Write($"Splits: " +
                    $"({binNumber}, {splitBinAbove}), " +
                    $"({binNumber}, {splitBinBelow})");
            }
            else if ( binNumber < 4)
            {
                {
                    Console.Write($"Splits: ({binNumber}, {splitBinBelow})");
                }
            }
            else
            {
                Console.Write($"Splits: ({binNumber}, {splitBinAbove})");
            }
            
            if (firstColumn.Contains(binNumber))
            {
                Console.WriteLine($", ({binNumber}, {splitBinRight})");
            }
            else if (secondColumn.Contains(binNumber))
            {
                Console.WriteLine($", ({binNumber}, {splitBinLeft}), ({binNumber}, {splitBinRight})");
            }
            else
            {
                Console.WriteLine($", ({binNumber}, {splitBinLeft})");                
            }
        }

        
        public static void Corners(int binNumber)
        {
            //Looks if match to First Column
            if (firstColumn.Contains(binNumber))
            {
                //If bin number not first or last row
                if (binNumber > 3 && binNumber < 34)
                {
                    Console.Write($"Corners: " +
                        //upper right corners
                        $"({binNumber}, {binNumber +1}, {binNumber -2}, {binNumber -3}), " +
                        //lower right corners
                        $"({binNumber}, {binNumber + 1}, {binNumber + 3}, {binNumber + 4})");
                }
                //if bin number in first row
                else if (binNumber < 4)
                {
                    //lower right corners
                    Console.WriteLine($"Corners: ({binNumber}, {binNumber + 1}, {binNumber + 3}, {binNumber + 4})");
                }
                //if bin number is last row
                else
                {
                    //upper right corners
                    Console.WriteLine($"Corners: ({binNumber}, {binNumber + 1}, {binNumber - 2}, {binNumber - 3})");
                }                
            }
            //Looks if match to Second Column
            else if (secondColumn.Contains(binNumber))
            {
                //Bin number not first or last row
                if (binNumber > 3 && binNumber < 34)
                {
                    Console.WriteLine($"Corners: " +
                        //upper right corners
                        $"({binNumber}, {binNumber + 1}, {binNumber - 2}, {binNumber - 3}), " +
                        //lower right corners
                        $"({binNumber}, {binNumber + 1}, {binNumber + 3}, {binNumber + 4}), " +
                        //upper left corners
                        $"({binNumber}, {binNumber - 1}, {binNumber - 3}, {binNumber - 4}), " +
                        //lower left corners
                        $"({binNumber}, {binNumber - 1}, {binNumber + 2}, {binNumber + 3}))");
                }
                //bin number in first row
                else if (binNumber < 4)
                {
                    Console.WriteLine($"Corners:" +
                        //lower left corners
                        $"({binNumber}, {binNumber - 1}, {binNumber + 2}, {binNumber + 3})," +
                        //lower right corners
                        $"({binNumber}, {binNumber + 1}, {binNumber + 3}, {binNumber + 4})");
                }
                else
                    //bin number is last row
                    Console.Write($"Corners:" +
                        //upper right corners
                        $"({binNumber}, {binNumber + 1}, {binNumber - 2}, {binNumber - 3})," +
                        //upper left corners
                        $"({binNumber}, {binNumber - 1}, {binNumber - 3}, {binNumber - 4})");
            }
            //Third column
            else
            {
                //bin number not in first or last row
                if (binNumber > 3 && binNumber < 34)
                {
                    Console.Write($"Corners: " +
                        //upper left corners
                        $"({binNumber}, {binNumber - 1}, {binNumber - 3}, {binNumber - 4}), " +
                        //lower left corners
                        $"({binNumber}, {binNumber - 1}, {binNumber + 2}, {binNumber + 3})");
                }
                //bin number in first row
                else if (binNumber < 4)
                {
                    //lower left corners
                    Console.Write($"Corners: ({binNumber}, {binNumber - 1}, {binNumber + 2}, {binNumber + 3})");
                }
                //bin number in last row
                else
                {
                    //upper left corners
                    Console.Write($"Corners: ({binNumber}, {binNumber - 1}, {binNumber - 3}, {binNumber - 4})");
                }
            }
        }
    }
}

