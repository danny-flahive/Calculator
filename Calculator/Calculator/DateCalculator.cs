using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class DateCalculator : ICalculator
    {
        private Logger logger;

        public DateCalculator(Logger logger)
        {
            this.logger = logger;
        }
        public void PerformCalculation()
        {
            DateTime userDate = InputParser.GetDateInput("Please enter a date: ");
            int daysToAdd = (int) InputParser.GetIntInput("Please enter the number of days to add: ");
            DateTime result = userDate.AddDays(daysToAdd);
            LogCalculation(userDate, daysToAdd, result);
            Console.WriteLine($"The result is: {result.ToShortDateString()}");
        }

        private void LogCalculation(DateTime userDate, int daysToAdd, DateTime result)
        {
            string calculation = $"{userDate.ToShortDateString()} + {daysToAdd} = {result.ToShortDateString()}";
            logger.Log(calculation);
        }
    }
}
