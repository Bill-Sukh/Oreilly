using Oreilly_ChapterTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_ChapterTwo
{
    public interface IEmployee
    {
        public int Emp_Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee GetEmployee(int empId);

        public string GetEmployeeBadgeNumber(int empId, string empName)
        {
            return $"{empId}{empName}EAGANB4";
        }
    }

}
