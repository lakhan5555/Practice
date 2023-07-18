using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph11
{
    public class Graph
    {
        public int V;
        public List<int>[] adj;
        public Graph(int Vertex)
        {
            this.V = Vertex;
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
        public List<List<int>> ConnectedComponentsInUndirectedGraph()
        {
            var visited = new bool[V];
            var connectedComponentsList = new List<List<int>>();
            for(int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    var temp = new List<int>();
                    ConnectedComponentsInUndirectedGraphUtil(i, visited, temp);
                    connectedComponentsList.Append(temp);
                }
            }
            return connectedComponentsList;
        }
        public void ConnectedComponentsInUndirectedGraphUtil(int src, bool[] visited, List<int> ccList)
        {
            visited[src] = true;
            ccList.Append(src);
            foreach (var item in adj[src])
                if (!visited[item])
                    ConnectedComponentsInUndirectedGraphUtil(item, visited, ccList);
        }
    }
}
