using logic_gates.Operators;
using System;
using System.Collections.Generic;
using System.Text;

namespace logic_gates
{
    class Bit : Component
    {
        public string Name { set; get; }
        private bool Value { set; get; }

        public Bit(string Name, bool Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public bool TruthValue()
        {
            return Value;
        }
    }
}
