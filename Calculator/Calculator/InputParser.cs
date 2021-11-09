using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class InputParser
    {
        public static int? GetMenuChoice()
        {
            string menuString = "\nWhich calculator mode do you want?\n"
                + "\t1) Numbers\n\t2) Dates\n(Press 0 to exit)\n";
            int? userInput;
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

        public static int? GetIntInput(string message)
        {
            int? output = 0;
            bool valid = false;
            while (!valid)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (input.Trim() == "")
                {
                    output = null;
                    valid = true;
                }
                else
                {
                    int temp;
                    valid = int.TryParse(input, out temp);
                    output = temp;
                }
            }
            return output;
        }

        public static int? GetValidDivisor(string message)
        {
            int? value = 0;
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

        public static List<int> GetMultipleValues(string userOperator)
        {
            List<int> values = new List<int>();
            int? value = 0;
            while (value.HasValue)
            {
                if (userOperator == "/" && values.Count > 1)
                {
                    value = GetValidDivisor("Enter the next number: ");
                }
                else
                {
                    value = GetIntInput("Enter the next number: ");
                }
                if (value.HasValue)
                    values.Add((int) value);
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
