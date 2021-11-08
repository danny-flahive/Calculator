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
                PerformOneCalculation();
                performCalculations = AskToContinue();
                Console.Clear();
            }

        }

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Calculator!");
            Console.WriteLine("==========================");
        }

        public static void PerformOneCalculation()
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

        public static bool AskToContinue()
        {
            Console.WriteLine("Would you like to perform another calculation? (Y/N)");
            String answer = Console.ReadLine();
            while (answer != "Y" && answer != "N")
            {
                Console.WriteLine("Enter a valid response (Y/N)");
                answer = Console.ReadLine();
            }
            return answer == "Y";
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
    }
}
