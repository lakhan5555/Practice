using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph1
{
    public class Node1
    {
        public int val;
        public Node1 next;
        public Node1(int data)
        {
            this.val = data;
            this.next = null;
        }
    }
    class Graph
    {
        public int Vertex;
        public Node1[] Array;
        public Graph(int Vertex)
        {
            this.Vertex = Vertex;
            this.Array = new Node1[Vertex];
        }
        public void Set_Edge(int src, int dest)
        {
            Node1 destNode = new Node1(dest);
            destNode.next = Array[src];
            Array[src] = destNode;

            // for undirected graph
            Node1 srcNode = new Node1(src);
            srcNode.next = Array[dest];
            Array[dest] = srcNode;
        }
        public Dictionary<int, Node1> Get_Egdes()
        {
            Dictionary<int, Node1> dict = new Dictionary<int, Node1>();
            for (int i = 0; i < Vertex; i++)
            {
                dict.Add(i, Array[i]);
            }
            return dict;
        }
    }
}
