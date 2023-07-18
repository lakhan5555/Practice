using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph8
{
    // solution - https://gist.github.com/jianminchen/c328dbc4391cb03a9ab8665b3ab54966
    public class GraphNode
    {
        public int val;
        public List<GraphNode> neighbours;
        public GraphNode(int val)
        {
            this.val = val;
            neighbours = new List<GraphNode>();
        }
    }
    public class Graph
    {
        public GraphNode CloneGraph(GraphNode node)
        {
            Queue<GraphNode> queue = new Queue<GraphNode>();
            queue.Enqueue(node);

            Dictionary<GraphNode, GraphNode> dict = new Dictionary<GraphNode, GraphNode>();

            GraphNode newHead = new GraphNode(node.val);
            dict.Add(node, newHead);

            while(queue.Count > 0)
            {
                var curr = queue.Dequeue();
                foreach(var item in curr.neighbours)
                {
                    if (!dict.ContainsKey(item))
                    {
                        GraphNode copy = new GraphNode(item.val);
                        dict.Add(item, copy);
                        dict[curr].neighbours.Add(copy);
                        queue.Enqueue(item);
                    }
                    else
                    {
                        dict[curr].neighbours.Add(dict[item]);
                    }
                }
            }
            return newHead;
        }
    }
}
