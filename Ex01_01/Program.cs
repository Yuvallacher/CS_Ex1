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
            StringBuilder userInput = new StringBuilder(k_LengthOfBinaryNumber);

            do
            {
                userInput.Append(Console.ReadLine());
                validInputFromUser = CheckUserInput(userInput, out numFromUser);
                if(!validInputFromUser)
                {
                    Console.WriteLine("Invalid input!\nTry again");
                    userInput.Clear();
                }

            } while(!validInputFromUser);

            return numFromUser;
        }

        public static int ConvertBinaryToDecimal(int i_BinaryNumber)
        {
            int resDecNumber = 0, currentDigitInNumber, currentPower = 0;

            while(i_BinaryNumber > 0) 
            {
                currentDigitInNumber = i_BinaryNumber % 10;
                resDecNumber += currentDigitInNumber * (int)Math.Pow(2, currentPower);
                i_BinaryNumber /= 10;
                currentPower++;
            }

            return resDecNumber;
        }

        public static bool CheckUserInput(StringBuilder i_UserInput, out int o_NumFromUser)
        {
            bool validNumFromUser = int.TryParse(i_UserInput.ToString(), out o_NumFromUser);
            
            if(validNumFromUser)
            {
                if(i_UserInput.Length == k_LengthOfBinaryNumber)
                {
                    validNumFromUser = IsBinaryNumber(i_UserInput);
                }
                else
                {
                    validNumFromUser = false;
                }
            }

            return validNumFromUser;
        }

        public static bool IsBinaryNumber(StringBuilder i_UserInput)
        {
            bool validBinaryNumber = true;
            
            for(int i = 0; i < k_LengthOfBinaryNumber; i++)
            {
                if(i_UserInput[i] != '0' && i_UserInput[i] != '1')
                {
                    validBinaryNumber = false;
                }
            }

            return validBinaryNumber;
        }

        public static void CalcAvgNumberOfDigitsFromBinary(int i_BinaryNumber1, int i_BinaryNumber2, int i_BinaryNumber3)
        {
            float countOfZero = 0, countOfOne = 0;

            countOfZero += GetHowManyDigits(i_BinaryNumber1, k_Zero);
            countOfZero += GetHowManyDigits(i_BinaryNumber2, k_Zero);
            countOfZero += GetHowManyDigits(i_BinaryNumber3, k_Zero);
            countOfOne += GetHowManyDigits(i_BinaryNumber1, k_One);
            countOfOne += GetHowManyDigits(i_BinaryNumber2, k_One);
            countOfOne += GetHowManyDigits(i_BinaryNumber3, k_One);
            countOfZero /= k_AmountOfNumbers;
            countOfOne /= k_AmountOfNumbers;
            Console.WriteLine("The average size of digit zero is: {0} and of the digit one is: {1}", countOfZero, countOfOne);
        }

        public static float GetHowManyDigits(int i_BinaryNumber, int i_DigitToSearch)
        {
            int countOfDigitsInTheNumber = 0;

            for(int i = 0; i < k_LengthOfBinaryNumber; i++) 
            { 
                if(i_BinaryNumber % 10 == i_DigitToSearch)
                {
                    countOfDigitsInTheNumber++;
                }

                i_BinaryNumber /= 10;
            }

            return countOfDigitsInTheNumber;
        }

        public static void CalcUpSeries(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3)
        {
            int countOfUpSeries = IsUpSeries(i_DecimalNumber1) + IsUpSeries(i_DecimalNumber2) + IsUpSeries(i_DecimalNumber3);
           
            Console.WriteLine("Numbers that are an up series: {0}", countOfUpSeries);
        }

        public static int IsUpSeries(int i_DecimalNumber)
        {
            bool isUpSeries = true;
            int resIsUpSeries = 0, leastSignificantDigit = i_DecimalNumber % 10, currDigit;

            i_DecimalNumber /= 10;
            while(i_DecimalNumber > 0)
            {
                currDigit = i_DecimalNumber % 10;
                if(currDigit >= leastSignificantDigit)
                {
                    isUpSeries = false;
                }

                leastSignificantDigit = currDigit;
                i_DecimalNumber /= 10;
            }

            if(isUpSeries)
            {
                resIsUpSeries = 1;
            }

            return resIsUpSeries;
        }

        public static void CalcHowManyArePowerOf2(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3)
        {
            int countOfNumbersPowerOf2 = IsPowerOf2(i_DecimalNumber1) + IsPowerOf2(i_DecimalNumber2) + IsPowerOf2(i_DecimalNumber3);
            
            Console.WriteLine("Numbers that are a power of 2: {0}", countOfNumbersPowerOf2);
        }

        public static int IsPowerOf2(int i_DecimalNumber)
        {
            int resIsPowerOf2 = 0;
            bool isPowerOf2 = i_DecimalNumber > 0 && (i_DecimalNumber & (i_DecimalNumber - 1)) == 0;

            if(isPowerOf2) 
            {
                resIsPowerOf2 = 1;
            }

            return resIsPowerOf2;
        }

        public static void FindOrderOfNumbers(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3, out int o_MinNumber, out int o_MidNumber, out int o_MaxNumber)
        {
            o_MinNumber = Math.Min(i_DecimalNumber1, Math.Min(i_DecimalNumber2, i_DecimalNumber3));
            o_MaxNumber = Math.Max(i_DecimalNumber1, Math.Max(i_DecimalNumber2, i_DecimalNumber3));
            o_MidNumber = i_DecimalNumber1 + i_DecimalNumber2 + i_DecimalNumber3 - o_MinNumber - o_MaxNumber;
        }
    }
}
