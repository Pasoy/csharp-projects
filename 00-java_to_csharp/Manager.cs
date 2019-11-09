using System;

namespace vererb1_java {
    public class Manager : Employee
    {
        public decimal WeeklySalary
        {
            set;
            get;
        }

        // Konstruktoren
        public Manager(String n) : base(n)
        {
            WeeklySalary = 0;
        }

        public Manager()
        {
            WeeklySalary = 0;
        }

        public override decimal ComputePay()
        {
            return WeeklySalary;
        }

    }
}


