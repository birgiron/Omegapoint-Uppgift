using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidityCheckService.ValidityChecks;

namespace ValidityCheckService.ValidityCheckers
{
    public abstract class ValidityChecker : IValidityChecker
    {
        /// <summary>
        /// Performs a number of validity checks to determine if a string is valid.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public abstract bool AllChecksValid(string number);

        /// <summary>
        /// Runs provided validityCheck on provided string.
        /// </summary>
        /// <param name="validityCheck"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        protected bool RunValidityCheck(IValidityCheck validityCheck, string number)
        {
            if (!validityCheck.CheckValidity(number))
            {
                Console.WriteLine($"{validityCheck.GetType().Name} failed.");
                return false;
            }
            return true;
        }
    }
}
