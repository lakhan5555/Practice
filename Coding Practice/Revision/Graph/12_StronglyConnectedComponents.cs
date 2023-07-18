using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph12
{
    //link - https://www.geeksforgeeks.org/strongly-connected-components/

    public class Graph
    {
        public int V;
        public List<int>[] adj;
        public Graph(int Vertex)
        {
            this.V = Vertex;
            this.adj = new List<int>[Vertex];
            for (int i = 0; i < V; i++)
                adj[i] = new List<int>();
        }
        public void Set_Edges(int src,int dest)
        {
            adj[src].Append(dest);
        }
        public void Kosaraju()
        {
            var visited = new bool[V];
            var stack = new Stack<int>();
            for (int i = 0; i < V; i++)
                if (!visited[i])
                    FillOrder(i, visited, stack);
            Graph g = GetTranpose();
            visited = new bool[V];
            while(stack.Count > 0)
            {
                var temp = stack.Pop();
                if (!visited[temp])
                {
                    DFSUtil(temp, visited);
                    Console.WriteLine();
                }
            }
        }
        public void FillOrder(int src,bool[] visited, Stack<int> stack)
        {
            visited[src] = true;
            foreach (var item in adj[src])
                if (!visited[item])
                    FillOrder(item, visited, stack);
            stack.Push(src);
        }
        public Graph GetTranpose()
        {
            Graph g = new Graph(V);
            for(int i = 0; i < V; i++)
            {
                foreach(var item in adj[i])
                {
                    g.Set_Edges(item, i);
                }
            }
            return g;
        }
        public void DFSUtil(int src,bool[] visited)
        {
            visited[src] = true;
            Console.Write(src + " ");
            foreach (var item in adj[src])
                if (!visited[item])
                    DFSUtil(item, visited);
        }
    }
}
