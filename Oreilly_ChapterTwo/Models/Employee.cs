using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_ChapterTwo.Models
{
    // Used to demonstrate fields and properties section. 
    public class Employee : IEmployee
    {
        private int _id;
        private string? _name;
        private decimal _salary;

        public int Emp_Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }

        // This syntax creates private field automatically. It looks different, but it is exactly same as two fields above. 
        // Only difference here is that private field declaration is implicit. And you interact with the field through Property name. 
        public string? Address { get; set; }
        public string? City { get; private set; }

        public Employee()
        {
            // Empty constructor
        }

        public Employee GetEmployee(int empId)
        {
            Database employees = new();
            return employees.GetEmployeeList().SingleOrDefault(employee => empId == employee.Emp_Id);
        }
    }
}
