using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph13
{
    //link - https://www.geeksforgeeks.org/union-find/

    public class Graph
    {
        public int V;
        public List<int>[] adj;
        public Graph(int Vertex)
        {
            this.V = Vertex;
            this.adj = new List<int>[Vertex];
            for (int i = 0; i < Vertex; i++)
                adj[i] = new List<int>();
        }
        public void Set_Edges(int src, int dest)
        {
            adj[src].Append(dest);
        }
        public bool IsCyclic()
        {
            var parent = new int[V];
            for(int i = 0; i < V; i++)
            {
                var parentOfSrc = Find(parent, i);
                foreach (var item in adj[i])
                {
                    var parentOfDest = Find(parent, item);
                    if (parentOfSrc == parentOfDest)
                        return true;
                    Union(parent, parentOfSrc, parentOfDest);
                }
            }
            return false;
        }
        public int Find(int[] parent, int x)
        {
            if (x == parent[x])
                return x;
            return Find(parent, parent[x]);
        }
        public void Union(int[] parent, int x, int y)
        {
            parent[x] = y;
        }
    }
}
