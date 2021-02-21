using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Intern_Task
{
    class CalculateTime
    {
        private List<Employee> employees=new List<Employee>(); // list of employees 

        public CalculateTime(string filepath) // Constructor. Loads the list from a text file
        {
            string[] text = System.IO.File.ReadAllLines(filepath);
            foreach (var line in text)
            {
                var lineSplit = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (lineSplit[3] == " NULL")
                {
                    employees.Add(new Employee(Convert.ToInt32(lineSplit[0]), Convert.ToInt32(lineSplit[1]), Convert.ToDateTime(lineSplit[2]), DateTime.Today));
                }
                else
                {
                    employees.Add(new Employee(Convert.ToInt32(lineSplit[0]), Convert.ToInt32(lineSplit[1]), Convert.ToDateTime(lineSplit[2]), Convert.ToDateTime(lineSplit[3])));

                }
            }
        }

        public void CalculateTimeSpan() // Calculates the biggest timespan of two employees working on a same project
        {
            int timespan = 0;
            var WorkedTogether = new List<WorkedOnProject>();
            for (int i = 0; i < employees.Count; i++)
            {
                for (int j = i; j < employees.Count; j++)
                {
                    if (employees[i].EmpId != employees[j].EmpId && employees[i].ProjectId == employees[j].ProjectId && employees[i].DateTo > employees[j].DateFrom && employees[j].DateTo > employees[i].DateFrom)
                    {
                        timespan = CalculateRange(employees[i].DateFrom,employees[i].DateTo,employees[j].DateFrom,employees[j].DateTo);

                        WorkedTogether.Add(new WorkedOnProject(employees[i].EmpId, employees[j].EmpId, employees[i].ProjectId, timespan));
                    }
                }
            }
            //creating new list and grouping using LINQ 
            var result = WorkedTogether.GroupBy(x => new { x.EmployeeID1, x.EmployeeID2 })
                                       .Select(w => new WorkedOnProject()
                                       {
                                           EmployeeID1 = w.Key.EmployeeID1,
                                           EmployeeID2 = w.Key.EmployeeID2,
                                           TotalDays = w.Sum(d => d.TotalDays)
                                       }
                                       ).OrderByDescending(w => w.TotalDays).ToList().First();
            
            Console.Write("\nEmployees who worked together:");
            Console.WriteLine("\nEmployee ID 1:"+result.EmployeeID1+ "\nEmployee ID 2:" + result.EmployeeID2 +"\nTotal days together:" + result.TotalDays);
        }


        public int CalculateRange (DateTime DateFrom1,DateTime DateTo1,DateTime DateFrom2,DateTime DateTo2) // Calculates the timespan 
        {
            double timespan = 0;
            if (DateFrom1 <= DateFrom2 && DateTo1 <= DateTo2)
            {
                timespan = (DateTo1 - DateFrom2).TotalDays;
            }
            else if (DateFrom1 <= DateFrom2 && DateTo1 >= DateTo2)
            {
                timespan = (DateTo2 - DateFrom2).TotalDays;
            }
            else if (DateFrom1 >= DateFrom2 && DateTo1 <= DateTo2)
            {
                timespan = (DateTo1 - DateFrom1).TotalDays;
            }
            else if (DateFrom1 >= DateFrom2 && DateTo1 >= DateTo2)
            {
                timespan = (DateTo2 - DateFrom1).TotalDays;
            }

            return (int)timespan;
        }
        public void PrintData() // Prints the whole list
        {
            foreach(var employee in employees)
            {
                employee.PrintEmployee();
            }
        }
    }
}
