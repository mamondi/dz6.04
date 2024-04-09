using System;
using System.Linq;

namespace dz6._04
{
    public class ArrOperations
    {
        public static int[] GetAllIntegers(int[] array)
        {
            return array;
        }

        public static int[] GetEvenIntegers(int[] array)
        {
            return array.Where(x => x % 2 == 0).ToArray();
        }

        public static int[] GetOddIntegers(int[] array)
        {
            return array.Where(x => x % 2 != 0).ToArray();
        }

        public static int[] GetNumbersInRange(int[] array, int min, int max)
        {
            return array.Where(x => x >= min && x <= max).ToArray();
        }

        public static int[] GetGreaterThan(int[] array, int threshold)
        {
            return array.Where(x => x > threshold).ToArray();
        }

        public static int[] GetMultiplesOfEight(int[] array)
        {
            return array.Where(x => x % 8 == 0).OrderByDescending(x => x).ToArray();
        }

        public static int[] GetMultiplesOfSeven(int[] array)
        {
            return array.Where(x => x % 7 == 0).OrderBy(x => x).ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 14, 16, 18, 21, 24, 28, 32 };

            Console.WriteLine("Усі цілі:");
            Console.WriteLine(string.Join(", ", ArrOperations.GetAllIntegers(numbers)));

            Console.WriteLine("\nПарні цілі:");
            Console.WriteLine(string.Join(", ", ArrOperations.GetEvenIntegers(numbers)));

            Console.WriteLine("\nНепарні цілі:");
            Console.WriteLine(string.Join(", ", ArrOperations.GetOddIntegers(numbers)));

            Console.WriteLine("\nБільше 10:");
            Console.WriteLine(string.Join(", ", ArrOperations.GetGreaterThan(numbers, 10)));

            Console.WriteLine("\nЧисла в діапазоні від 5 до 20:");
            Console.WriteLine(string.Join(", ", ArrOperations.GetNumbersInRange(numbers, 5, 20)));

            Console.WriteLine("\nКратні семи:");
            Console.WriteLine(string.Join(", ", ArrOperations.GetMultiplesOfSeven(numbers)));

            Console.WriteLine("\nКратні восьми (за спаданням):");
            Console.WriteLine(string.Join(", ", ArrOperations.GetMultiplesOfEight(numbers)));
        }
    }
}
