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
            Console.WriteLine("| Invalid path                      |");
            Console.WriteLine("| Choose a valid path or type 'back'|");
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
        public void NotValid(string message)
        {
            Console.WriteLine("\n ------------------------");
            Console.WriteLine($"   {message}   ");
            Console.WriteLine(" ------------------------");
        }

        /// <summary>
        /// Prints possible criteria of an ISearchField
        /// </summary>
        /// <param name="searchCriteria">ISearchField variable</param>
        public void PossibleCriteria(ISearchField searchCriteria)
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

            Console.WriteLine("\nTo begin the search, type 'search'");
            Console.WriteLine("To reset the fields, type 'reset'");
            Console.WriteLine("To go back to main menu, type 'back'");
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
        /// Prints possible options while inside the criteria loop
        /// </summary>
        public void OptionsOnSearchCriteria()
        {
            Console.WriteLine("\n ------------------------");
            Console.WriteLine(" Press Enter key to show more results");
            Console.WriteLine(" Type 'change' to change search fields");
            Console.WriteLine(" ------------------------");
        }

        /// <summary>
        /// Prints a goodbye message
        /// </summary>
        public void Goodbye() =>
            Console.WriteLine("\nGoodbye");
    }
}