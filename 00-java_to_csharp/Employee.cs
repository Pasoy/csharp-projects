using System;

namespace vererb1_java
{
    public class Employee : IComparable<Employee>
    {
        // Attribute um Angestelltendaten zu speichern
        private String name;
        public String Name
        {
            set => name = value;
            get => name;
        }

        // Konstruktoren
        public Employee()
        {
            Name = "Hugo";
        }

        public Employee(String n)
        {
            Name = n;
        }

        public override String ToString()
        {
            var name = this.GetType().Name;
            return Name + " is a " + name + " and earns " + this.Gehalt;
        }

        public decimal Gehalt { get { return this.ComputePay(); } }

        public virtual decimal ComputePay()
        {
            return 0;
        }

        public int CompareTo(Employee other)
        {
            return this.Name.CompareTo(other?.Name);
        }
    }
}


