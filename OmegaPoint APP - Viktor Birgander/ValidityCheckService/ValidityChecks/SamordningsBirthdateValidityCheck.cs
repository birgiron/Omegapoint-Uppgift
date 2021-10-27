using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidityCheckService.ValidityChecks
{
    public class SamordningsBirthdateValidityCheck : BirthdateValidityCheck
    {
        /// <summary>
        /// Checks if the birthdate provided in a Samordningsnummer is a valid birthdate
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public override bool CheckValidity(string number)
        {
            int year = Int32.Parse(number.Substring(0, 2));
            int month = Int32.Parse(number.Substring(2, 2));
            int date = Int32.Parse(number.Substring(4, 2));

            bool validDateRange = date >= 61 && date <= 91;
            //remove 60 to normalize to a normal date.
            bool validBirthDate = IsValidBirthdate(year, month, date - 60);
            return validDateRange && validBirthDate;
        }
    }
}
