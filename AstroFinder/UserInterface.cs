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
            Console.WriteLine($"\n{newFile} | {quit}");
        }

        public void ChooseAnOption()
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine($"{planet} | {star} | {back}");
        }

        public void TopPlanetInformation()
        {
            Console.WriteLine($"\n{plName,x}{hoName,x}");
            Console.WriteLine("\n-------------------------\n");
        }

        public void NotValid()
        {
            Console.WriteLine("\n ------------------------");
            Console.WriteLine("|   Not a valid option   |");
            Console.WriteLine(" ------------------------");
        }
        

        public void PossibleCriteria(SearchCriteria searchCriteria)
        {
            Type type = typeof(SearchCriteria);
            PropertyInfo[] propertyInfo = type.GetProperties();    

            Console.WriteLine("\n--------Currently searching for---------");
            foreach (PropertyInfo property in propertyInfo)
            {
                Console.WriteLine($"{property.Name.ToLower(),-27}:" +
                $"{property.GetValue(searchCriteria, null)}");
            }

            Console.WriteLine("\nTo begin the search, type 'search'");
            Console.WriteLine("To go back to main menu, type 'back'");
            Console.WriteLine("Example to add planet name field: 'planetname: 51 peg b'");
            Console.WriteLine("Example to add discovery year field: 'discoveryyearmax: 1990'");
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