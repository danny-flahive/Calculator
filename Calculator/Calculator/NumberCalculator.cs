using System;
using System.Collections.Generic;
using System.Text;

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
            int[] values = InputParser.GetMultipleValues(chosenOperator);
            int output = CalculateOutput(values, chosenOperator);
            LogCalculation(chosenOperator, values, output);
            Console.WriteLine("The result is {0}", output);
        }

        private void LogCalculation(string chosenOperator, int[] values, int output)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int value in values)
            {
                stringBuilder.Append(string.Format("{0} {1} ", value, chosenOperator));
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append(string.Format("= {0}", output));
            logger.Log(stringBuilder.ToString());
        }

        private int CalculateOutput(int[] values, string operation)
        {
            int output = 0;
            switch (operation)
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
            return output;
        }
    }
}
