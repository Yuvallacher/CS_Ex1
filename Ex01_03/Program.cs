using System;
using System.Text;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            int numOfRows = getUserInput();
            Ex01_02.Program.printDiamond(Ex01_02.Program.k_StartingRow, numOfRows);
        }

        private static int getUserInput()
        {
            bool successfullyParsed;
            int numOfRows;
            StringBuilder userInput = new StringBuilder();

            do
            {
                Console.WriteLine("Please enter the number of rows for the diamond: ");
                userInput.Append(Console.ReadLine());
                successfullyParsed = int.TryParse(userInput.ToString(), out numOfRows);
                if(!successfullyParsed)
                {
                    Console.WriteLine("Invalid input! Your input is not a whole number");
                    userInput.Clear();
                }
            } while(!successfullyParsed);

            if(numOfRows % 2 == 0)
            {
                numOfRows++;
            }

            return numOfRows;
        }
    }
}
