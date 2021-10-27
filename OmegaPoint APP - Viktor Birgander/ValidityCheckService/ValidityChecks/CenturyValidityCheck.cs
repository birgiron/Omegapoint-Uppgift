using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidityCheckService.ValidityChecks
{
    public class CenturyValidityCheck : IValidityCheck
    {
        private int[] _allowedCenturies;
        public CenturyValidityCheck(int[] allowedCenturies)
        {
            _allowedCenturies = allowedCenturies;
        }

        /// <summary>
        /// Checks the validity of provided century if a century was provided
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool CheckValidity(string number)
        {
            int century = Int32.Parse(number.Substring(0, 2));
            return _allowedCenturies.Contains(century);
        }
    }
}
