using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class InputParser
    {
        public static int GetMenuChoice()
        {
            string menuString = "\nWhich calculator mode do you want?\n"
                + "\t1) Numbers\n\t2) Dates\n(Press 0 to exit)";
            int userInput;
            do
            {
                userInput = GetIntInput(menuString);
            } while (userInput < 0 || userInput > 2);
            return userInput;
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

        public static int GetValidDivisor(string message)
        {
            int value = 0;
            bool divByZero = true;
            while (divByZero)
            {
                value = GetIntInput(message);
                if (value != 0)
                {
                    divByZero = false;
                }
            }
            return value;
        }

        public static int[] GetMultipleValues(string userOperator)
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
                    value = GetValidDivisor(String.Format("Enter number {0}: ", i + 1));
                }
                else
                {
                    value = GetIntInput(String.Format("Enter number {0}: ", i + 1));
                }
                values[i] = value;
            }
            return values;
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
