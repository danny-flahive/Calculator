using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Calculator
{
    class Logger
    {
        private string filepath = @"C:\Logs\log.txt";
        private StreamWriter writer;
        public Logger()
        {
            writer = File.CreateText(filepath);
            writer.AutoFlush = true;
        }

        public void Log(string message)
        {
            writer.WriteLine(message);
        }
    }
}
