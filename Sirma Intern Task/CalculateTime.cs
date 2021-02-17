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
            double timespan = 0, maxTimeSpan = 0, employee1 = 0, employee2 = 0, projectId = 0;

            for (int i = 0; i < employees.Count; i++)
            {
                for (int j = i; j < employees.Count; j++)
                {
                    if (employees[i].EmpId != employees[j].EmpId && employees[i].ProjectId == employees[j].ProjectId && employees[i].DateTo > employees[j].DateFrom && employees[j].DateTo > employees[i].DateFrom)
                    {
                        int DateFrom = DateTime.Compare(employees[i].DateFrom, employees[j].DateFrom);
                        int DateTo = DateTime.Compare(employees[i].DateTo, employees[j].DateTo);
                        
                        // Cases where the DateFrom or the DateTo (or both) are equal, are not assumed (written)

                        if (employees[i].DateFrom < employees[j].DateFrom && employees[i].DateTo < employees[j].DateTo)
                        {
                            timespan = (employees[i].DateTo - employees[j].DateFrom).TotalDays;
                        }
                        else if (employees[i].DateFrom < employees[j].DateFrom && employees[i].DateTo > employees[j].DateTo)
                        {
                            timespan = (employees[j].DateTo - employees[j].DateFrom).TotalDays;
                        }
                        else if (employees[i].DateFrom > employees[j].DateFrom && employees[i].DateTo < employees[j].DateTo)
                        {
                            timespan = (employees[i].DateTo - employees[i].DateFrom).TotalDays;
                        }
                        else if (employees[i].DateFrom > employees[j].DateFrom && employees[i].DateTo > employees[j].DateTo)
                        {
                            timespan = (employees[j].DateTo - employees[j].DateFrom).TotalDays;
                        }
                    }
                    if (timespan > maxTimeSpan)
                    {
                        maxTimeSpan = timespan;
                        employee1 = employees[i].EmpId;
                        employee2 = employees[j].EmpId;
                        projectId = employees[i].ProjectId;
                    }

                }
            }
            if (maxTimeSpan == 0) 
            { 
                Console.WriteLine("\nNo Solutions!");
            }
            else
            {
                TimeSpan result = TimeSpan.FromDays(maxTimeSpan);
                Console.WriteLine("\nThe longest couple of employees who worked on a same project are employee {0} and employee {1}, who worked on project {2} for {3} days", employee1, employee2, projectId, result.Days);

            }
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
