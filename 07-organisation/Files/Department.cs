using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.Files
{
    class Department : Organisation
    {
        public decimal Winnings { set; get; }

        public void AddWinnings(decimal winnings)
        {
            this.Winnings += winnings;
        }
    }
}
