using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class NumberCalculator
    {
        public void PerformCalculation()
        {
            string chosenOperator = InputParser.GetOperator();
            int[] values = InputParser.GetMultipleValues(chosenOperator);
            int output = CalculateOutput(values, chosenOperator);
            Console.WriteLine("The result is {0}", output);
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
