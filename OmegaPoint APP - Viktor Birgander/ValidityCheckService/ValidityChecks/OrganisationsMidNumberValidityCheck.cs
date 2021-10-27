using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidityCheckService.ValidityChecks;

namespace ValidityCheckService
{
    public class OrganisationsMidNumberValidityCheck : IValidityCheck
    {
        /// <summary>
        /// Checks the validity of the middle number of an organisationsnummer
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool CheckValidity(string number)
        {
            int middleNumber = Int32.Parse(number.Substring(2, 2));
            return middleNumber >= 20;
        }
    }
}
