using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Supermarket.Stuff.Persons
{
    class Buyer : Person
    {
        private int ID { set; get; }
        private int Age { set; get; }
        public List<Product> Products { set; get; }

        public Buyer(int id, string firstname, string lastname, string location, int age, int plz, decimal money, char gender) : base(firstname, lastname, location, age, plz, money, gender)
        {
            this.ID = id;
            this.Age = age;
        }

        public Buyer() : base("Buyer1", "Buyer11", "Spengergasse", 30, 1050, 10.0m, 'W')
        {
            this.ID = 1;
        }

        public override String ToString()
        {
            return base.ToString() + $"Kunden ID: {ID}";
        }
    }
}
