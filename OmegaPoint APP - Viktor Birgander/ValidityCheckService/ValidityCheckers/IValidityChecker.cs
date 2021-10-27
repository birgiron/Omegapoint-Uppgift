using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidityCheckService.ValidityCheckers
{
    public interface IValidityChecker
    {
        /// <summary>
        /// Runs all IValidityChecks associated with a ValidityChecker to determine if a string is a valid number of a type.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        bool AllChecksValid(string number);
    }
}
