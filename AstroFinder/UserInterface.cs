using System;
using System.Reflection;

namespace AstroFinder
{
    public class UserInterface
    {
        private const string PLNAME = "pl_name";
        private const string HONAME = "hostname";
        private const string PLANET = "planet";
        private const string STAR = "star";
        private const string NEWFILE = "new file";
        private const string QUIT = "quit";
        private const string BACK = "back";
        private const string SEARCH = "search";
        private const int x = -7;

        public string GetInput() => Console.ReadLine().ToLower();

        public void Print(object obj) =>
            Console.WriteLine(obj);

        public void InitialInformation() =>
            Console.WriteLine("\nInsert file path");

        public void InvalidPath()
        {
            Console.WriteLine("\n -----------------------------------");
            Console.WriteLine("| Invalid path                      |");
            Console.WriteLine("| Choose a valid path or type 'back'|");
            Console.WriteLine(" -----------------------------------");
        }

        public void FileOpened()
        {
            Console.WriteLine("\nFile opened successfully");
        }

        public void ChooseAnOptionNoFile()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine($"\n{NEWFILE} | {QUIT}");
        }

        public void ChooseAnOption()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine($"{PLANET} | {STAR} | {BACK}");
        }

        public void TopPlanetInformation()
        {
            Console.WriteLine($"\n{PLNAME,x}{HONAME,x}");
            Console.WriteLine("\n-------------------------\n");
        }

        public void NotValid()
        {
            Console.WriteLine("\n ------------------------");
            Console.WriteLine("|   Not a valid option   |");
            Console.WriteLine(" ------------------------");
        }        

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
            Console.WriteLine("To go back to main menu, type 'back'");
            Console.WriteLine(
                "Example to add planet name field: 'planetname: 51 peg b'");
            Console.WriteLine(
                "Example to add discovery year field: 'distancemin: 10000.25'");
            Console.WriteLine("----------------------------------------");
        }

        public void InvalidCriteria()
        {
            Console.WriteLine("\n ------------------------");
            Console.WriteLine("|    Invalid criteria    |");
            Console.WriteLine(" ------------------------");
        }

        public void Goodbye() =>
            Console.WriteLine("\nGoodbye");
    }
}