using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.Files.Persons
{
    class Employee : Person, IComparable<Employee>
    {
        private Organisation organisation = null;
        private decimal wage;

        public int LastID { set; get; } = 0;
        public int ID { set; get; }
        public string Description { set; get; }
        public Organisation Organisation { set { SetOrganisation(value); } get { return organisation; } }
        public decimal Wage { set { SetWage(value); } get { return wage; } }
        public decimal MaxWage { set; get; }


        public Employee(string name, string address, int age, char gender, int id, string description, Organisation organisation, decimal wage, decimal maxwage) : base(name, address, age, gender)
        {
            this.ID = id;
            this.LastID = id - 1;
            this.Description = description;
            this.Organisation = organisation;
            this.Wage = wage;
            this.MaxWage = maxwage;
        }

        private bool SetWage(decimal wage)
        {
            if(wage <= this.MaxWage)
            {
                this.wage = wage;
                return true;
            }

            Console.WriteLine($"Wage from {Name} can max be {MaxWage}");
            return false;
        }

        private bool NewID()
        {
            if(this.LastID.Equals(0))
            {
                this.LastID++;
                this.ID = LastID;
                return true;
            }

            return false;
        }

        private void SetOrganisation(Organisation organisation)
        {
            if(this.organisation != null)
            {
                this.organisation.RemoveEmployee(this);
                if(!this.organisation.Employees.Contains(this))
                {
                    this.organisation.AddEmployee(this);
                }
            }
            this.organisation = organisation;
        }

        int IComparable<Employee>.CompareTo(Employee other)
        {
            return this.Wage.CompareTo(other.Wage);
        }
    }
}
