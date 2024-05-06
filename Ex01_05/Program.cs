using System;
using System.Text;

namespace Ex01_05
{
    public class Program
    {
        public const int k_LenOfNum = 8;

        public static void Main()
        {
            int numForStats = getUserInput();
            checkAndPrintStats(numForStats);
        }

        private static int getUserInput()
        {
            bool validInputFromUser;
            int numFromUser;
            StringBuilder userInput = new StringBuilder(k_LenOfNum);

            do 
            {
                Console.WriteLine("Please enter an 8 digits number:");
                userInput.Append(Console.ReadLine());
                validInputFromUser = checkUserInput(userInput, out numFromUser);
                if(!validInputFromUser)
                {
                    Console.WriteLine("Invalid input!\nTry again");
                    userInput.Clear();
                }
            } while(!validInputFromUser);

            return numFromUser;
        }

        private static bool checkUserInput(StringBuilder i_UserInput, out int o_NumFromUser)
        {
            bool validNumFromUser = int.TryParse(i_UserInput.ToString(), out o_NumFromUser);
            
            if(validNumFromUser)
            {
                if(o_NumFromUser < 0 || i_UserInput.Length != k_LenOfNum)
                {
                    validNumFromUser = false;
                }
            }

            return validNumFromUser;
        }

        private static void checkAndPrintStats(int i_NumForStats)
        {
            int leastSignificantDigit = i_NumForStats % 10, smallerThanLeastSignificantDigit = 0, biggestDigit = 0;
            int countOfDigitsDividableBy3 = 0, currentDigitInNumForStats, numOfLeadingZeroes, numOfDigits = 0;
            float avgOfDigits = 0;

            while(i_NumForStats > 0)
            {
                currentDigitInNumForStats = i_NumForStats % 10;
                if(currentDigitInNumForStats < leastSignificantDigit)
                {
                    smallerThanLeastSignificantDigit++;
                }
                if(currentDigitInNumForStats % 3 == 0)
                {
                    countOfDigitsDividableBy3++;
                }
                if(currentDigitInNumForStats > biggestDigit)
                {
                    biggestDigit = currentDigitInNumForStats;
                }

                avgOfDigits += currentDigitInNumForStats;
                i_NumForStats /= 10;
                numOfDigits++;
            }

            numOfLeadingZeroes = k_LenOfNum - numOfDigits; 
            avgOfDigits /= k_LenOfNum;
            countOfDigitsDividableBy3 += numOfLeadingZeroes;
            if(leastSignificantDigit != 0)
            {
                smallerThanLeastSignificantDigit += numOfLeadingZeroes;
            }

            Console.WriteLine(new StringBuilder().AppendFormat(
@"The number of digits that are smaller from the least significant digit is: {0}
The number of digits that divisible by 3 are: {1}
The biggest digit is: {2}
The average of the digits are: {3}",
            smallerThanLeastSignificantDigit, countOfDigitsDividableBy3, biggestDigit, avgOfDigits));
        }
    }
}
