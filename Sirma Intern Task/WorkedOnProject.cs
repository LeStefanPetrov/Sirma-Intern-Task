using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Intern_Task
{
    class WorkedOnProject
    {
        public int EmployeeID1 { get; set; }
        public int EmployeeID2 { get; set; }
        public int ProjectID { get; set; }
        public int TotalDays { get; set; }

        public WorkedOnProject(int Employee1, int Employee2, int Project, int Days) 
        {
            this.EmployeeID1 = Employee1;
            this.EmployeeID2 = Employee2;
            this.ProjectID = Project;
            this.TotalDays = Days;
        }

        public WorkedOnProject()
        {
        }

        public void PrintInfo()
        {
            Console.WriteLine("\nEmployee ID 1:" + EmployeeID1 + "\nEmployee ID 2:" + EmployeeID2 + "\nProject ID:" + ProjectID + "\nTotal Days:" + TotalDays);
        }
    }
}
