using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidityCheckService.ValidityChecks
{
    public interface IValidityCheck
    {
        /// <summary>
        /// Runs a ValidityCheck for a provided string
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool CheckValidity(string number);
    }
}
