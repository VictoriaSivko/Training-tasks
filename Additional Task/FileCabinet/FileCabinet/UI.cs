using NLog;
using System;
using FileCabinetLib;
using System.Globalization;
using System.Text.RegularExpressions;
using FileCabinetLib.Repositories;

namespace FileCabinet
{
    /// <summary>
    /// Represents the user interface of the application.
    /// </summary>
    public class UI
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private PersonService personService = new PersonService();

        /// <summary>
        /// A greeting to the user.
        /// </summary>
        static UI()
        {
            Console.WriteLine("Welcome to the file Cabinet!");
            Console.WriteLine("If you want to see a list of commands enter Info");
        }

        /// <summary>
        /// Processes user commands.
        /// </summary>
        public void WorkWithFileCabinet()
        {
            Console.Write("\nPlease enter your command:");
            
            while (true)
            {
                Console.Write("\n> ");
                string command = Console.ReadLine().ToLower();
                if (new Regex(@"^\s*info\s*$").IsMatch(command))
                {
                    logger.Trace("User command \"Info\"");
                    Console.WriteLine($"You can use the following commands: {CommandInfo()}");
                }
                else if (new Regex(@"^\s*create\s*$").IsMatch(command))
                {
                    logger.Trace("User command \"Create\"");
                    Person temp = CreatePerson();
                    if (temp != null)
                    {
                        personService.Add(temp);
                        Console.WriteLine($"Record #{personService.People.Count} is created.");
                    }
                    else
                    {
                        Console.WriteLine("Record was not created.");
                    }

                }
                else if (new Regex(@"^\s*list\s*$").IsMatch(command) || new Regex(@"^\s*list\s+(.*,?)+$").IsMatch(command))
                {
                    logger.Trace("User command \"List\"");
                    string criterion = Regex.Replace(command, @"^\s*list\s+", "").ToLower().Replace(" ", "");

                    if (string.IsNullOrWhiteSpace(criterion) || criterion.Equals("list"))
                        Console.Write(personService);
                    else
                    {
                        Console.WriteLine(personService.ListByCriterion(criterion.Split(new char[] { ',' })));
                    }
                }
                else if (new Regex(@"^\s*stat\s*$").IsMatch(command))
                {
                    logger.Trace("User command \"Stat\"");
                    Console.WriteLine(personService.Count + " records.");
                }
                else if (new Regex(@"^\s*find(\s+\w+\s+'\w+',?)+$").IsMatch(command))
                {
                    logger.Trace("User command \"Find\"");
                    string criterion = Regex.Replace(command, @"^\s*find\s+", "").ToLower().Replace(" ", "");

                    personService.FindByTag(criterion.Split(new char[] { ',' }));
                }
                else if (new Regex(@"^\s*edit\s+#[0-9]+\s*$").IsMatch(command))
                {
                    logger.Trace("User command \"Edit\"");
                    int index = Convert.ToInt32(Regex.Replace(command, @"^\s*edit\s+#", "").ToLower().Replace(" ", ""));

                    if (index <= 0 || personService.Count < index)
                    {
                        Console.WriteLine("Not found the mutable object.");
                        continue;
                    }

                    personService[index] = CreatePerson();
                }
                else if (new Regex(@"^\s*export\s+\w+\s*$").IsMatch(command))
                {
                    if (new Regex(@"^\s*export\s+csv\s*$").IsMatch(command))
                    {
                        logger.Trace("User command \"Export csv\"");
                        Console.WriteLine("The data will be appended to the end of the file.");
                        Console.Write("Please enter a filename: ");
                        string name = Wait();
                        personService.Write(new CSVRepository(name));
                    }
                    else if(new Regex(@"^\s*export\s+xml\s*$").IsMatch(command))
                    {
                        logger.Trace("User command \"Export xml\"");
                        Console.WriteLine("The file will be overwritten!");
                        Console.Write("Please enter a filename: ");
                        string name = Wait();
                        personService.Write(new XMLRepository(name));
                    }
                    else
                    {
                        logger.Trace("Invalid user command \"Export\"");
                        Console.WriteLine("Error: invalid file extension. Try again.");
                    }
                }
                else if (new Regex(@"^\s*import\s+\w+\s+\w+[.]\w+\s*$").IsMatch(command))
                {
                    if (new Regex(@"^\s*import\s+csv\s+\w+.csv\s*").IsMatch(command))
                    {
                        logger.Trace("User command \"Import csv\"");
                        string name = Regex.Replace(command, @"^\s*import\s+csv\s+", "").Replace(" ", "");
                        personService.Read(new CSVRepository(name));
                    }
                    else if (new Regex(@"^\s*import\s+xml\s+\w+.xml\s*").IsMatch(command))
                    {
                        logger.Trace("User command \"Import xml\"");
                        string name = Regex.Replace(command, @"^\s*import\s+xml\s+", "").Replace(" ", "");
                        personService.Read(new XMLRepository(name));
                    }
                    else
                    {
                        logger.Trace("Invalid user command \"Import\"");
                        Console.WriteLine("Invalid file extension. Plaese try again.");
                    }
                }
                else if (new Regex(@"^\s*remove\s+#[0-9]+\s*$").IsMatch(command))
                {
                    logger.Trace("User command \"Remove\"");
                    int index = Convert.ToInt32(Regex.Replace(command, @"^\s*remove\s+#", "").ToLower().Replace(" ", ""));
                    personService.Remove(index);
                }
                else if (new Regex(@"^\s*purge\s*$").IsMatch(command))
                {
                    logger.Trace("User command \"Purge\"");
                    personService.Clear();
                    Console.WriteLine("Purge is successful.");
                }
                else if (new Regex(@"^\s*exit\s*$").IsMatch(command))
                {
                    logger.Info("The user exits the application.");
                    Console.WriteLine("Dump records are created...");
                    personService.Write(new XMLRepository($@"{Environment.CurrentDirectory}\dump\{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}"));
                    break;
                }
                else
                {
                    logger.Trace("Invalid user command.");
                    Console.WriteLine("Error: сommand not found. Try again.");
                }
            }
        }

