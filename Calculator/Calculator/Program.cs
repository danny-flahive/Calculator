using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator!");
            string chosenOperator = "";
            while (chosenOperator != "+" && chosenOperator != "-" && chosenOperator != "*" && chosenOperator != "/")
            {
                Console.Write("Enter an operator (+, -, *, /): ");
                chosenOperator = Console.ReadLine();
            }

            //Need to sanitise this to keep it in line with the rest of the program
            Console.Write("How many integers would you like to enter? ");
            int numberOfInputs = int.Parse(Console.ReadLine());
            int[] values = new int[numberOfInputs];

            //Gather all values for the calculation later
            for (int i = 0; i < numberOfInputs; i++)
            {
                Boolean validInput = false;
                int value = 0;
                //Input sanitisation
                while (!validInput)
                {
                    Console.Write("Enter number {0}: ", i + 1);
                    try
                    {
                        value = int.Parse(Console.ReadLine());
                        if (i > 0 && chosenOperator == "/" && value == 0)
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
                values[i] = value;
            }

            //Perform calculations
            int output = 0;
            switch (chosenOperator)
            {
                case ("+"):
                    foreach (int value in values)
                    {
                        output += value;
                    }
                    break;
                case ("-"):
                    output = values[0];
                    for (int i = 1; i < values.Length; i++)
                    {
                        output -= values[i];
                    }
                    break;
                case ("*"):
                    output = 1;
                    foreach (int value in values)
                    {
                        output *= value;
                    }
                    break;
                case ("/"):
                    output = values[0];
                    for (int i = 1; i < values.Length; i++)
                    {
                        output /= values[i];
                    }
                    break;
            }

            Console.WriteLine(output);

        }
    }
}
