using System;
using System.Collections.Generic;
using System.Text;

namespace logic_gates.Operators
{
    class NAND : Component
    {
        private Component Gate1 { set; get; }
        private Component Gate2 { set; get; }

        public NAND(Component Gate1, Component Gate2)
        {
            this.Gate1 = Gate1;
            this.Gate2 = Gate2;
        }

        public bool TruthValue()
        {
            if (Gate1.TruthValue() == true && Gate2.TruthValue() == true) return false;

            return true;
        }
    }
}
