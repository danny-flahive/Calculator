using System;

namespace Calculator
{
    class Program
    {

        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            Logger logger = new Logger();
            NumberCalculator numberCalculator = new NumberCalculator(logger);
            DateCalculator dateCalculator = new DateCalculator(logger);
            bool continueCalculations = true;
            while (continueCalculations)
            {
                int option = InputParser.GetMenuChoice();
                Console.Clear();
                switch(option)
                {
                    case 0:
                        continueCalculations = false;
                        break;
                    case 1:
                        numberCalculator.PerformCalculation();
                        break;
                    case 2:
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
