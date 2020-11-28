using System;

namespace AstroFinder
{
    public class UserInterface
    {
        private const string plName = "pl_name";
        private const string hoName = "ho_name";
        private const string planet = "planet";
        private const string star = "star";
        private const string quit = "quit";
        private const string back = "back";
        private const int x = -7;

        public UserInterface()
        {
        }

        public string GetInput() => Console.ReadLine().ToLower();

        public void InitialInformation() =>
            Console.WriteLine("Insert file path");

        public void FileOpened() =>
            Console.WriteLine("File opened successfully");

        public void ChooseAnOption()
        {
            Console.WriteLine();
            Console.WriteLine("Search:");
            Console.WriteLine($"{planet,x} | {star,x} | {quit,x}");
        }

        public void ChoosePlanet()
        {
            Console.WriteLine();
            Console.WriteLine("Searching Planet for:");
            Console.WriteLine($"{plName,x} | {hoName,x} | {back,x}");
        }

        public void TopPlanetInformation()
        {
            Console.WriteLine();
            Console.WriteLine($"{plName,x}{hoName,x}");
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine();
        }

        public void NotValid() =>
            Console.WriteLine("Not a valid option");

        public void Goodbye() =>
            Console.WriteLine("Goodbye");

        public void SearchPlanet() =>
            Console.WriteLine("planeta");
    }
}