using System;
using System.Linq;

namespace StudentQueries
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Institution { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = {
                new Student { Name = "John", Surname = "Doe", Age = 21, Institution = "MIT" },
                new Student { Name = "Boris", Surname = "Johnson", Age = 25, Institution = "Oxford" },
                new Student { Name = "Alice", Surname = "Brown", Age = 19, Institution = "Harvard" },
                new Student { Name = "Bob", Surname = "Brooks", Age = 22, Institution = "Oxford" },
                new Student { Name = "Boris", Surname = "Kovalev", Age = 20, Institution = "MIT" }
            };

            var allStudents = students.ToArray();

            Console.WriteLine("All students:");
            foreach (var student in allStudents)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, {student.Age}, {student.Institution}");
            }
            Console.WriteLine();

            var borisStudents = students.Where(student => student.Name == "Boris").ToArray();
            Console.WriteLine("Boris students:");
            foreach (var student in borisStudents)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, {student.Age}, {student.Institution}");
            }

            var broStudents = students.Where(student => student.Surname.StartsWith("Bro")).ToArray();
            Console.WriteLine("Bro students:");
            foreach (var student in broStudents)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, {student.Age}, {student.Institution}");
            }

            var over19Students = students.Where(student => student.Age > 19).ToArray();
            Console.WriteLine("Over 19 students:");
            foreach (var student in over19Students)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, {student.Age}, {student.Institution}");
            }

            var between20And23Students = students.Where(student => student.Age > 20 && student.Age < 23).ToArray();
            Console.WriteLine("Between 20 and 23 students:");
            foreach (var student in between20And23Students)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, {student.Age}, {student.Institution}");
            }

            var mitStudents = students.Where(student => student.Institution == "MIT").ToArray();
            Console.WriteLine("MIT students:");
            foreach (var student in mitStudents)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, {student.Age}, {student.Institution}");
            }

            var oxfordOver18Students = students.Where(student => student.Institution == "Oxford" && student.Age > 18).OrderByDescending(student => student.Age).ToArray();
            Console.WriteLine("Oxford over 18 students:");
            foreach (var student in oxfordOver18Students)
            {
                Console.WriteLine($"{student.Name} {student.Surname}, {student.Age}, {student.Institution}");
            }

        }
    }
}
