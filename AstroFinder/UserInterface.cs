using System;
using System.Reflection;
using System.Collections.Generic;

namespace AstroFinder
{
    public class UserInterface
    {
        private const string plName = "pl_name";
        private const string hoName = "hostname";
        private const string planet = "planet";
        private const string star = "star";
        private const string newFile = "new file";
        private const string quit = "quit";
        private const string back = "back";
        private const string search = "search";
        private const int x = -7;

        public UserInterface()
        {
        }

        public string GetInput() => Console.ReadLine().ToLower();

        public void Print(object obj) =>
            Console.WriteLine(obj);

        public void InitialInformation() =>
            Console.WriteLine("\nInsert file path");

        public void InvalidPath()
        {
            Console.WriteLine("\nInvalid path");
            Console.WriteLine("Choose a valid path or type 'quit' to leave\n");
        }

        public void FileOpened()
        {
            Console.WriteLine("\nFile opened successfully");
        }

        public void ChooseAnOption()
        {
            Console.WriteLine("\nSearch for:");
            Console.WriteLine($"{planet} | {star} | {newFile} | {quit}");
        }

        public void TopPlanetInformation()
        {
            Console.WriteLine($"\n{plName,x}{hoName,x}");
            Console.WriteLine("\n-------------------------\n");
        }

        public void NotValid() =>
            Console.WriteLine("Not a valid option");
        
        

        public void PossibleCriteria(SearchCriteria searchCriteria)
        {
            Type type = typeof(SearchCriteria);
            PropertyInfo[] propertyInfo = type.GetProperties();    

            Console.WriteLine("\n--------Possible criteria---------");
            Console.WriteLine("pl_name: | hostname: | discoverymethod:");
            Console.WriteLine("disc_year: min | disc_year: max |");
            Console.WriteLine("\nTo begin the search, type 'search'");
            Console.WriteLine("To go back to main menu, type 'back'");
            Console.WriteLine("Search example: 'pl_name: 51 Peg b'");
            Console.WriteLine("Search example: 'discovery_year: min 1990'");
            Console.WriteLine("----------------------------------");
        }

        public void CurrentlySearchingFor(SearchCriteria searchCriteria)
        {
            Type type = typeof(SearchCriteria);
            PropertyInfo[] propertyInfo = type.GetProperties();    

            Console.WriteLine("\n-----Currently searching for------");
            foreach (PropertyInfo property in propertyInfo)
            {
                Console.WriteLine($"{property.Name,-18}:" +
                $"{property.GetValue(searchCriteria, null)}");
            }
            Console.WriteLine("----------------------------------");
        }

        public void InvalidCriteria()
        {
            Console.WriteLine("\nInvalid criteria");
        }

        public void Goodbye() =>
            Console.WriteLine("\nGoodbye");
    }
}