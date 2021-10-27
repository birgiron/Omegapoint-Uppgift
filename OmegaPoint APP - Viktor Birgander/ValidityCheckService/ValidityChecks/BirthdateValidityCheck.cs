using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidityCheckService.ValidityChecks;

namespace ValidityCheckService
{
    public class BirthdateValidityCheck : IValidityCheck
    {
        /// <summary>
        /// Checks the validity of the födelsedatum in provided string
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public virtual bool CheckValidity(string number)
        {
            int year = Int32.Parse(number.Substring(0, 2));
            int month = Int32.Parse(number.Substring(2, 2));
            int date = Int32.Parse(number.Substring(4, 2));
            return IsValidBirthdate(year, month, date);
        }

        /// <summary>
        /// Checks if the provided födelsedatum made up by parameters year, month and date
        /// is a valid Födelsedatum
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        protected bool IsValidBirthdate(int year, int month, int date)
        {
            return ((IsValidMonth(month) && IsValidDate(date, month)) || IsLeapDay(year, month, date));
        }

        private bool IsValidDate(int date, int month)
        {
            return date <= GetDaysForMonth(month);
        }

        private bool IsValidMonth(int month)
        {
            return month >= 1 && month <= 12;
        }

        private bool IsValidYear(int year)
        {
            return year > 18 && year < 21;
        }

        //Returns the amount of days a month has a non-leap year
        private int GetDaysForMonth(int month)
        {
            switch (month)
            {
                case 1: return 31;
                case 2: return 28;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        //Evaluates if provided födelsedatum is a valid leap day
        private bool IsLeapDay(int year, int month, int date)
        {
            return IsValidYear(year) && year % 4 == 0 && month == 2 && date == 29;
        }
    }
}
