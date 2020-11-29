using System;
using System.Collections.Generic;

namespace AstroFinder
{
    public class UserInterface
    {
        private const string plName = "pl_name";
        private const string hoName = "hostname";
        private const string planet = "planet";
        private const string star = "star";
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
            Console.WriteLine("Insert file path");

        public void FileOpened()
        {
            Console.WriteLine("\nFile opened successfully");
        }

        public void ChooseAnOption()
        {
            Console.WriteLine("\nSearch for:");
            Console.WriteLine($"{planet,x} | {star,x} | {quit,x}");
        }

        public void ChoosePlanet()
        {
            Console.WriteLine("\nTo begin the search, type 'search'");
            Console.WriteLine("Search example: 'pl_name: 51 Peg b'");
            Console.WriteLine("Possible criteria:");
            Console.WriteLine($"{plName,x} | {hoName,x} | {search,x} | {back,x}");
        }

        public void TopPlanetInformation()
        {
            Console.WriteLine($"\n{plName,x}{hoName,x}");
            Console.WriteLine("\n-------------------------\n");
        }

        public void NotValid() =>
            Console.WriteLine("Not a valid option");
        
        public void InvalidPath()
        {
            Console.WriteLine("\nInvalid path");
            Console.WriteLine("Choose a new path or type 'quit' to leave\n");
        }

        public void PrintDictionary(IDictionary<string,string> searchCriteria)
        {
            Console.WriteLine("\n---------Current criteria---------");
            foreach (KeyValuePair<string,string> key in searchCriteria)
                Console.WriteLine($"{key.Key + ": " + key.Value}");
            Console.WriteLine("-----------------------------------");
        }

        public void InvalidCriteria()
        {
            Console.WriteLine("\nInvalid criteria");
        }

        public void Goodbye() =>
            Console.WriteLine("\nGoodbye");

        public void SearchPlanet() =>
            Console.WriteLine("planeta");
    }
}