using Organisation.Files.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.Files
{
    abstract class Organisation
    {
        public string Name { set; get; }
        public Manager Manager { set; get; }
        public List<Employee> Employees { get; }
        public decimal Expenses { set; get; }

        public void AddEmployee(Employee employee)
        {
            Organisation oldOrganisation = employee.Organisation;

            if((oldOrganisation != null) && (oldOrganisation != this))
            {
                oldOrganisation.RemoveEmployee(employee);
                employee.Organisation = this;
            }

            Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine(PrintManager());
            Console.WriteLine($"Total employees: {Employees.Count}");

            foreach(Employee e in Employees)
            {
                Console.WriteLine(e.ToString() + $", ID: {e.ID}, Wage: {e.Wage}");
            }
            
        }

        private string PrintManager()
        {
            if (this.Manager != null) return $"Managed by: {Manager}";

            return "No manager yet";
        }
    }
}