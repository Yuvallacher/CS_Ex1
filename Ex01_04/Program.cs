using System;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        public const int k_lengthOfInput = 10;
        
        public static void Main()
        {
            StringBuilder userInput = getUserInput();
            isPalindrome(new StringBuilder(userInput.ToString()));
            isDividableByFour(userInput);
            checkNumberOfLowercaseLetters(userInput);
        }

        private static StringBuilder getUserInput()
        {
            bool validInput;
            StringBuilder userInput = new StringBuilder(k_lengthOfInput);
            
            do
            {
                Console.WriteLine("Please enter a 10 character long input:");
                userInput.Append(Console.ReadLine());
                validInput = validateInput(userInput);
                if(!validInput)
                {
                    Console.WriteLine("Invalid input! Please try again");
                    userInput.Clear();
                }
            } while(!validInput);

            return userInput;
        }

        private static bool validateInput(StringBuilder i_UserInput)
        {
            bool lengthOfInputCorrect = i_UserInput.Length == k_lengthOfInput;
            bool containsLetters = false;
            bool containsNumbers = false;
            bool containsSymbols = false;

            for(int i = 0; i < i_UserInput.Length; i++)
            {
                if(Char.IsDigit(i_UserInput[i]))
                {
                    containsNumbers = true;
                }
                else if(Char.IsLetter(i_UserInput[i]))
                {
                    containsLetters = true;
                }
                else
                {
                    containsSymbols = true;
                }
            }

            return !(containsLetters && containsNumbers) && !containsSymbols && lengthOfInputCorrect;
        }

        private static void isPalindrome(StringBuilder i_StringToCheck)
        {
            bool palindrome = isPalindromeHelper(i_StringToCheck);

            if(palindrome)
            {
                Console.WriteLine("The string is a palindrome");
            }
            else
            {
                Console.WriteLine("The string is not a palindrome");
            }
        }

        private static bool isPalindromeHelper(StringBuilder i_StringToCheck)
        {
            bool result = true;

            if(i_StringToCheck.Length > 1)
            {
                if(i_StringToCheck[0] == i_StringToCheck[i_StringToCheck.Length - 1])
                {
                    i_StringToCheck.Remove(0, 1);
                    i_StringToCheck.Remove(i_StringToCheck.Length - 1, 1);
                    result = isPalindromeHelper(i_StringToCheck);
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        private static void isDividableByFour(StringBuilder i_StringToCheck)
        {
            bool isNumber = long.TryParse(i_StringToCheck.ToString(), out long stringAsNumber);

            if(isNumber)
            {
                if(stringAsNumber % 4 == 0)
                {
                    Console.WriteLine("The number {0} is dividable by 4", stringAsNumber);
                }
                else
                {
                    Console.WriteLine("The number {0} is not dividable by 4", stringAsNumber);
                }
            }
        }

        private static void checkNumberOfLowercaseLetters(StringBuilder i_StringToCheck)
        {
            int counterOfLowercaseLetters = 0;
            bool isNumber = long.TryParse(i_StringToCheck.ToString(), out _);

            if(!isNumber)
            {
                for(int i = 0; i < i_StringToCheck.Length; i++)
                {
                    if(Char.IsLower(i_StringToCheck[i]))
                    {
                        counterOfLowercaseLetters++;
                    }
                }

                string[] args = new string[2];
                args[0] = i_StringToCheck.ToString();
                args[1] = counterOfLowercaseLetters.ToString();
                Console.WriteLine("The string \"{0}\" contains {1} lowercase letters", args);
            }
        }
    }
}