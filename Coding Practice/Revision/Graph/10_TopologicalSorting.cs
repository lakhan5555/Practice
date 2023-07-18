using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph10
{
    //Topological sorting for Directed Acyclic Graph(DAG) is a linear ordering of vertices such that for every directed edge u v, 
    //vertex u comes before v in the ordering.
    //Note: Topological Sorting for a graph is not possible if the graph is not a DAG.

    public class Graph
    {
        public int V;
        public List<int>[] adj;
        public Graph(int Vertex)
        {
            this.V = Vertex;
            adj = new List<int>[Vertex];
            for(int i = 0; i < Vertex; i++)
            {
                adj[i] = new List<int>();
            }
        }
        public void Set_Edges(int src, int desc)
        {
            adj[src].Append(desc);
        }
        public void TopologicalSorting()
        {
            var visited = new bool[V];
            var stack = new Stack<int>();
            for(int i = 0; i < V; i++)
            {
                if (!visited[i])
                    TopologicalSortingUtil(i, visited, stack);
            }
            foreach (var item in stack)
                Console.Write(item + " ");
        }
        public void TopologicalSortingUtil(int src, bool[] visited, Stack<int> stack)
        {
            visited[src] = true;
            foreach(var item in adj[src])
            {
                if (!visited[item])
                    TopologicalSortingUtil(item, visited, stack);
            }
            stack.Push(src);
        }
    }
}
