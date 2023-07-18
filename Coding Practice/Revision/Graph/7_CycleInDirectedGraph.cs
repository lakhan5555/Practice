using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph6
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
        }
        public bool IsCyclic()
        {
            var visited = new bool[Vertex];
            var recursionStack = new bool[Vertex];

            for(int i = 0; i < Vertex; i++)
            {
                if (!visited[i])
                    if (IsCyclicUtil(i, visited, recursionStack))
                        return true;
            }
            return false;
        }
        public bool IsCyclicUtil(int src, bool[] visited, bool[] recursionStack)
        {
            visited[src] = true;
            recursionStack[src] = true;
            foreach(var item in adj[src])
            {
                if (!visited[item])
                {
                    if (IsCyclicUtil(item, visited, recursionStack))
                        return true;
                }
                else if (recursionStack[item])
                    return true;
            }
            recursionStack[src] = false;
            return false;
        }
    }
}
