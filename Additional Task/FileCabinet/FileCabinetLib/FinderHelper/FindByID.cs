using FileCabinetLib.Interfaces;
using System;

namespace FileCabinetLib.Helper
{
    /// <summary>
    /// Implements search by ID.
    /// </summary>
    public class FindByID : IFinder<Person>
    {
        private string id;

        /// <summary>
        /// Initializes a new instance of the FindByID class.
        /// </summary>
        /// <param name="surname">Person's id.</param>
        public FindByID(string id)
        {
            this.id = id;
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

            try
            {
                if (obj.ID == long.Parse(id))
                    return true;
            }
            catch (InvalidCastException)
            {
                return false;
            }

            return false;
        }
    }
}
