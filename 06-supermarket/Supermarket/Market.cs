using Supermarket.Supermarket.Stuff;
using Supermarket.Supermarket.Stuff.Persons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Supermarket
{
    class Market
    {
        // boss
        private Boss Boss { set; get; }
        // string
        private string Name { set; get; }
        private string Location { set; get; }
        // list
        private List<Product> products = new List<Product>();
        public List<Product> Products { set => products = value; get => products; }
        private List<Employee> employees = new List<Employee>();
        public List<Employee> Employees { set => employees = value; get => employees; }
        // decimal
        private decimal Money { set; get; }

        public Market(Boss boss, string name, string location, List<Product> products, List<Employee> employees, decimal money)
        {
            this.Boss = boss;
            this.Name = name;
            this.Location = location;
            this.Products = products;
            this.Employees = employees;
            this.Money = money;
        }

        public Market(Boss boss)
        {
            this.Boss = boss;
            this.Name = "Paso Market";
            this.Location = "Reumannplatz";
            this.Products = products;
            this.Employees = employees;
            this.Money = 1000.0m;
        }

        public void Hire(Employee employee)
        {
            Employees.Add(employee);
            Boss.Staff.Add(employee);
        }

        public void Fire(Employee employee)
        {
            Employees.Remove(employee);
            Boss.Staff.Remove(employee);
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public void Print()
        {
            Employees.ForEach(employee => Console.WriteLine(employee.ToString()) );
            Products.ForEach(product => Console.WriteLine(product.ToString()) );
        }

        public decimal EmployeesCost()
        {
            decimal sum = 0.0m;

            Employees.ForEach(employee => sum += employee.Wage());

            return sum;
        }

        public decimal ProductsValue()
        {
            decimal sum = 0.0m;

            //products.ForEach(product => sum += product.Price);
            sum = (from product in Products
                   select product.Price).Sum();

            return sum;
        }

        public bool Buy(Product product, int amount)
        {
            if(Money >= product.Price * amount)
            {
                product.Stock += amount;
                Money -= product.Price * amount;
                return true;
            }
            return false;
        }

        public bool Sell(Product product, Buyer buyer)
        {
            if (buyer.Money >= product.Price && product.Stock > 0)
            {
                buyer.Products.Add(product);
                buyer.Money -= product.Price;
                product.Stock--;
                Money += product.Price;
                return true;
            }
            return false;
        }


    }
}
