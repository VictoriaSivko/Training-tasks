using System.Text;
using System.Collections.Generic;
using NLog;
using System;
using FileCabinetLib.Interfaces;
using System.Linq;
using FileCabinetLib.Helper;

namespace FileCabinetLib
{
    /// <summary>
    /// Class for working with Person objects.
    /// </summary>
    public class PersonService: IService<Person>
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets the list of the Persons.
        /// </summary>
        public List<Person> People { get; private set; }

        /// <summary>
        /// Gets count of Persons in People list.
        /// </summary>
        public int Count { get { return People.Count; } }

        /// <summary>
        /// Initializes a new instance of the PersonService class.
        /// </summary>
        public PersonService()
        {
            logger.Trace("Default initialization of PersonServise object.");
            People = new List<Person>();
        }

        /// <summary>
        /// Initializes a new instance of the PersonService class.
        /// </summary>
        /// <param name="people">List of the persons.</param>
        public PersonService(List<Person> people)
        {
            if (people != null)
            {
                logger.Trace("Initializing PersonService object.");
                People = people;
            }  
            else
            {
                logger.Trace("Default initialization of PersonServise object.");
                People = new List<Person>();
            }
                
        }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="index">Index of the object in the People list.</param>
        /// <returns>Person oblect.</returns>
        public Person this[int index]
        {
            get
            {
                return People[index];
            }
            set
            {
                if (index <= 0 || People.Count < index)
                    Console.WriteLine("Not found the mutable object."); 
                else if (value == null)
                    Console.WriteLine("Object has not been modified.");
                else
                {
                    logger.Debug($"{People[index - 1].ToString()} was changed to {value}");
                    People[index - 1] = value;
                    Console.WriteLine("Changes successfully saved.");
                }
            }
        }

        /// <summary>
        /// Returns a string representation of People according to the selected fields.
        /// </summary>
        /// <param name="criterion">Array of field names.</param>
        /// <returns>String representation of People.</returns>
        public string ListByCriterion(string[] criterion)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int item = 0; item < People.Count; item++)
            {
                for (int i = 0; i < criterion.Length; i++)
                {
                    switch (criterion[i])
                    {
                        case "firstname":
                            stringBuilder.Append($"{People[item].FirstName}, "); break;
                        case "lastname":
                            stringBuilder.Append($"{People[item].LastName}, "); break;
                        case "id":
                            stringBuilder.Append($"{People[item].ID}, "); break;
                        case "dateofbirth":
                        case "birth":
                        case "date":
                            stringBuilder.Append($"{People[item].DateOfBirth.Date.ToString("d")}, "); break;
                        default:
                            stringBuilder.Append($"unknown field, "); break;
                    }
                }
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Adds new person in People.
        /// </summary>
        /// <param name="person">Person object.</param>
        public void Add(Person person)
        {
            if (person != null && !People.Contains(person))
            {
                foreach (Person p in People)
                {
                    if (p.Equals(person))
                    {
                        Console.WriteLine($"Person with id = {p.ID} exist.");
                        logger.Warn("Person has not been added to the People list.");
                        return;
                    }
                }

                logger.Debug("Person has been added to the People list.");
                People.Add(person);
            }
            else
            {
                logger.Warn("Person has not been added to the People list.");
            }
        }

        /// <summary>
        /// Removes person by index.
        /// </summary>
        /// <param name="index">Index of the Person in list.</param>
        public void Remove(int index)
        {
            if (index <= 0 || this.Count < index)
            {
                logger.Debug("Person has not been removed.");
                Console.WriteLine("Not found the mutable object.");
                return;
            }

            logger.Debug($"Person {People[index-1].ToString()} has been removed.");
            People.RemoveAt(index-1);
            Console.WriteLine($"Record #{index} is removed.");
        }

        /// <summary>
        /// Searches for Person records that match the criteria.
        /// </summary>
        /// <param name="criteria">Search criterion.</param>
        public void FindByTag(string[] criteria)
        {
            List<Person> temp = People.ToList();

            for (int i = 0; i< criteria.Length; i++)
            {
                string data = criteria[i].Replace("'", "");

                if (data.Contains("firstname"))
                {
                    data = data.Replace("firstname", "");
                    temp = FindByTag(new FindByFirstName(data), temp);
                }
                else if (data.Contains("lastname"))
                {
                    data = data.Replace("lastname", "");
                    temp = FindByTag(new FindByLastName(data), temp);
                }
                else if (data.Contains("id"))
                {
                    data = data.Replace("id", "");
                    temp = FindByTag(new FindByID(data), temp);
                }
                else if (data.Contains("dateofbirth"))
                {
                    data = data.Replace("dateofbirth", "");
                    temp = FindByTag(new FindByID(data), temp);
                }
                else
                {
                    Console.Write($"Error: search criterion {criteria[i]} don't exist. \nFiltering will not be performed by this criterion.\n");
                }
            }

            if (temp.Count < 1)
            {
                Console.WriteLine("The corresponding records is not found.");
            }
                
            for (int i = 0; i < temp.Count; i++)
                Console.WriteLine($"#{i+1} {temp[i]}");
        }

        /// <summary>
        /// Searches for Person records that match the criteria.
        /// </summary>
        /// <param name="finder">Search algorithm.</param>
        /// <param name="people">Initial Person's list for filtering.</param>
        /// <returns>Filtered Person's list.</returns>
        public List<Person> FindByTag(IFinder<Person> finder, List<Person> people = null)
        {

            if (finder == null)
            {
                Console.WriteLine("No search criteria specified.");
                return null;
            }

            if (people == null)
                people = People.ToList();

            for (int i = 0; i < people.Count; i++)
            {
                if (!finder.Find(people[i]))
                    people.Remove(people[i]);
            }

            return people;
        }

        /// <summary>
        /// Replaces the Person object with a new one.
        /// </summary>
        /// <param name="index">Index of the replaced object.</param>
        /// <param name="person">new Person object.</param>
        public void Edit (int index, Person person)
        {
            this[index] = person;
        }

        /// <summary>
        /// Writes data to a file.
        /// </summary>
        /// <param name="repository">Type of repository.</param>
        public void Write(IRepository<Person> repository)
        {
            repository.Write(People);
        }

        /// <summary>
        /// Reads data from a file.
        /// </summary>
        /// <param name="repository">Type of repository.</param>
        public void Read(IRepository<Person> repository)
        {
            List<Person> temp = repository.Reade();

            foreach (Person p in temp)
                this.Add(p);   
        }

        /// <summary>
        /// Cleans People list.
        /// </summary>
        public void Clear()
        {
            People.Clear();
            logger.Debug("People list has been cleaned");
        }

        /// <summary>
        /// Returns string representation of the Person's list (People).
        /// </summary>
        /// <returns>String representation of the Person's list (People).</returns>
        public override string ToString()
        {
            if(People.Count == 0)
                return "The list of people is empty\n";

            StringBuilder stringBuilder = new StringBuilder();

            for(int i = 0; i < People.Count; i++)
               stringBuilder.Append($"#{i+1} {People[i].ToString()}\n");

            return stringBuilder.ToString();
        }
    }
}
