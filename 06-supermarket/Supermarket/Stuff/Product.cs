using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Supermarket.Stuff
{
    class Product
    {
        // int 
        private int ID { set; get; }
        public int Price { set; get; }
        public int Stock { set; get; }
        // string
        private string Name { set; get; }
        // bool
        private bool Restriction { set; get; }

        // constructor
        public Product(int id, int price, int stock, string name, bool restriction)
        {
            this.ID = id;
            this.Price = price;
            this.Stock = stock;
            this.Name = name;
            this.Restriction = restriction;
        }

        // default constructor
        public Product()
        {
            ID = 1;
            Price = 5;
            Stock = 150;
            Name = "Apple";
            Restriction = false;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Price: {Price}, Stock: {Stock}, Name: {Name}, Restriction: {Restriction}";
        }
    }
}
