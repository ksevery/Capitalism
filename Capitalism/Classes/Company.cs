using Capitalism.Classes.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitalism.Classes
{
    public class Company
    {
        private Employee ceo;
        private string name;
        private decimal ceoSalary;
        private IList<Employee> employees;
        private IList<Department> departments;
        
        public Company(string name, decimal ceoSalary, Employee ceo)
        {
            this.Name = name;
            this.CeoSalary = ceoSalary;
            this.Ceo = ceo;
            this.Employees = new List<Employee>();
            this.Departments = new List<Department>();
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

        public decimal CeoSalary
        {
            get
            {
                return ceoSalary;
            }

            private set
            {
                ceoSalary = value;
            }
        }

        public Employee Ceo
        {
            get
            {
                return ceo;
            }

            private set
            {
                ceo = value;
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

        public IList<Department> Departments
        {
            get
            {
                return departments;
            }

            private set
            {
                departments = value;
            }
        }
    }
}
