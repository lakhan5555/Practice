using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph14
{
    //link - https://www.geeksforgeeks.org/union-find-algorithm-set-2-union-by-rank/

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
        public class SubSet
        {
            public int parent;
            public int rank;
        }
        public bool IsCyclic()
        {
            var subsets = new SubSet[V];
            for(int i = 0; i < V; i++)
            {
                subsets[i] = new SubSet();
                subsets[i].parent = i;
                subsets[i].rank = 0;
            }
            for(int i = 0; i < V; i++)
            {
                var srcRoot = Find(subsets, i);
                foreach(var item in adj[i])
                {
                    var destRoot = Find(subsets, item);
                    if (srcRoot == destRoot)
                        return true;
                    Union(subsets, srcRoot, destRoot);
                }
            }
            return false;
        }
        public int Find(SubSet[] subsets, int x)
        {
            if (x != subsets[x].parent)
                subsets[x].parent = Find(subsets, subsets[x].parent);
            return subsets[x].parent;
        }
        public void Union(SubSet[] subsets, int x, int y)
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
