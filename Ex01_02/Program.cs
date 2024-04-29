﻿using System;

namespace Ex01_02
{
    public class Program
    {
        public const int k_StartingRow = 0;

        public static void Main()
        {
            PrintDiamond(k_StartingRow, 9);
        }

        public static void PrintDiamond(int i_NumOfCurrentRow, int i_DesiredNumOfRows)
        {
            if (i_NumOfCurrentRow < i_DesiredNumOfRows)
            {
                PrintDiamond(i_NumOfCurrentRow + 1, i_DesiredNumOfRows);
                int spaces = Math.Abs(i_DesiredNumOfRows / 2 - i_NumOfCurrentRow);
                Console.Write(new string(' ', spaces));
                if (i_NumOfCurrentRow < i_DesiredNumOfRows / 2)
                {
                    PrintLine(2 * i_NumOfCurrentRow + 1);
                }
                else
                {
                    PrintLine((i_DesiredNumOfRows - i_NumOfCurrentRow) * 2 - 1);
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