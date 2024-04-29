using System;
using System.Text;

namespace Ex01_01
{
    public class Program
    {   
        public const int k_SizeOfNum = 3;
        public const int k_LenOfBinaryNumber = 9; 
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
            decimalNumber1 = ConvertBinToDec(binaryNumber1);
            decimalNumber2 = ConvertBinToDec(binaryNumber2);
            decimalNumber3 = ConvertBinToDec(binaryNumber3);
            FindOrderOfNumbers(decimalNumber1, decimalNumber2, decimalNumber3, out minNumber, out midNumber, out maxNumber);
            Console.WriteLine("The numbers are {0}, {1}, {2}", minNumber, midNumber, maxNumber);
            CalcAvgNumOfDigsFromBin(binaryNumber1, binaryNumber2, binaryNumber3);
            CalcHowManyAreStrongOf2(decimalNumber1, decimalNumber2, decimalNumber3);
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
        public static int ConvertBinToDec(int io_BinNum)
        {
            int resDecNumber = 0, currentDigitInNumber, currentPower = 0;
            while(io_BinNum > 0) 
            {
                currentDigitInNumber = io_BinNum % 10;
                resDecNumber += currentDigitInNumber * (int)Math.Pow(2, currentPower);
                io_BinNum /= 10;
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
                    validNumFromUser = IsBinNumber(io_UserInput);
                }
                else
                {
                    validNumFromUser = false;
                }
            }

            return validNumFromUser;
        }

        public static bool IsBinNumber(StringBuilder io_UserInput)
        {
            bool validBinNum = true;
            
            for (int i = 0; i < k_LenOfBinaryNumber; i++)
            {
                if (io_UserInput[i] != '0' && io_UserInput[i] != '1')
                {
                    validBinNum = false;
                }
            }

            return validBinNum;
        }

        public static void CalcAvgNumOfDigsFromBin(int io_BinNum1, int io_BinNum2, int io_BinNum3)
        {
            float numOfZero = 0, numOfOne = 0;

            numOfZero += GetHowManyDigs(io_BinNum1, k_Zero);
            numOfZero += GetHowManyDigs(io_BinNum2, k_Zero);
            numOfZero += GetHowManyDigs(io_BinNum3, k_Zero);
            numOfOne += GetHowManyDigs(io_BinNum1, k_One);
            numOfOne += GetHowManyDigs(io_BinNum2, k_One);
            numOfOne += GetHowManyDigs(io_BinNum3, k_One);
            numOfZero /= k_SizeOfNum;
            numOfOne /= k_SizeOfNum;
            Console.WriteLine("The average size of digit zero is: {0} and of the digit one is: {1}", numOfZero, numOfOne);
        }

        public static float GetHowManyDigs(int io_BinNum, int i_DigitToSearch)
        {
            int sumOfDigitsInTheNumber = 0;

            for (int i = 0; i < k_LenOfBinaryNumber; i++) 
            { 
                if (io_BinNum % 10 == i_DigitToSearch)
                {
                    sumOfDigitsInTheNumber++;
                }

                io_BinNum /= 10;
            }

            return sumOfDigitsInTheNumber;
        }

        public static void CalcUpSeries(int io_DecNum1, int io_DecNum2, int io_DecNum3)
        {
            int sumOfUpSeries = IsUpSeries(io_DecNum1) + IsUpSeries(io_DecNum2) + IsUpSeries(io_DecNum3);
           
            Console.WriteLine("Numbers that are an up series: {0}", sumOfUpSeries);
        }

        public static int IsUpSeries(int io_DecNum)
        {
            bool isUpSeries = true;
            int resIsUpSeries = 0, lastDig = io_DecNum % 10, currDigit;
            
            io_DecNum /= 10;
            while (io_DecNum > 0)
            {
                currDigit = io_DecNum % 10;
                if (currDigit >= lastDig)
                {
                    isUpSeries = false;
                }

                lastDig = currDigit;
                io_DecNum /= 10;
            }

            if (isUpSeries)
            {
                resIsUpSeries = 1;
            }

            return resIsUpSeries;
        }

        public static void CalcHowManyAreStrongOf2(int io_DecNum1, int io_DecNum2, int io_DecNum3)
        {
            int countOfNumsStrongOf2 = IsStrongOf2(io_DecNum1) + IsStrongOf2(io_DecNum2) + IsStrongOf2(io_DecNum3);
            
            Console.WriteLine("Numbers that are a power of 2: {0}", countOfNumsStrongOf2);
        }

        public static int IsStrongOf2(int io_DecNum)
        {
            int resIsStrongOf2 = 0;
            bool isStrongOf2 = io_DecNum > 0 && (io_DecNum & (io_DecNum - 1)) == 0;

            if (isStrongOf2) 
            {
                resIsStrongOf2 = 1;
            }

            return resIsStrongOf2;
        }

        public static void FindOrderOfNumbers(int io_DecNum1, int io_DecNum2, int io_DecNum3, out int o_MinNumber, out int o_MidNumber, out int o_MaxNumber)
        {
            o_MinNumber = Math.Min(io_DecNum1,Math.Min(io_DecNum2, io_DecNum3));
            o_MaxNumber = Math.Max(io_DecNum1,Math.Max(io_DecNum2, io_DecNum3));
            o_MidNumber = io_DecNum1 + io_DecNum2 + io_DecNum3 - o_MinNumber - o_MaxNumber;
        }
    }
}