        /// <summary>
        /// Creates new Person instance.
        /// </summary>
        /// <returns>New Person instance.</returns>
        private Person CreatePerson()
        {
            Console.Write("First name: ");
            string name = Wait();
            Console.Write("Last name: ");
            string surnname = Wait();
            Console.Write("Date of birth: ");
            string date = Wait();

            DateTime dateTime;
            if (DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime))
            {
                return new Person(name, surnname, dateTime);
            }
            else
            {
                Console.WriteLine($"Error entering date. Try again.\nValid date format is dd/mm/yyyy");
                return null;
            }
        }

        /// <summary>
        /// Contains a list of commands.
        /// </summary>
        /// <returns>A list of commands.</returns>
        public static string CommandInfo()
        {
            return String.Format($"\n> create - adds a new person" +
                $"\n> list - shows all records" +
                $"\n> list <Fields> - shows the corresponding fields of the record" +
                $"\n> stat - shows the number of records" +
                $"\n> find <FieldName 'value'> - shows records that match the search criteria" +
                $"\n> edit #<RecordNamber> - allows to change the fields of the corresponding record" +
                $"\n> export <FileExtenesion> - writes data to the appropriate file" +
                $"\n> import <FileExtenesion> <FileName.FileExtension> - reads data from the appropriate file" +
                $"\n> remove #<RecordNamber> - вeletes the corresponding record" +
                $"\n> purge - removes all records" +
                $"\n> exit - closes the application.");
        }

        /// <summary>
        /// Waits for the user to enter the required data.
        /// </summary>
        /// <returns>Requested data.</returns>
        private string Wait()
        {
            string str = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(str))
            {
                Console.Write("> ");
                str = Console.ReadLine();
            }

            return str;
        }
    }
}
