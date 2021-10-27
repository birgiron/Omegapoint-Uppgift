using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidityCheckService.ValidityChecks
{
    public class FormatValidityCheck : IValidityCheck
    {
        private char[] _separators;

        public FormatValidityCheck(char[] separators)
        {
            _separators = separators;
        }

        /// <summary>
        /// Checks the validity of the format of a string for identification numbers.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool CheckValidity(string number)
        {
            //If the length is 10 or 12 it cannot contain a separator and be valid
            if(number.Length == 10 || number.Length == 12)
            {
                return AreCharsDigits(number);
            }

            //If the length is 11 or 13 it has to contain a separator to be valid
            if (number.Length == 11 || number.Length == 13)
            {
                return AreAllCharactersCorrect(number);
            }

            //In all other cases we have an invalid number
            return false;
        }

        //Controls if all characters of a string are digits
        private bool AreCharsDigits(string number)
        {
            return number.All(c => Char.IsDigit(c));
        }

        //Goes through the entire string to control that the correct type of characters are in the correct places
        private bool AreAllCharactersCorrect(string number)
        {
            //A valid separator is always at position number.Length-5
            int validSeparatorIndex = number.Length - 5;

            //If the character at index validSeparatorIndex of number is not one of the valid separators, returns false
            if (!_separators.Contains(number[validSeparatorIndex]))
                return false;

            string beforeSeparator = number.Substring(0, number.Length - 6);
            string afterSeparator = number.Substring(number.Length - 4, 4);

            //As the separator is valid, we control the rest of characters in the string
            if (!AreCharsDigits(beforeSeparator) || !AreCharsDigits(afterSeparator))
                return false;

            return true;
        }

    }
}
