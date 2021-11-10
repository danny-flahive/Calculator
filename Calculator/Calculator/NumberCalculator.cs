using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Calculator
{
    class NumberCalculator : ICalculator
    {
        private Logger logger;

        public NumberCalculator(Logger logger)
        {
            this.logger = logger;
        }

        public void PerformCalculation()
        {
            string chosenOperator = InputParser.GetOperator();
            List<int> values = InputParser.GetMultipleValues(chosenOperator);
            int output = CalculateOutput(values, chosenOperator);
            LogCalculation(chosenOperator, values, output);
            Console.WriteLine($"The result is {output}");
        }

        private void LogCalculation(string chosenOperator, List<int> values, int output)
        {
            string calculation = $"{string.Join((" " + chosenOperator + " "), values)} = {output}";
            logger.Log(calculation);
        }

        private int CalculateOutput(List<int> values, string operation)
        {
            int output = 0;
            switch (operation)
            {
                case ("+"):
                    output = checked(values.Sum());
                    break;
                case ("-"):
                    output = checked(values.Skip(1).Aggregate(values[0], (current, next) => current - next));
                    break;
                case ("*"):
                    output = checked(values.Aggregate(1, (current, next) => current * next));
                    break;
                case ("/"):
                    output = checked(values.Skip(1).Aggregate(values[0], (current, next) => current / next));
                    break;
            }
            return output;
        }
    }
}
