using FileCabinetLib.Interfaces;

namespace FileCabinetLib.Helper
{
    /// <summary>
    /// Implements search by firstname.
    /// </summary>
    public class FindByFirstName : IFinder<Person>
    {
        private string firstName;

        /// <summary>
        /// Initializes a new instance of the FindByFirstName class.
        /// </summary>
        /// <param name="surname">Person's firstname.</param>
        public FindByFirstName(string name)
        {
            firstName = name;
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

            if (obj.FirstName.ToLower().Replace(" ", "").Equals(this.firstName))
                return true;

            return false;
        }
    }
}
