using System;

namespace Day1Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Age:");
            string age = Console.ReadLine();

            Console.WriteLine($"Your name is {name} and you are {age} years old." );

        }
    }
}
