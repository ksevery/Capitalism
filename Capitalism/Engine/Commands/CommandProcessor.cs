using Capitalism.Classes;
using Capitalism.Classes.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitalism.Engine.Commands
{
    public class CommandProcessor
    {
        private IList<Company> companies;

        public CommandProcessor()
        {
            this.companies = new List<Company>();
        }

        public void ProcessCommand(string command, string[] commandParams)
        {
            switch (command)
            {
                case Constants.Create_Company:
                    this.CreateCompany(commandParams);
                    break;
                case Constants.Create_Department:
                    this.CreateDepartment(commandParams);
                    break;
                case Constants.Create_Employee:
                    this.CreateEmployee(commandParams);
                    break;
                case Constants.Pay_Salaries:
                    break;
                case Constants.Show_Employees:
                    break;
                default:
                    break;
            }
        }
        
        private void CreateCompany(string[] commandParams)
        {
            var companyName = commandParams[1];
            var ceoFirstName = commandParams[2];
            var ceoLastName = commandParams[3];
            var ceoSalary = decimal.Parse(commandParams[4]);
            // ceoFirstName + " " + ceoLastName
            var ceoFullName = $"{ceoFirstName} {ceoLastName}";
            /*
            foreach(var c in companies)
            {
                if(c.Name == companyName)
                    return true;
            }

            return false;
            */
            var isCompanyPresent = this.companies.Any(c => c.Name == companyName);
            if (isCompanyPresent)
            {
                Console.WriteLine($"Company {companyName} already exists");
                return;
            }

            var ceo = new Employee(ceoFullName, EmployeesEnum.CEO) { Salary = ceoSalary };
            var newCompany = new Company(companyName, ceoSalary, ceo);

            this.companies.Add(newCompany);
        }

        /// <summary>
        /// Creates a department based on command like "create-department C Root1 Nikolay Stoichov [Root1]"
        /// </summary>
        /// <param name="commandParams"></param>
        private void CreateDepartment(string[] commandParams)
        {
            // Extract parameters from commands
            var companyName = commandParams[1];
            var departmentName = commandParams[2];
            var managerFirstName = commandParams[3];
            var managerLastName = commandParams[4];
            var managerFullName = $"{managerFirstName} {managerLastName}";
            var mainDepartmentName = string.Empty;
            
            if (commandParams.Length == 6)
            {
                mainDepartmentName = commandParams[5];
            }

            var company = this.companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                Console.WriteLine($"Company {companyName} does not exist");
                return;
            }

            var isDepartmentPresent = company.Departments.Any(d => d.Name == departmentName);
            if (isDepartmentPresent)
            {
                Console.WriteLine($"Department {departmentName} already exists in {companyName}");
                return;
            }
            
            if (!string.IsNullOrEmpty(mainDepartmentName))
            {
                var mainDepartment = company.Departments.FirstOrDefault(d => d.Name == mainDepartmentName);
                if (mainDepartment == null)
                {
                    Console.WriteLine($"There is no department {mainDepartmentName} in {companyName}");
                    return;
                }

                var employeeInMain = mainDepartment.Employees.FirstOrDefault(e => e.Name == managerFullName);
                if (employeeInMain == null)
                {
                    Console.WriteLine($"There is no employee called {managerFullName} in department {mainDepartmentName}");
                    return;
                }

                if (employeeInMain.Position != EmployeesEnum.Manager)
                {
                    Console.WriteLine($"{employeeInMain.Name} is not a manager (real position: {employeeInMain.Position.ToString()})");
                    return;
                }
                var newDepartment = new Department(departmentName, employeeInMain);
                mainDepartment.SubDepartments.Add(newDepartment);
            }
            else
            {
                var manager = company.Employees.FirstOrDefault(e => e.Name == managerFullName);
                if (manager == null)
                {
                    Console.WriteLine($"There is no employee called {managerFullName} in company {companyName}");
                    return;
                }

                var newDepartment = new Department(departmentName, manager);
                company.Departments.Add(newDepartment);
            }
        }

        private void CreateEmployee(string[] commandParams)
        {
            var empFirstName = commandParams[1];
            var empLastName = commandParams[2];
            var empPosition = commandParams[3];
            var companyName = commandParams[4];
            var departmentName = string.Empty;
            var empFullName = $"{empFirstName} {empLastName}";

            var position = (EmployeesEnum)Enum.Parse(typeof(EmployeesEnum), empPosition);

            if (commandParams.Length == 6)
            {
                departmentName = commandParams[5];
            }

            var company = this.companies.FirstOrDefault(c => c.Name == companyName);
            if (company == null)
            {
                Console.WriteLine($"Company {companyName} does not exist");
                return;
            }

            var newEmp = new Employee(empFullName, position);

            if (string.IsNullOrEmpty(departmentName))
            {
                var department = company.Departments.FirstOrDefault(d => d.Name == departmentName);
                if (department == null)
                {
                    Console.WriteLine($"There is no department {departmentName} in {companyName}");
                    return;
                }

                var hasEmployee = department.Employees.Any(e => e.Name == empFullName && e.Position == position);
                if (hasEmployee)
                {
                    Console.WriteLine($"Employee {empFullName} already exists in {companyName} (in department {departmentName})");
                    return;
                }

                department.Employees.Add(newEmp);
            }
            else
            {
                var hasEmployee = company.Employees.Any(e => e.Name == empFullName && e.Position == position);
                if (hasEmployee)
                {
                    Console.WriteLine($"Employee {empFullName} already exists in {companyName} (no department)");
                    return;
                }

                company.Employees.Add(newEmp);
            }
        }
    }
}
