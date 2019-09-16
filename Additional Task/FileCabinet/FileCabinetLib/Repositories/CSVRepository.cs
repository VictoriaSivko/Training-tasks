using System.Collections.Generic;
using FileCabinetLib.Interfaces;
using System.IO;
using System;
using NLog;

namespace FileCabinetLib.Repositories
{
    /// <summary>
    /// CSV repository.
    /// </summary>
    public class CSVRepository : IRepository<Person>
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets name (path) of the file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the CSVRepository class.
        /// </summary>
        /// <param name="name">Name (path) of the file.</param>
        public CSVRepository(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Reads data from a csv file.
        /// </summary>
        /// <returns>List of the Persons.</returns>
        public List<Person> Reade()
        {
            logger.Trace("Started reading from CSV file.");

            using (FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fs, System.Text.Encoding.Default))
                {
                    List<Person> temp = new List<Person>();
                    string record;
                    while ((record = streamReader.ReadLine()) != null)
                    {
                        var words = record.Split(new char[] { ';' }, 4);
                        temp.Add(new Person(words[1], words[2], Convert.ToDateTime(words[3]), long.Parse(words[0])));
                    }

                    if (temp.Count < 1)
                    {
                        logger.Warn($"{Name}.csv file is empty.");
                        Console.WriteLine($"{Name} file is empty.");
                    }
                    else
                        Console.WriteLine("Operation completed successfully.");

                    logger.Trace("Ended reading from CSV file.");
                    return temp;
                }
            }
        }

        /// <summary>
        /// Writes data to a csv file.
        /// </summary>
        /// <param name="list">Data to be recorded.</param>
        public void Write(List<Person> list)
        {
            logger.Trace("Started writing to csv file.");

            using (FileStream fs = new FileStream($"{Name}.csv", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (Person person in list)
                        sw.WriteLine($"{person.ID};{person.FirstName};{person.LastName};{person.DateOfBirth}");
                }

                Console.WriteLine("Operation completed successfully.");
            }

            logger.Trace("Ended writing to csv file.");
        }
    }
}
