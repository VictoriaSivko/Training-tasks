using FileCabinetLib.Interfaces;

namespace FileCabinetLib.Helper
{
    /// <summary>
    /// Implements search by lastname.
    /// </summary>
    public class FindByLastName : IFinder<Person>
    {
        private string lastName;

        /// <summary>
        /// Initializes a new instance of the FindByLastName class.
        /// </summary>
        /// <param name="surname">Person's lastname.</param>
        public FindByLastName(string surname)
        {
            lastName = surname;
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

            if (obj.LastName.ToLower().Replace(" ","").Equals(this.lastName))
                return true;

            return false;
        }
    }
}
