using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.Files
{
    class Project : Organisation
    {
        public int PlannedTime { set; get; } = 1;
        public int PlannedLifeTime { set; get; } = 0;
        public new decimal Winnings { set; get; } = 0.0m;


        public override decimal WinningsWithoutBonus()
        {
            var res = (Winnings * PlannedLifeTime) / (PlannedTime * 12) - CostsWithoutBonus();
            return res;
        }
        
    }
}
