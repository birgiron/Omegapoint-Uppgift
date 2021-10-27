using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidityCheckService.StringCleaners;
using ValidityCheckService.ValidityChecks;

namespace ValidityCheckService.ValidityCheckers
{
    public class OrganisationsNummerValidityChecker : ValidityChecker
    {
        private FormatValidityCheck formatValidityCheck = new(new char[]{'-'});
        private CenturyValidityCheck centuryValidityCheck = new(new int[] {16});
        private OrganisationsMidNumberValidityCheck organisationsMidNumberValidityCheck = new();
        private LuhnsValidityCheck luhnsValidityCheck = new();
        private IdentificationNumberCleaner identificationNumberCleaner = new();

        /// <summary>
        /// Runs all necessary checks to determine if a provided number is a valid Organisationsnummer
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public override bool AllChecksValid(string number)
        {
            if (!RunValidityCheck(formatValidityCheck, number))
                return false;

            //If number is a 12 digit format e.g. provides a century
            if(number.Length > 11)
            {
                if (!RunValidityCheck(centuryValidityCheck, number))
                    return false;
            }

            string cleanedNumber = identificationNumberCleaner.CleanString(number);
            return RunValidityCheck(organisationsMidNumberValidityCheck, cleanedNumber) && RunValidityCheck(luhnsValidityCheck, cleanedNumber);
        }
    }
}
