using System;
using System.Text;

namespace Ex01_01
{
    public class Program
    {   
        public const int k_AmountOfNumbers = 3;
        public const int k_LengthOfBinaryNumber = 9; 
        public const int k_Zero = 0;
        public const int k_One = 1;
        
        public static void Main()
        {
            int binaryNumber1, binaryNumber2, binaryNumber3;
            int decimalNumber1, decimalNumber2, decimalNumber3;
            int maxNumber, midNumber, minNumber;

            Console.WriteLine("Please enter 3 binary numbers with 9 digits each");
            binaryNumber1 = GetUserInput();
            binaryNumber2 = GetUserInput();
            binaryNumber3 = GetUserInput();
            decimalNumber1 = ConvertBinaryToDecimal(binaryNumber1);
            decimalNumber2 = ConvertBinaryToDecimal(binaryNumber2);
            decimalNumber3 = ConvertBinaryToDecimal(binaryNumber3);
            FindOrderOfNumbers(decimalNumber1, decimalNumber2, decimalNumber3, out minNumber, out midNumber, out maxNumber);
            Console.WriteLine("The numbers are {0}, {1}, {2}", minNumber, midNumber, maxNumber);
            CalcAvgNumberOfDigitsFromBinary(binaryNumber1, binaryNumber2, binaryNumber3);
            CalcHowManyArePowerOf2(decimalNumber1, decimalNumber2, decimalNumber3);
            CalcUpSeries(decimalNumber1, decimalNumber2, decimalNumber3);
            Console.WriteLine(
@"Biggest number: {0}
Smallest number: {1}", maxNumber, minNumber);
        }

        public static int GetUserInput()
        {
            bool validInputFromUser;
            int numFromUser;
            StringBuilder userInput = new StringBuilder(k_LenOfBinaryNumber);

            do
            {
                userInput.Append(Console.ReadLine());
                validInputFromUser = CheckUserInput(userInput, out numFromUser);
                if (!validInputFromUser)
                {
                    Console.WriteLine("Invalid input!\nTry again");
                    userInput.Clear();
                }

            } while (!validInputFromUser);

            return numFromUser;
        }

        public static int ConvertBinaryToDecimal(int io_BinaryNumber)
        {
            int resDecNumber = 0, currentDigitInNumber, currentPower = 0;

            while(io_BinaryNumber > 0) 
            {
                currentDigitInNumber = io_BinaryNumber % 10;
                resDecNumber += currentDigitInNumber * (int)Math.Pow(2, currentPower);
                io_BinaryNumber /= 10;
                currentPower++;
            }

            return resDecNumber;
        }

        public static bool CheckUserInput(StringBuilder io_UserInput, out int o_NumFromUser)
        {
            bool validNumFromUser = int.TryParse(io_UserInput.ToString(), out o_NumFromUser);
            
            if (validNumFromUser)
            {
                if (io_UserInput.Length == k_LenOfBinaryNumber)
                {
                    validNumFromUser = IsBinaryNumber(io_UserInput);
                }
                else
                {
                    validNumFromUser = false;
                }
            }

            return validNumFromUser;
        }

        public static bool IsBinaryNumber(StringBuilder io_UserInput)
        {
            bool validBinaryNumber = true;
            
            for (int i = 0; i < k_LenOfBinaryNumber; i++)
            {
                if (io_UserInput[i] != '0' && io_UserInput[i] != '1')
                {
                    validBinaryNumber = false;
                }
            }

            return validBinaryNumber;
        }

        public static void CalcAvgNumberOfDigitsFromBinary(int io_BinaryNumber1, int io_BinaryNumber2, int io_BinaryNumber3)
        {
            float countOfZero = 0, countOfOne = 0;

            countOfZero += GetHowManyDigits(io_BinaryNumber1, k_Zero);
            countOfZero += GetHowManyDigits(io_BinaryNumber2, k_Zero);
            countOfZero += GetHowManyDigits(io_BinaryNumber3, k_Zero);
            countOfOne += GetHowManyDigits(io_BinaryNumber1, k_One);
            countOfOne += GetHowManyDigits(io_BinaryNumber2, k_One);
            countOfOne += GetHowManyDigits(io_BinaryNumber3, k_One);
            countOfZero /= k_AmountOfNumbers;
            countOfOne /= k_AmountOfNumbers;
            Console.WriteLine("The average size of digit zero is: {0} and of the digit one is: {1}", countOfZero, countOfOne);
        }

        public static float GetHowManyDigits(int io_BinaryNumber, int i_DigitToSearch)
        {
            int countOfDigitsInTheNumber = 0;

            for (int i = 0; i < k_LenOfBinaryNumber; i++) 
            { 
                if (io_BinaryNumber % 10 == i_DigitToSearch)
                {
                    countOfDigitsInTheNumber++;
                }

                io_BinaryNumber /= 10;
            }

            return countOfDigitsInTheNumber;
        }

        public static void CalcUpSeries(int io_DecimalNumber1, int io_DecimalNumber2, int io_DecimalNumber3)
        {
            int countOfUpSeries = IsUpSeries(io_DecimalNumber1) + IsUpSeries(io_DecimalNumber2) + IsUpSeries(io_DecimalNumber3);
           
            Console.WriteLine("Numbers that are an up series: {0}", countOfUpSeries);
        }

        public static int IsUpSeries(int io_DecimalNumber)
        {
            bool isUpSeries = true;
            int resIsUpSeries = 0, leastSignificantDigit = io_DecimalNumber % 10, currDigit;

            io_DecimalNumber /= 10;
            while (io_DecimalNumber > 0)
            {
                currDigit = io_DecimalNumber % 10;
                if (currDigit >= leastSignificantDigit)
                {
                    isUpSeries = false;
                }

                leastSignificantDigit = currDigit;
                io_DecimalNumber /= 10;
            }

            if (isUpSeries)
            {
                resIsUpSeries = 1;
            }

            return resIsUpSeries;
        }

        public static void CalcHowManyArePowerOf2(int io_DecimalNumber1, int io_DecimalNumber2, int io_DecimalNumber3)
        {
            int countOfNumbersPowerOf2 = IsPowerOf2(io_DecimalNumber1) + IsPowerOf2(io_DecimalNumber2) + IsPowerOf2(io_DecimalNumber3);
            
            Console.WriteLine("Numbers that are a power of 2: {0}", countOfNumbersPowerOf2);
        }

        public static int IsPowerOf2(int io_DecimalNumber)
        {
            int resIsPowerOf2 = 0;
            bool isPowerOf2 = io_DecimalNumber > 0 && (io_DecimalNumber & (io_DecimalNumber - 1)) == 0;

            if (isPowerOf2) 
            {
                resIsPowerOf2 = 1;
            }

            return resIsPowerOf2;
        }

        public static void FindOrderOfNumbers(int io_DecimalNumber1, int io_DecimalNumber2, int io_DecimalNumber3, out int o_MinNumber, out int o_MidNumber, out int o_MaxNumber)
        {
            o_MinNumber = Math.Min(io_DecimalNumber1, Math.Min(io_DecimalNumber2, io_DecimalNumber3));
            o_MaxNumber = Math.Max(io_DecimalNumber1, Math.Max(io_DecimalNumber2, io_DecimalNumber3));
            o_MidNumber = io_DecimalNumber1 + io_DecimalNumber2 + io_DecimalNumber3 - o_MinNumber - o_MaxNumber;
        }
    }
}
