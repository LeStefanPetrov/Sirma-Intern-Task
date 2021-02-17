using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Intern_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var variable = new CalculateTime(Path.Combine(Environment.CurrentDirectory, "textfile.txt"));
                variable.PrintData();
                variable.CalculateTimeSpan();
            } catch (Exception e)
            {
                Console.WriteLine("Error: {0}",e.Message);
            }
        }   
    }
}
