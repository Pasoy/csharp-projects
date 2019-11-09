using System;

namespace vererb1_java {
    public class WageEmployee : Employee
    {
        public decimal Wage
        {
            set;
            get;
        }
        public decimal Hours
        {
            set;
            get;
        }

        public WageEmployee(String n) : base(n)
        {
            Wage = 0;
            Hours = 0;
        }
   

        public WageEmployee()
        {
            Wage = 0;
            Hours = 0;
        }

        public override decimal ComputePay()
        {
            return Wage * Hours;
        }

    }
}


