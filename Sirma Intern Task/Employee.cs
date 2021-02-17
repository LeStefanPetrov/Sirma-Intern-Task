using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Intern_Task
{
    class Employee 
    {
        public int EmpId { get; set; } // Employee ID
        public int ProjectId { get; set; } // Project ID
        public DateTime DateFrom { get; set; } // Started his work on the project
        public DateTime DateTo { get; set; } // Ended his work on the project 

        public Employee(int EmpId, int ProjectId, DateTime DateFrom, DateTime DateTo)
        {
            this.EmpId = EmpId;
            this.ProjectId = ProjectId;
            this.DateFrom = DateFrom;
            this.DateTo = DateTo;
        }
        public void PrintEmployee()
        {
            Console.WriteLine(EmpId + " " + ProjectId + " " + DateFrom + " " + DateTo);
        }
    }
}
