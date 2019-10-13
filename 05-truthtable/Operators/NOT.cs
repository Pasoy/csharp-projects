using System;
using System.Collections.Generic;
using System.Text;

namespace logic_gates.Operators
{
    class NOT : Component
    {
        private Component Gate1 { set; get; }

        public NOT(Component Gate1)
        {
            this.Gate1 = Gate1;
        }

        public bool TruthValue()
        {
            return !Gate1.TruthValue();
        }
    }
}
