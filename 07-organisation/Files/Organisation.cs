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

        public decimal EmployeeCostsWithoutBonus()
        {
            decimal sum = 0.0m;

            foreach (Employee e in Employees)
            {
                sum += e.Wage;
            }

            return sum;
        }

        public decimal CostsWithoutBonus()
        {
            return EmployeeCostsWithoutBonus() + Expenses;
        }

        public decimal Bonus()
        {
            return WinningsWithoutBonus() * Manager.Wage;
        }

        public decimal EmployeeCosts()
        {
            return EmployeeCostsWithoutBonus() + Bonus();
        }

        public decimal Winnings()
        {
            return WinningsWithoutBonus() + Bonus();
        }

        public abstract decimal WinningsWithoutBonus();
    }
}