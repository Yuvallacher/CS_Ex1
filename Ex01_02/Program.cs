using System;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            PrintDiamond(0, 9);
        }

        public static void PrintDiamond(int i_numOfCurrentRow, int i_desiredNumOfRows)
        {
            if (i_numOfCurrentRow < i_desiredNumOfRows)
            {
                PrintDiamond(i_numOfCurrentRow + 1, i_desiredNumOfRows);
                int spaces = Math.Abs(i_desiredNumOfRows / 2 - i_numOfCurrentRow);
                Console.Write(new string(' ', spaces));
                if (i_numOfCurrentRow < i_desiredNumOfRows / 2)
                {
                    PrintLine(2 * i_numOfCurrentRow + 1);
                }
                else
                {
                    PrintLine((i_desiredNumOfRows - i_numOfCurrentRow) * 2 - 1);
                }
            }
        }

        public static void PrintLine(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
        }
    }
}