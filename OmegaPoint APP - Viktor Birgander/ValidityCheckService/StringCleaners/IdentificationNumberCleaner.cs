using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidityCheckService.StringCleaners
{
    public class IdentificationNumberCleaner
    {
        /// <summary>
        /// Cleans a string of all non-numeric characters
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string CleanString(string number)
        {
            //Removes all non-numeric characters from the string
            string onlyNumbersString = new string(number.Where(c => char.IsDigit(c)).ToArray());

            if (onlyNumbersString.Length < 10 || onlyNumbersString.Length > 12)
                throw new ArgumentOutOfRangeException();

            //Removes the initial two digits if provided number was in 12 digit format
            if (onlyNumbersString.Length > 10)
            {
                string shortenedString = onlyNumbersString.Substring(2, onlyNumbersString.Length - 2);
                return shortenedString;
            }
            return onlyNumbersString;
        }
    }
}
