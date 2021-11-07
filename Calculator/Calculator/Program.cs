using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator!");
            Console.Write("Enter the first number to multiply: ");
            int first_multiplier = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number to multiply: ");
            int second_multiplier = int.Parse(Console.ReadLine());
            int result = first_multiplier * second_multiplier;
            Console.WriteLine(result);
        }
    }
}
