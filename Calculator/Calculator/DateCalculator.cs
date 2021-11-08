using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class DateCalculator
    {
        public void PerformCalculation()
        {
            DateTime userDate = InputParser.GetDateInput("Please enter a date: ");
            int daysToAdd = InputParser.GetIntInput("Please enter the number of days to add: ");
            DateTime result = userDate.AddDays(daysToAdd);
            Console.WriteLine("The result is: {0}", result.ToShortDateString());
        }
    }
}
