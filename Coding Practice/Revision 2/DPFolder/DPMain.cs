using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision_2.DPFolder
{
    public class DPMain
    {
        public void main()
        {
            int[] weight = { 4, 5, 1 };
            int[] profit = {1,2, 3 };
            var a = new DP().ZeroOneKnapsackRecur(weight, 4, profit, 3);
        }
    }
}
