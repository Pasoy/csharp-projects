using System;

namespace vererb1_java
{

    public class SalesPerson : WageEmployee
    {
        public String Name { get; set; }
        public decimal Commission { get; set; }
        public decimal SalesMade { get; set; }

 	    // Konstruktoren
        public SalesPerson(String n) : base(n)
        {
            Commission = 0;
            SalesMade = 0;
        }
        public SalesPerson()
        {
            Commission = 0;
            SalesMade = 0;
        }

        public override decimal ComputePay()
        {
            return (decimal) (Commission * SalesMade + base.ComputePay());
        }
    }
}

