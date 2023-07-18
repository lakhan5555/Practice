using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph2
{
    public class Node
    {
        public int val;
        public Node next;
        public Node(int data)
        {
            this.val = data;
            this.next = null;
        }
    }
    public class Graph
    {
        public int Vertex;
        public Node[] Arr;
        public Graph(int Vertex)
        {
            this.Vertex = Vertex;
            this.Arr = new Node[Vertex];
        }
        public void Set_Edges(int src,int dest)
        {
            // considering directed graph
            Node node = new Node(dest);
            node.next = Arr[src];
            Arr[src] = node;
        }
        public void BFS(int src)
        {
            var visisted = new bool[Vertex];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(src);
            visisted[src] = true;
            while(queue.Count > 0)
            {
                var curr = queue.Dequeue();
                Console.WriteLine(curr);
                var temp = Arr[curr];
                while(temp != null)
                {
                    if (!visisted[temp.val])
                    {
                        visisted[temp.val] = true;
                        queue.Enqueue(temp.val);
                        temp = temp.next;
                    }
                }
            }
        }
    }
}
