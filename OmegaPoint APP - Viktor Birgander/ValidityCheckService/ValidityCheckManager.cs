using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidityCheckService.ValidityCheckers;

namespace ValidityCheckService
{
    public class ValidityCheckManager
    {
        private IValidityChecker _validityChecker;

        public ValidityCheckManager(IValidityChecker validityChecker)
        {
            _validityChecker = validityChecker;
        }

        /// <summary>
        /// Validates a string input by using the managers IValidityChecker
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool Validate(string input)
        {
            return _validityChecker.AllChecksValid(input);
        }
    }
}
