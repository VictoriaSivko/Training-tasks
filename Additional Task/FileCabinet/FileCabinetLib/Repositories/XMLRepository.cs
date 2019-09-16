using System.Collections.Generic;
using FileCabinetLib.Interfaces;
using System.IO;
using System.Xml.Serialization;
using System;
using NLog;

namespace FileCabinetLib.Repositories
{
    /// <summary>
    /// XML repository.
    /// </summary>
    public class XMLRepository : IRepository<Person>
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets name (path) of the file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the XMLRepository class.
        /// </summary>
        /// <param name="name">Name (path) of the file.</param>
        public XMLRepository(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Deserializes data from a xml file.
        /// </summary>
        /// <returns>List of the Persons.</returns>
        public List<Person> Reade()
        {
            logger.Trace("Started reading from XML file.");
            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));

            using (FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    List<Person> temp = (List<Person>)formatter.Deserialize(fs);

                    if (temp.Count < 1)
                    {
                        logger.Warn($"{Name}.xml file is empty.");
                        Console.WriteLine($"{Name} file is empty.");
                    }  
                    else
                        Console.WriteLine("Operation completed successfully.");

                    logger.Trace("Ended reading from XML file.");
                    return temp;
                }
                catch (InvalidOperationException ex)
                {
                    logger.Warn($"{Name}.xml file is empty.");
                    logger.Error(ex.StackTrace);
                    logger.Trace("Ended reading from XML file.");
                    Console.WriteLine($"{Name} file is empty.");
                    return new List<Person> ();
                }
            }
        }

        /// <summary>
        /// Serializes data to a xml file.
        /// </summary>
        /// <param name="list">Data to be serialized.</param>
        public void Write(List<Person> list)
        {
            logger.Trace("Started writing to xml file.");
            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));

            using (FileStream fs = new FileStream($"{Name}.xml", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, list);
                Console.WriteLine("Operation completed successfully.");
            }

            logger.Trace("Ended writing to xml file.");
        }
    }
}
