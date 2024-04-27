using System;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder userInput = GetUserInput();
            IsPalindrome(new StringBuilder(userInput.ToString()));
            IsDividableByFour(userInput);
            CheckNumberOfLowercaseLetters(userInput);
        }

        public static StringBuilder GetUserInput()
        {
            bool validInput;
            StringBuilder userInput = new StringBuilder(10);
            
            do
            {
                Console.WriteLine("Please enter a 10 character long input:");
                userInput.Append(Console.ReadLine());
                validInput = ValidateInput(userInput);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input! Input should only contain either letters or numbers, but not simultaneously");
                    userInput.Clear();
                }
            } while (!validInput);

            return userInput;
        }

        public static bool ValidateInput(StringBuilder io_UserInput)
        {
            bool containsLetters = false;
            bool containsNumbers = false;
            bool containsSymbols = false;

            for (int i = 0; i < io_UserInput.Length; i++)
            {
                if (Char.IsDigit(io_UserInput[i]))
                {
                    containsNumbers = true;
                }
                else if (Char.IsLetter(io_UserInput[i]))
                {
                    containsLetters = true;
                }
                else
                {
                    containsSymbols = true;
                }
            }

            return !(containsLetters && containsNumbers) && !containsSymbols;
        }

        public static void IsPalindrome(StringBuilder i_StringToCheck)
        {
            bool palindrome = IsPalindromeHelper(i_StringToCheck);
            if (palindrome)
            {
                Console.WriteLine("The string is a palindrome");
            }
            else
            {
                Console.WriteLine("The string is not a palindrome");
            }
        }

        public static bool IsPalindromeHelper(StringBuilder i_StringToCheck)
        {
            bool result = true;

            if (i_StringToCheck.Length > 1)
            {
                if (i_StringToCheck[0] == i_StringToCheck[i_StringToCheck.Length - 1])
                {
                    i_StringToCheck.Remove(0, 1);
                    i_StringToCheck.Remove(i_StringToCheck.Length - 1, 1);
                    result = IsPalindromeHelper(i_StringToCheck);
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        public static void IsDividableByFour(StringBuilder i_StringToCheck)
        {
            bool isNumber = long.TryParse(i_StringToCheck.ToString(), out long stringAsNumber);
            if (isNumber)
            {
                if (stringAsNumber % 4 == 0)
                {
                    Console.WriteLine("The number {0} is dividable by 4", stringAsNumber);
                }
                else
                {
                    Console.WriteLine("The number {0} is not dividable by 4", stringAsNumber);
                }
            }
        }

        public static void CheckNumberOfLowercaseLetters(StringBuilder i_StringToCheck)
        {
            int counterOfLowercaseLetters = 0;
            bool isNumber = long.TryParse(i_StringToCheck.ToString(), out long stringAsNumber);
            if (!isNumber)
            {
                for (int i = 0; i < i_StringToCheck.Length; i++)
                {
                    if (Char.IsLower(i_StringToCheck[i]))
                    {
                        counterOfLowercaseLetters++;
                    }
                }

                string[] args = new string[2];
                args[0] = i_StringToCheck.ToString();
                args[1] = counterOfLowercaseLetters.ToString();
                Console.WriteLine(new StringBuilder(65).AppendFormat("The string \"{0}\" contains {1} lowercase letters", args));
            }
        }
    }
}