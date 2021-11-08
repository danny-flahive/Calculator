using System;

namespace Calculator
{
    class Program
    {

        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            bool performCalculations = true;
            while (performCalculations)
            {
                int option = GetMenuChoice();
                Console.Clear();
                switch(option)
                {
                    case 0:
                        performCalculations = false;
                        break;
                    case 1:
                        PerformNumericCalculation();
                        break;
                    case 2:
                        PerformDateCalculation();
                        break;
                }
            }

        }

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Calculator!");
            Console.WriteLine("==========================");
        }

        public static int GetMenuChoice()
        {
            string menuString = "\nWhich calculator mode do you want?\n"
                + "\t1) Numbers\n\t2) Dates\n(Press 0 to exit)";
            int userInput;
            do
            {
                userInput = GetIntInput(menuString);
            } while (userInput < 0 && userInput > 2);
            return userInput;
        }

        public static void PerformNumericCalculation()
        {
            string chosenOperator = GetOperator();
            int[] values = GetValues(chosenOperator);
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

            Console.WriteLine("The result is {0}", output);
        }

        public static void PerformDateCalculation()
        {
            DateTime userDate = GetDateInput("Please enter a date: ");
            int daysToAdd = GetIntInput("Please enter the number of days to add: ");
            DateTime result = userDate.AddDays(daysToAdd);
            Console.WriteLine("The result is: {0}", result);

        }

        public static string GetOperator()
        {
            string chosenOperator = "";
            while (chosenOperator != "+" && chosenOperator != "-" && chosenOperator != "*" && chosenOperator != "/")
            {
                Console.Write("Enter an operator (+, -, *, /): ");
                chosenOperator = Console.ReadLine();
            }
            return chosenOperator;
        }

        public static int[] GetValues(string userOperator)
        {
            int numberOfInputs;
            do
            {
                numberOfInputs = GetIntInput("How many integers would you like to enter? (2 or more) ");
            } while (numberOfInputs < 2);
            int[] values = new int[numberOfInputs];
            for (int i = 0; i < numberOfInputs; i++)
            {

                int value;
                //Prevent divide by zero errors
                if (userOperator == "/" && i > 0)
                {
                    value = GetValidDivisor(i);
                }
                else
                {
                    value = GetIntInput(String.Format("Enter number {0}: ", i + 1));
                }
                values[i] = value;
            }
            return values;
        }

        public static int GetIntInput(string message)
        {
            int output = 0;
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine(message);
                valid = int.TryParse(Console.ReadLine(), out output);
            }
            return output;
        }

        public static int GetValidDivisor(int currentNum)
        {
            int value = 0;
            bool divByZero = true;
            while (divByZero)
            {
                value = GetIntInput(String.Format("Enter number {0}: ", currentNum + 1));
                if (value != 0)
                {
                    divByZero = false;
                }
            }
            return value;
        }

        public static DateTime GetDateInput(string message)
        {
            DateTime output = DateTime.Now;
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine(message);
                valid = DateTime.TryParse(Console.ReadLine(), out output);
            }
            return output;
        }
    }
}
