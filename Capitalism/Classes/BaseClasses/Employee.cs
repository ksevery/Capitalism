using System;
using System.Collections.Generic;

namespace Capitalism.Classes.BaseClasses
{
    public class Employee
    {
        private EmployeesEnum position;
        private string name;
        private decimal salary;
        private IList<Employee> employees;

        private Employee()
        {
            this.Employees = new List<Employee>();
        }

        public Employee(string name)
        {
            this.Name = name;
        }

        public Employee(string name, EmployeesEnum position)
            : this()
        {
            this.Name = name;
            this.Position = position;
            this.Salary = salary;
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        public EmployeesEnum Position
        {
            get
            {
                return position;
            }

            private set
            {
                position = value;
            }
        }

        public IList<Employee> Employees
        {
            get
            {
                return employees;
            }

            private set
            {
                employees = value;
            }
        }
    }
}
