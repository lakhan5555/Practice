using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.TreeFolder
{
    public class Main
    {
        public static void main()
        {
            Node root = new Node(1);
            root.left= new Node(3);
            root.right= new Node(2);
            var a = new Tree().bottomView(root);
        }
    }
}
