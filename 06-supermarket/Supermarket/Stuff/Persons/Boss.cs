
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Supermarket.Supermarket.Stuff.Persons
{
    class Boss : Employee
    {
        private List<Employee> staff = new List<Employee>();
        public List<Employee> Staff { set => staff = value; get => staff; }

        public Boss(int id, decimal hours, decimal hourWage, string firstname, string lastname, string location, int age, int plz, decimal money, char gender) : base(id, hours, hourWage, firstname, lastname, location, age, plz, money, gender) {}

        public Boss() : base(1, 40.0m, 30.0m, "Pasoy", "ActualKing", "Spengergasse", 20, 1050, 3000.0m, 'M') {}

        public int StaffAmount()
        {
            return Staff.Count;
        }

        public override string ToString()
        {
            string staff = "";
            Staff.ForEach(employee => staff += employee.Name() + ", ");

            return base.ToString() + $" Untergebene vom Chef: {staff}";
        }
    }
}
