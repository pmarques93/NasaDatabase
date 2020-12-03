using System;
using System.Collections.Generic;
using System.Reflection;

namespace AstroFinder
{
    /// <summary>
    /// Class that implements IUserInterface
    /// </summary>
    public class ConsoleUserInterface : IUserInterface
    {
        private const string PLANET = "planet";
        private const string STAR = "star";
        private const string NEWFILE = "new file";
        private const string QUIT = "quit";
        private const string BACK = "back";
        private const string SEARCH = "search";
        private const string RESET = "reset";
        private const string ORDER = "order";
        private const string CHANGE = "change";
        private const string INFORMATION = "information";
        private const string LIST = "list";

        /// <summary>
        /// Asks for input
        /// </summary>
        /// <returns>Returns a string with the input</returns>
        public string GetInput() => Console.ReadLine().ToLower();

        /// <summary>
        /// Prints a message asking for a file path
        /// </summary>
        public void AskForAFilePath() =>
            Console.WriteLine("\nInsert file path");

        /// <summary>
        /// Prints an invalid path message
        /// </summary>
        public void InvalidPath()
        {
            Console.WriteLine("\n -----------------------------------");
            Console.WriteLine(" Invalid path / file");
            Console.WriteLine(" Choose a valid path or type 'back'");
            Console.WriteLine(" -----------------------------------");
        }

        /// <summary>
        /// Prints a message if the file opened successfully
        /// </summary>
        public void FileOpened()
        {
            Console.WriteLine("\nFile opened successfully");
        }

        /// <summary>
        /// Prints a message if the file didn't open
        /// </summary>
        public void ChooseAnOptionNoFile()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine($"\n{NEWFILE} | {QUIT}");
        }

        /// <summary>
        /// Prints initial inputs
        /// </summary>
        public void ChooseAnOption()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine($"{PLANET} | {STAR} | {BACK}");
        }

        /// <summary>
        /// Prints a message when the player inputs
        /// </summary>
        /// <param name="message">Message to print</param>
        public void Message(string message)
        {
            Console.WriteLine("\n ----------------------------");
            Console.WriteLine($"   {message}   ");
            Console.WriteLine(" ----------------------------");
        }

        /// <summary>
        /// Prints possible criteria of an ISearchField
        /// </summary>
        /// <param name="searchCriteria">ISearchField variable</param>
        /// <param name="curOrd">String with current list order</param>
        public void PossibleCriteria(ISearchField searchCriteria, string curOrd)
        {
            // Gets proprties in received type
            Type type = searchCriteria.GetType();
            PropertyInfo[] propertyInfo = type.GetProperties();    

            // Prints the properties and their values
            Console.WriteLine("\n--------Currently searching for---------");
            foreach (PropertyInfo property in propertyInfo)
            {
                Console.WriteLine($"{property.Name.ToLower(),-27}:" +
                $"{property.GetValue(searchCriteria, null)}");
            }

            Console.WriteLine($"\nTo begin the search, type '{SEARCH}'");
            Console.WriteLine($"To reset the fields, type '{RESET}'");
            Console.Write($"To order the list, type '{ORDER}'. ");
            if (Enum.TryParse(curOrd, out ListOrder tempOrder))
            {
                Console.WriteLine($"Current order is {tempOrder}");
            }
            else
            {
                Console.WriteLine($"Current order is defaultorder");
            }
            Console.WriteLine($"To go back to main menu, type '{BACK}'");
            Console.WriteLine(
                "Example to add planet name field: 'planetname: 51 peg b'");
            Console.WriteLine(
                "Example to add distance field: 'distancemin: 10000.25'");
            Console.WriteLine("----------------------------------------");
        }

        /// <summary>
        /// Prints elements of an IAstromicalObject ienumerable
        /// </summary>
        /// <param name="">IEnumerable of IAstronomicalObjects</param>
        public void PrintCriteria(IEnumerable<IAstronomicalObject> listOfObjects)
        {
            foreach (IAstronomicalObject astroBody in listOfObjects)
                Console.WriteLine(astroBody.Information());
        }

        /// <summary>
        /// Prints detailed information of an IAstronomicalObject
        /// </summary>
        /// <param name="astroObject">IAstronomicalObject to print</param>
        public void PrintDetailedCriteria(
            IEnumerable<IAstronomicalObject> astroObject)
        {
            foreach (IAstronomicalObject astroBody in astroObject)
                Console.WriteLine(astroBody.DetailedInformation());
        }

        /// <summary>
        /// Prints possible options while inside the criteria loop
        /// </summary>
        /// <param name="time">Number of times the result was shown</param>
        /// <param name="order">Current list order</param>
        public void OptionsOnSearchCriteria(ushort time, string order)
        {
            Console.WriteLine("\n ---------------------------" +
                "------------------------------");
            Console.WriteLine(" Press Enter key to show more results");
            if (time > 0)
            {
                Console.WriteLine($" Type '{BACK}' to move back the list " +
                                    "to show previous results");
            }
            Console.WriteLine($" Type '{CHANGE}' to go back to search fields");
            Console.WriteLine($" Type '{INFORMATION}' to search for detailed" +
                                " information");
            if (Enum.TryParse(order, out ListOrder tempOrder))
            {
                Console.WriteLine($" Ordering by {tempOrder}");
            }
            else 
            {
                Console.WriteLine($" Ordering by default order");
            }
            Console.WriteLine(" ---------------------------" +
                "------------------------------");
        }

        /// <summary>
        /// Prints possible options while inside the detailed information loop
        /// </summary>
        public void OptionsOnDetailedInformation()
        {
            Console.WriteLine("\n ---------------------------" +
                "------------------------------");
            Console.WriteLine($" Type '{LIST}' to go back to the list   ");
            Console.WriteLine($" Type a name on the the list to " +
                                $"see detailed information");
            Console.WriteLine(" ---------------------------" +
                "------------------------------");
        }

        /// <summary>
        /// Prints every value in an eum
        /// </summary>
        /// <param name="message">Enum to print values from</param>
        public void PrintEnumValues(Enum values)
        {
            // Gets proprties in received type
            Type type = values.GetType();
            Array vals = Enum.GetValues(type);

            Console.WriteLine("\n Type one of the following orders or the " +
                                "order will be default");
            Console.WriteLine(" ----------------------------");
            foreach (var value in vals)
            {
                Console.WriteLine(" " + value);
            }
            Console.WriteLine(" ----------------------------");
        }

        /// <summary>
        /// Prints a goodbye message
        /// </summary>
        public void Goodbye() =>
            Console.WriteLine("\nGoodbye");
    }
}