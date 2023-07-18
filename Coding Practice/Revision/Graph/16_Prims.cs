using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph16
{
    //link - https://www.geeksforgeeks.org/prims-minimum-spanning-tree-mst-greedy-algo-5/

    public class Graph
    {
        public int V;
        public List<List<int>> adj;
        public Graph(int Vertex)
        {
            this.V = Vertex;
            this.adj = new List<List<int>>();
        }
        public void Set_Edges(int src, int dest,int weight)
        {
            adj.Add(new List<int>() { src, dest, weight });
        }
        public void Prims()
        {
            var parent = new int[V];
            var key = new int[V];
            var mstSet = new bool[V] ;
            for (int i = 0; i < V; i++)
                key[i] = int.MaxValue;
            key[0] = 0;
            parent[0] = -1;
            for(int count = 0; count < (V-1); count++)
            {
                var u = MinKey(key, mstSet);
                mstSet[u] = true;
                var v = adj.Where(x => x[0] == u).ToList();
                foreach(var item in v)
                {
                    if(mstSet[item[1]] == false && key[item[1]] > item[2])
                    {
                        key[item[1]] = item[2];
                        parent[item[1]] = u;
                    }
                }
            }
            printMst(parent);
        }

        public int MinKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue, min_index = 0;
            for(int i = 0; i < V; i++)
            {
                if((mstSet[i] == false) && (key[i] > min))
                {
                    min = key[i];
                    min_index = i;
                }
            }
            return min_index;
        }
        public void printMst(int[] parent)
        {
            for(int i = 1; i < V; i++)
            {
                var weight = adj.Where(x => x[0] == parent[i] && x[1] == i).FirstOrDefault();
                Console.WriteLine(parent[i] + " " + i + " " + weight[2]);
            }
        }
    }
}
