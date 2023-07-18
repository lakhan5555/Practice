
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.LinkedListFolder
{
    public class Main
    {
        public void main()
        {
            Node node = new Node(3);
            node.next= new Node(6);
            node.next.next= new Node(9);
            node.next.next.next = new Node(15);
            node.next.next.next.next = new Node(30);

            Node node2 = new Node(10);
            node2.next = node.next.next.next;

            //var ans1 = new LinkedList().getMiddle(node);
            var ans2 = new LinkedList().intersectPoint(node, node2);
        }
    }
}
