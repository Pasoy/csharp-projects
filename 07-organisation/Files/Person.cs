using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.Files
{
    class Person
    {
        public string Name { set; get; }
        public string Address { set; get; }
        public string Salutation { get { return GetSalutation(); } }
        public int Age { set; get; }
        public int YearOfBirth { get { return GetYearOfBirth(); } }
        public char Gender { set; get; }

        public Person(string name, string address, int age, char gender)
        {
            this.Name = name;
            this.Address = address;
            this.Age = age;
            this.Gender = gender;
        }

        public Person() : this("Pasoy", "Spengergasse", 18, 'M') { }

        private string GetSalutation()
        {
            if (Gender.Equals('M'))
            {
                return "Mr.";
            }
            else if (Gender.Equals('W'))
            {
                return "Ms.";
            }

            return "Other";
        }

        private int GetYearOfBirth()
        {
            int actualYear = DateTime.Today.Year;

            return actualYear - Age;
        }

        public override string ToString()
        {
            return $"Name: {Salutation} {Name}, Address: {Address}, Age: {Age}, Born: {YearOfBirth}, Gender: {Gender}";
        }
    }
}
