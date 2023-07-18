using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph5
{
    public class Graph
    {
        public int Vertex;
        public List<int>[] adj;
        public Graph(int Vertex)
        {
            this.Vertex = Vertex;
            this.adj = new List<int>[Vertex];
            for(int i = 0; i < Vertex; i++)
            {
                adj[i] = new List<int>();
            }
        }
        public void Set_Edges(int src, int dest)
        {
            adj[src].Append(dest);
            adj[dest].Append(src);
        }
        public bool IsCyclic()
        {
            var visited = new bool[Vertex];
            for(int i = 0; i < Vertex; i++)
            {
                if (!visited[i])
                {
                    if (IsCyclicUtil(i, visited))
                        return true;
                }
            }
            return false;
        }
        public bool IsCyclicUtil(int src, bool[] visited)
        {
            var queue = new Queue<int>();
            visited[src] = true;
            queue.Enqueue(src);
            var parent = new int[Vertex];
            for(int i = 0; i < Vertex; i++)
            {
                parent[i] = -1;
            }
            while(queue.Count > 0)
            {
                var curr = queue.Dequeue();
                foreach(var item in adj[curr])
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        parent[item] = curr;
                        queue.Enqueue(item);
                    }
                    else if (item != parent[curr])
                        return true;
                }
            }
            return false;
        }
    }
}
