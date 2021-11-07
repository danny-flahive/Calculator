using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator!");
            //Input sanitisation on all three user inputs before the operation is performed
            string chosenOperator = "";
            while (chosenOperator != "+" && chosenOperator != "-" && chosenOperator != "*" && chosenOperator != "/")
            {
                Console.Write("Enter an operator (+, -, *, /): ");
                chosenOperator = Console.ReadLine();
            }

            Boolean validInput = false;
            int firstValue = 0;
            while (!validInput)
            {
                Console.Write("Enter the first number: ");
                try
                {
                    firstValue = int.Parse(Console.ReadLine());
                    validInput = true;
                }
                catch (FormatException e)
                {
                    continue;
                }
            }

            validInput = false;
            int secondValue = 0;
            while (!validInput)
            {
                Console.Write("Enter the second number: ");
                try
                {
                    secondValue = int.Parse(Console.ReadLine());
                    if (chosenOperator == "/" && secondValue == 0)
                    {
                        Console.WriteLine("Cannot divide by 0.");
                        continue;
                    }
                    validInput = true;
                }
                catch (FormatException e)
                {
                    continue;
                }

            }

            int output = 0;
            switch (chosenOperator)
            {
                case ("+"):
                    output = firstValue + secondValue;
                    break;
                case ("-"):
                    output = firstValue - secondValue;
                    break;
                case ("*"):
                    output = firstValue * secondValue;
                    break;
                case ("/"):
                    output = firstValue / secondValue;
                    break;
            }

            Console.WriteLine(output);
        }
    }
}
