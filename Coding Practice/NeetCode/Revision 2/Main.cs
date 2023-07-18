using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision_2
{
    public class Main
    {
        public void main()
        {
            int[] preOrder = { 3, 9, 20, 15, 7 };
            int[] inOrder = { 9, 3, 15, 20, 7 };
            var a = new Trees().BuildTree(preOrder, inOrder);
        }
    }
}
