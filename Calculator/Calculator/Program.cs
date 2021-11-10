using System;
using System.Collections.Generic;
namespace Calculator
{
    class Program
    {
        //TODO: ICalculator Interface
        enum MenuOptions
        {
            Exit,
            NumberCalculator,
            DateCalculator
        }

        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            Logger logger = new Logger();
            NumberCalculator numberCalculator = new NumberCalculator(logger);
            DateCalculator dateCalculator = new DateCalculator(logger);
            bool continueCalculations = true;
            while (continueCalculations)
            {
                MenuOptions? option = (MenuOptions?) InputParser.GetMenuChoice();
                Console.Clear();
                switch(option)
                {
                    case null:
                    case MenuOptions.Exit:
                        continueCalculations = false;
                        break;
                    case MenuOptions.NumberCalculator:
                        try
                        {
                            numberCalculator.PerformCalculation();
                        } catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case MenuOptions.DateCalculator:
                        dateCalculator.PerformCalculation();
                        break;
                }
            }

        }
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Calculator!");
            Console.WriteLine("==========================");
        }
    }
}
