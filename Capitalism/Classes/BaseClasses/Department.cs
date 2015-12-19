using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitalism.Classes.BaseClasses
{
    public class Department
    {
        private IList<Employee> employees;
        private IList<Department> subDepartments;
        private string name;
        private Employee manager;
        
        public Department(string name, Employee manager)
        {
            this.Name = name;
            this.Manager = manager;
            this.Employees = new List<Employee>();
            this.SubDepartments = new List<Department>();
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

        public Employee Manager
        {
            get
            {
                return manager;
            }

            private set
            {
                manager = value;
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

        public IList<Department> SubDepartments
        {
            get
            {
                return subDepartments;
            }

            private set
            {
                subDepartments = value;
            }
        }
    }
}
