using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Calculator
{
    class NumberCalculator
    {
        Logger logger;

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
            Console.WriteLine("The result is {0}", output);
        }

        private void LogCalculation(string chosenOperator, List<int> values, int output)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int value in values)
            {
                stringBuilder.Append(string.Format("{0} {1} ", value, chosenOperator));
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append(string.Format("= {0}", output));
            logger.Log(stringBuilder.ToString());
        }

        private int CalculateOutput(List<int> values, string operation)
        {
            int output = 0;
            switch (operation)
            {
                case ("+"):
                    output = values.Sum();
                    break;
                case ("-"):
                    output = values.Skip(1).Aggregate(values[0], (current, next) => current - next);
                    break;
                case ("*"):
                    output = values.Aggregate(1, (current, next) => current * next);
                    break;
                case ("/"):
                    output = values.Skip(1).Aggregate(values[0], (current, next) => current / next);
                    break;
            }
            return output;
        }
    }
}
