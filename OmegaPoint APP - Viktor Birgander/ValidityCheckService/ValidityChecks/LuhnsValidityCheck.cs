using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidityCheckService.ValidityChecks;

namespace ValidityCheckService
{
    public class LuhnsValidityCheck : IValidityCheck
    {
        /// <summary>
        /// Checks if the provided string of digits
        /// is valid according to Luhn's Algorithm
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool CheckValidity(string number)
        {
            int total = 0;
            int multiplier = 2;

            foreach (char c in number)
            {
                //(c - '0') is the most efficient way to get the numeric value of the current character
                int multiplied = multiplier * (c - '0');
                //checks if the mulitplied number becomes a two digit number and deals with it according to Luhns if so.
                total = multiplied >= 10 ? total += (1 + (multiplied % 10)) : total += multiplied;
                multiplier = multiplier == 1 ? 2 : 1;
            }

            //If checksum is evenly divisible by 10 the control number is correct and the number is valid according to Luhns.
            return total % 10 == 0;
            
        }
    }
}
