using System;
using System.Linq;
using System.Collections.Generic;

namespace CanBePalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string to check whether it can be palindrome or not?");
            string stringToCheck = Console.ReadLine();
            var canBePalindrome = canBePalindromAfterRearranging(stringToCheck);
            Console.WriteLine($" {stringToCheck}'s characters  can be rearranged to form a palindrome? {canBePalindrome} ");

            Console.ReadLine();
        }

        static bool canBePalindromAfterRearranging(string inputString)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(inputString) && inputString.Trim().Length >= 1 && inputString.Trim().Length <= 50)
            {

                Dictionary<char, int> charCount = new Dictionary<char, int>();
                var distinctCharacters = inputString.ToLower().Distinct();
                var stringInLowerCase = inputString.ToLower();

                foreach (char c in distinctCharacters)
                {
                    var cnt = stringInLowerCase.Count(ch => ch == c);
                    charCount.Add(c, cnt);
                }

                var numberOfCharactersOddNumberOfTimes = charCount.Count(item => item.Value % 2 != 0);

                result = numberOfCharactersOddNumberOfTimes <= 1;

            }
            else
            {
                throw new ArgumentOutOfRangeException($" Length of {nameof(inputString)} is invalid");
            }
            return result;
        }
    }
}
