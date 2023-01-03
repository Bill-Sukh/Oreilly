using Oreilly_ChapterTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_ChapterTwo
{
    public class Database
    {
        private readonly List<Employee> Employees = new();

        public Database()
        {
            for(int i = 0; i < 10; i++)
            {
                Employees.Add(new Employee
                {
                    Emp_Id = i,
                    Name = $"Merlin{i}",
                    Salary = Convert.ToDecimal(i) + 2.00M,
                });
            }
        }

        public List<Employee> GetEmployeeList()
        {
            return Employees;
        }
    }
}
