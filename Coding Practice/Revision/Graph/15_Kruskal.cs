using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph15
{
    //link - https://www.geeksforgeeks.org/kruskals-minimum-spanning-tree-algorithm-greedy-algo-2/

    public class Graph
    {
        public int V;
        public List<List<int>> adj;
        public Graph(int Vertex)
        {
            this.V = Vertex;
            this.adj = new List<List<int>>();
        }
        public void Set_Edges(int src, int dest, int weight)
        {
            var edge = new List<int>() { src, dest, weight };
            this.adj.Add(edge);
        }
        public class Subset
        {
            public int parent;
            public int rank;
        }
        public List<List<int>> Kruskal()
        {
            var result = new List<List<int>>();
            int e = 0, i = 0;
            var subsets = new Subset[V];
            for(i = 0; i < V; i++)
            {
                subsets[i] = new Subset();
                subsets[i].parent = i;
                subsets[i].rank = 0;
            }
            adj = adj.OrderBy(x => x[2]).ToList();
            i = 0;
            while(e < (V - 1))
            {
                int src = adj[i][0];
                int dest = adj[i][1];
                int x = Find(subsets, src);
                int y = Find(subsets, dest);
                if(x != y)
                {
                    result.Add(new List<int>() { src, dest, adj[i][2] });
                    Union(subsets, x, y);
                    e++;
                }
                i++;
            }
            return result;
        }
        public int Find(Subset[] subsets, int x)
        {
            if (x != subsets[x].parent)
                subsets[x].parent = Find(subsets, subsets[x].parent);
            return subsets[x].parent;
        }
        public void Union(Subset[] subsets, int x, int y)
        {
            var xRoot = Find(subsets, x);
            var yRoot = Find(subsets, y);
            if (subsets[xRoot].rank > subsets[yRoot].rank)
                subsets[yRoot].parent = xRoot;
            else if (subsets[xRoot].rank < subsets[yRoot].rank)
                subsets[xRoot].parent = yRoot;
            else
            {
                subsets[xRoot].parent = yRoot;
                subsets[yRoot].rank++;
            }
        }
    }
}
