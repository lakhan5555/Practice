using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph4
{
    public  class Graph
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
        public void Set_Edges(int src,int dest)
        {
            adj[src].Append(dest);
            adj[dest].Append(src);
        }
        public bool CycleInUndirectedGraph()
        {
            var visited = new bool[Vertex];
            for(int i = 0; i < Vertex; i++)
            {
                if (!visited[i])
                {
                    if (CycleInUndirectedGraphUtil(i, visited, -1))
                        return true;
                }
            }
            return false;
        }
        public bool CycleInUndirectedGraphUtil(int src, bool[] visited, int parent)
        {
            visited[src] = true;
            foreach(var item in adj[src])
            {
                if (!visited[item])
                {
                    if (CycleInUndirectedGraphUtil(item, visited, src))
                        return true;
                }
                else if (item != parent)
                    return true;
            }
            return false;
        }
    }
}
