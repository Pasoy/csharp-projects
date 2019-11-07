using Organisation.Files.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.Files.Persons
{
    class Buyer : Person
    {
        public decimal YearlyWage { set; get; }
        public decimal CreditLimit { set; get; }
        

        public Buyer(string name, string address, int age, Gender gender) : base(name, address, age, gender) { }
    
        public Buyer(string name, string address, int age, Gender gender, decimal yearlyWage, decimal creditLimit) : base(name, address, age, gender)
        {
            this.YearlyWage = yearlyWage;
            this.CreditLimit = creditLimit;
        }

        public Buyer() : this("Buyer", "Spengergasse", 18, Gender.FEMALE, 25000.0m, 10000.0m) { }
    }
}
