using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Supermarket.Stuff
{
    class Person
    {
        // string
        private string Firstname { set; get; }
        private string Lastname { set; get; }
        private string Location { set; get; }
        // int
        private int Age { set; get; }
        private int Plz { set; get; }
        // decimal
        public decimal Money { set; get; }
        // char
        private char Gender { set; get; }

        public Person(string firstname, string lastname, string location, int age, int plz, decimal money, char gender)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Location = location;
            this.Age = age;
            this.Plz = plz;
            this.Money = money;
            this.Gender = gender;
        }

        public Person()
        {
            new Person("Pasoy", "King", "Spengergasse", 18, 1050, 10.0m, 'M');
        }

        public string Name()
        {
            return Firstname + " " + Lastname;
        }

        public override string ToString()
        {
            return $"Name: {Firstname} {Lastname}, Age: {Age}, Location: {Location}, PLZ: {Plz}";
        }
    }
}
