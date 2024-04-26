using System;
using Ex01_02;



namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            int numOfRows = GetUserInput();
            Ex01_02.Program.PrintDiamond(0, numOfRows);
        }

        public static int GetUserInput()
        {
            bool successfullyParsed;
            int numOfRows;

            do
            {
                Console.WriteLine("Please enter the number of rows for the diamond: ");
                string userInput = Console.ReadLine();
                successfullyParsed = int.TryParse(userInput, out numOfRows);
                if (!successfullyParsed)
                {
                    Console.WriteLine("Invalid input! \"" + userInput + "\" is not a whole number");
                }
            }
            while (!successfullyParsed);

            if (numOfRows % 2 == 0)
            {
                numOfRows++;
            }

            return numOfRows;
        }
    }
}
