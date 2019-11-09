using System;
using System.Collections.Generic;
using System.Linq;

namespace vererb1_java
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp2 = new Employee();
            WageEmployee wemp2 = new WageEmployee("Fred");
            SalesPerson semp2 = new SalesPerson("Wilma");
            Manager man2 = new Manager("Boss");

            wemp2.Wage = 224;
            wemp2.Hours = 24;
            semp2.SalesMade = (1234);
            semp2.Commission = (0.3M);
            semp2.Wage = (224);
            semp2.Hours = (24);
            man2.WeeklySalary = ((decimal) 2500.5);

            var c1 = new List<Employee>
            {
                emp2,
                wemp2,
                semp2,
                man2
            };

            //c1.ForEach(e => Console.WriteLine(e));
            foreach (var item in c1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            /*
             * GEHALT PROZENT MIT FORMAT
             */
            decimal sum = c1.Sum(e => e.Gehalt);
            //foreach (var item in c1) sum += item.Gehalt;
            foreach (var item in c1)
            {
                Console.WriteLine("{0,-6} {1,6:f1} which is {2,5:f2}% von {3}", item.Name, item.Gehalt, item.Gehalt / sum * 100, sum);
            }

            /*
             * SORT 1 - GEHALT
             */
            Console.WriteLine();
            Console.WriteLine("--- Sort1   Name ---");
            c1.Sort();
            foreach (var item in c1)
            {
                Console.WriteLine(item);
            }

            /*
             * SORT 2 - GEHALT
             */
            Console.WriteLine();
            Console.WriteLine("--- Sort2   Gehalt ---");
            c1.Sort(new Vergleicher());
            foreach (var item in c1)
            {
                Console.WriteLine(item);
            }

            /*
             * SORT 3 - NAMENSLÄNGE
             */
            Console.WriteLine();
            Console.WriteLine("--- Sort3   Namenslänge desc ---");
            //c1.Sort(Vergleiche);
            c1.Sort((x, y) => x.Name.Length.CompareTo(y?.Name.Length));
            foreach (var item in c1)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }

        /*
        private static int Vergleiche(Employee x, Employee y)
        {
            return x.Name.Length.CompareTo(y?.Name.Length);
        }
        */
    }

    internal class Vergleicher : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x == null ? (y == null ? 0 : -1) : x.Gehalt.CompareTo(y?.Gehalt);
        }
    }
}
