using Organisation.Files.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.Files.Persons
{
    class Manager : Employee
    {
        private Organisation _organisation = null;

        public decimal Winnings { set; get; }
        public decimal Percentage { set; get; } = 0.05m;


        public Manager(string name, string address, int age, Gender gender, int id, string description, Organisation organisation, decimal wage, decimal maxWage) : base(name, address, age, gender, id, description, organisation, wage, maxWage) { }

        public override Organisation Organisation
        {
            get { return _organisation; }
            set
            {
                this._organisation = value;
                if(value != null)
                {
                    value.Manager = this;
                }
            }
        }

        public override decimal Wage
        {
            get {
                return Wage + (Organisation.WinningsWithoutBonus() * Percentage);
            }
        }

        public void Print()
        {
            Console.WriteLine("Employees: ");
            Organisation.Employees.ForEach(e => Console.WriteLine("-----------\n" +
                                                                  $"{e.ToString()}"));
        }
    }
}
