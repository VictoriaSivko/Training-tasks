using FileCabinetLib.Interfaces;
using System;
using System.Globalization;

namespace FileCabinetLib.Helper
{
    /// <summary>
    /// Implements search by birthday.
    /// </summary>
    public class FindByBirthDate : IFinder<Person>
    {
        private string date;

        /// <summary>
        /// Initializes a new instance of the FindByBirthDate class.
        /// </summary>
        /// <param name="surname">Person's birthday.</param>
        public FindByBirthDate(string date)
        {
            this.date = date;
        }

        /// <summary>
        /// Checks for compliance with the criterion of Person.
        /// </summary>
        /// <param name="obj">Person.</param>
        /// <returns>Сheck result.</returns>
        public bool Find(Person obj)
        {
            if (obj == null)
                return false;

            DateTime dateTime;

            if (DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime))
            {
                if (obj.DateOfBirth == dateTime)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}
