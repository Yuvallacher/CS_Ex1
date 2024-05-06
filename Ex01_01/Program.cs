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
            binaryNumber1 = getUserInput();
            binaryNumber2 = getUserInput();
            binaryNumber3 = getUserInput();
            decimalNumber1 = convertBinaryToDecimal(binaryNumber1);
            decimalNumber2 = convertBinaryToDecimal(binaryNumber2);
            decimalNumber3 = convertBinaryToDecimal(binaryNumber3);
            findOrderOfNumbers(decimalNumber1, decimalNumber2, decimalNumber3, out minNumber, out midNumber, out maxNumber);
            Console.WriteLine("The numbers are {0}, {1}, {2}", minNumber, midNumber, maxNumber);
            calcAvgNumberOfDigitsFromBinary(binaryNumber1, binaryNumber2, binaryNumber3);
            calcHowManyArePowerOf2(decimalNumber1, decimalNumber2, decimalNumber3);
            calcUpSeries(decimalNumber1, decimalNumber2, decimalNumber3);
            Console.WriteLine(
@"Biggest number: {0}
Smallest number: {1}", maxNumber, minNumber);
        }

        private static int getUserInput()
        {
            bool validInputFromUser;
            int numFromUser;
            StringBuilder userInput = new StringBuilder(k_LengthOfBinaryNumber);

            do
            {
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

        private static int convertBinaryToDecimal(int i_BinaryNumber)
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

        private static bool checkUserInput(StringBuilder i_UserInput, out int o_NumFromUser)
        {
            bool validNumFromUser = int.TryParse(i_UserInput.ToString(), out o_NumFromUser);
            
            if(validNumFromUser)
            {
                if(i_UserInput.Length == k_LengthOfBinaryNumber)
                {
                    validNumFromUser = isBinaryNumber(i_UserInput);
                }
                else
                {
                    validNumFromUser = false;
                }
            }

            return validNumFromUser;
        }

        private static bool isBinaryNumber(StringBuilder i_UserInput)
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

        private static void calcAvgNumberOfDigitsFromBinary(int i_BinaryNumber1, int i_BinaryNumber2, int i_BinaryNumber3)
        {
            float countOfZero = 0, countOfOne = 0;

            countOfZero += getHowManyDigits(i_BinaryNumber1, k_Zero);
            countOfZero += getHowManyDigits(i_BinaryNumber2, k_Zero);
            countOfZero += getHowManyDigits(i_BinaryNumber3, k_Zero);
            countOfOne += getHowManyDigits(i_BinaryNumber1, k_One);
            countOfOne += getHowManyDigits(i_BinaryNumber2, k_One);
            countOfOne += getHowManyDigits(i_BinaryNumber3, k_One);
            countOfZero /= k_AmountOfNumbers;
            countOfOne /= k_AmountOfNumbers;
            Console.WriteLine("The average size of digit zero is: {0} and of the digit one is: {1}", countOfZero, countOfOne);
        }

        private static float getHowManyDigits(int i_BinaryNumber, int i_DigitToSearch)
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

        private static void calcUpSeries(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3)
        {
            int countOfUpSeries = isUpSeries(i_DecimalNumber1) + isUpSeries(i_DecimalNumber2) + isUpSeries(i_DecimalNumber3);
           
            Console.WriteLine("Numbers that are an up series: {0}", countOfUpSeries);
        }

        private static int isUpSeries(int i_DecimalNumber)
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

        private static void calcHowManyArePowerOf2(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3)
        {
            int countOfNumbersPowerOf2 = isPowerOf2(i_DecimalNumber1) + isPowerOf2(i_DecimalNumber2) + isPowerOf2(i_DecimalNumber3);
            
            Console.WriteLine("Numbers that are a power of 2: {0}", countOfNumbersPowerOf2);
        }

        private static int isPowerOf2(int i_DecimalNumber)
        {
            int resIsPowerOf2 = 0;
            bool isPowerOf2 = i_DecimalNumber > 0 && (i_DecimalNumber & (i_DecimalNumber - 1)) == 0;

            if(isPowerOf2) 
            {
                resIsPowerOf2 = 1;
            }

            return resIsPowerOf2;
        }

        private static void findOrderOfNumbers(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3, out int o_MinNumber, out int o_MidNumber, out int o_MaxNumber)
        {
            o_MinNumber = Math.Min(i_DecimalNumber1, Math.Min(i_DecimalNumber2, i_DecimalNumber3));
            o_MaxNumber = Math.Max(i_DecimalNumber1, Math.Max(i_DecimalNumber2, i_DecimalNumber3));
            o_MidNumber = i_DecimalNumber1 + i_DecimalNumber2 + i_DecimalNumber3 - o_MinNumber - o_MaxNumber;
        }
    }
}
