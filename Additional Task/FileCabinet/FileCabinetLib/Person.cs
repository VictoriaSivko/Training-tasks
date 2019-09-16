using System;
using NLog;

namespace FileCabinetLib
{
    /// <summary>
    /// Person card.
    /// </summary>
    [Serializable]
    public class Person
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;

        /// <summary>
        /// Gets or sets the person id.
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    firstName = value;
                else
                {
                    logger.Warn("Default first name.");
                    firstName = "FirstNameDef";
                }
            }
        }

        /// <summary>
        /// Gets or sets the surname of the person.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    lastName = value;
                else
                {
                    logger.Warn("Default last name.");
                    lastName = "LastNameDef";
                }
            }
        }

        /// <summary>
        /// Gets or sets the person's birthday.
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return dateOfBirth.Date; }
            set
            {
                if (value > DateTime.Now)
                {
                    logger.Warn("Default Date Of Birth.");
                    dateOfBirth = DateTime.Today;
                }
                else
                {
                    dateOfBirth = value;
                }               
            }
        }

        /// <summary>
        /// Initializes a new instance of the Person class.
        /// </summary>
        public Person()
        {
            logger.Trace("Person default constryctor.");
        }

        /// <summary>
        /// Initializes a new instance of the Person class.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="surname">Surname of the person.</param>
        /// <param name="dateOfBirth">Person's birthday.</param>
        /// <param name="id">Person's id.</param>
        public Person(string name, string surname, DateTime dateOfBirth, long id = 0)
        {
            logger.Trace("Initializing the fields of the Person object.");
            FirstName = name;
            LastName = surname;
            DateOfBirth = dateOfBirth;
            if (id == 0)
                ID = DateTime.Now.Millisecond + this.dateOfBirth.Second;
            else
                ID = id;
        }

        /// <summary>
        /// Compares Person objects.
        /// </summary>
        /// <param name="person">Person object</param>
        /// <returns>True - if objects are equal, false otherwise.</returns>
        public bool Equals(Person person)
        {
            return this.ID == person.ID ? true : false;
        }

        /// <summary>
        /// Returns string representation of the person card.
        /// </summary>
        /// <returns>String representation of the person card.</returns>
        public override string ToString()
        {
            return String.Format($"{firstName}, {lastName}");
        }
    }
}
