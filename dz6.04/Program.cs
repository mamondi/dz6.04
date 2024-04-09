using System;
using System.Linq;

namespace CityQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cities = { "Kyiv", "Lviv", "Odessa", "Kharkiv", "Dnipro", "Zaporizhzhia", "Kherson" };

            var allCities = cities.ToArray();
            Console.WriteLine("All cities:");
            PrintCities(allCities);

            int specifiedLength = 6;
            var citiesWithSpecifiedLength = cities.Where(city => city.Length == specifiedLength).ToArray();
            Console.WriteLine($"\nCities with name length equal to {specifiedLength}:");
            PrintCities(citiesWithSpecifiedLength);

            var citiesStartingWithA = cities.Where(city => city.StartsWith("L")).ToArray();
            Console.WriteLine("\nCities whose names start with the letter L:");
            PrintCities(citiesStartingWithA);

            var citiesEndingWithM = cities.Where(city => city.EndsWith("a")).ToArray();
            Console.WriteLine("\nCities whose names end with the letter a:");
            PrintCities(citiesEndingWithM);

            var citiesStartsWithNAndEndsWithK = cities.Where(city => city.StartsWith("K") && city.EndsWith("v")).ToArray();
            Console.WriteLine("\nCities whose names start with the letter K and end with V:");
            PrintCities(citiesStartsWithNAndEndsWithK);

            var citiesStartsWithNe = cities.Where(city => city.StartsWith("K")).OrderByDescending(city => city).ToArray();
            Console.WriteLine("\nCities whose names start with 'K' (sorted in descending order):");
            PrintCities(citiesStartsWithNe);
        }

        static void PrintCities(string[] cities)
        {
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
        }
    }
}
