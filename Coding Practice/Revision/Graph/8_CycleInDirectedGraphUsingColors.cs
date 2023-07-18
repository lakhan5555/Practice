using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph7
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
        public bool IsCyclic()
        {
            var colors = new string[Vertex];
            for (int i = 0; i < Vertex; i++)
                colors[i] = "WHITE";
            for(int i = 0; i < Vertex; i++)
            {
                if(colors[i] == "WHITE")
                {
                    if (IsCyclicUtil(i, colors))
                        return true;
                }
            }
            return false;
        }
        public bool IsCyclicUtil(int src,string[] colors)
        {
            colors[src] = "GREY";
            foreach(var item in adj[src])
            {
                if (colors[item] == "GREY")
                    return true;
                if (colors[item] == "WHITE" && IsCyclicUtil(item, colors))
                    return true;
            }
            colors[src] = "BLACK";
            return false;
        }
    }
}
