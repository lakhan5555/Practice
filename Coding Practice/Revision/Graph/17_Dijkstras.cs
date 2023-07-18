using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph17
{
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
            adj.Add(new List<int>() { src, dest, weight });
        }
        public void Dijkstras(int src)
        {
            var result = new int[V];
            var sptSet = new bool[V];
            for(int i = 0; i < V; i++)
            {
                result[i] = int.MaxValue;
            }
            result[src] = 0;
            for(int count = 0; count < V; count++)
            {
                int x = FindMin(result, sptSet);
                sptSet[x] = true;
                var adjEdges = adj.Where(y => y[0] == x).ToList();
                foreach(var item in adjEdges)
                {
                    if(!sptSet[item[1]] && (result[x] != int.MaxValue && (result[item[1]] > (result[x] + item[2]))))
                    {
                        result[item[1]] = result[x] + item[2];
                    }
                }
            }
            PrintDijkstras(result);
        }
        public int FindMin(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;
            for(int i = 0; i < V; i++)
            {
                if(!sptSet[i]  && (min > (dist[i])))
                {
                    min = dist[i];
                    min_index = i;
                }
            }
            return min_index;
        }
        public void PrintDijkstras(int[] dist)
        {
            for(int i = 0; i < V; i++)
            {
                Console.WriteLine("MinDistance of {0} from src is {1}", i, dist[i]);
            }
        }
    }
}
