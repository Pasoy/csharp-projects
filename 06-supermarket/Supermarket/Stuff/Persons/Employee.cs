using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Supermarket.Stuff.Persons
{
    class Employee : Person
    {
        // int
        private int ID { set; get; }
        // decimal
        public decimal Hours { set; get; }
        public decimal HourWage { set; get; }

        public Employee(int id, decimal hours, decimal hourWage, string firstname, string lastname, string location, int age, int plz, decimal money, char gender) : base(firstname, lastname, location, age, plz, money, gender)
        {
            this.ID = id;
            this.Hours = hours;
            this.HourWage = hourWage;
        }

        public Employee() : base()
        {
            Hours = 40.0m;
            HourWage = 20.0m;
        }

        public decimal Wage()
        {
            return Hours * HourWage;
        }

        public override string ToString()
        {
            return base.ToString() + $", Hours: {Hours}, Hour Wage: {HourWage}";
        }

        public int CompareTo(Employee other)
        {
            return Hours.CompareTo(other.Hours);
        }
    }
}