using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph3
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
        public void DFS(int src)
        {
            var visisted = new bool[Vertex];
            DfsUtil(src, visisted);

        }
        public void DfsUtil(int src, bool[] visited)
        {
            visited[src] = true;
            Console.Write(src + " ");
            
            foreach(var item in adj[src])
            {
                if (!visited[item])
                    DfsUtil(item,visited);
            }
        }
    }
}
