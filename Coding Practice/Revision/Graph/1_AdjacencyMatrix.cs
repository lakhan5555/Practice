using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph
{
    public class Graph
    {
        public int Vertex;
        public int[,] Matrix;
        public Dictionary<string, int> Vertices;
        public string[] VertexList;
        public Graph(int vertex)
        {
            this.Matrix = new int[vertex, vertex];
            this.Vertex = vertex;
            this.Vertices = new Dictionary<string, int>();
            this.VertexList = new string[vertex];
        }
        public void Set_Vertex(int vtx, string id)
        {
            if (vtx >= 0 && vtx < Vertex)
            {
                Vertices.Add(id, vtx);
                VertexList[vtx] = id;
            }
        }
        public void Set_Edge(string from, string to, int cost = 0)
        {
            int fromInt = Vertices[from];
            int toInt = Vertices[to];
            Matrix[fromInt, toInt] = cost;
            Matrix[toInt, fromInt] = cost;                // for undirected graph
        }
        public string[] Get_Vertices()
        {
            return VertexList;
        }
        public List<Tuple<string, string, int>> Get_Edges()
        {
            var EdgeList = new List<Tuple<string, string, int>>();
            int uBound0 = Matrix.GetUpperBound(0);
            int uBound1 = Matrix.GetUpperBound(1);
            for (int i = 0; i < uBound0; i++)
            {
                for (int j = 0; j < uBound1; j++)
                {
                    if (Matrix[i, j] != 0)
                    {
                        Tuple<string, string, int> edge = Tuple.Create(VertexList[i], VertexList[j], Matrix[i, j]);
                        EdgeList.Append(edge);
                    }
                }
            }
            return EdgeList;
        }
    }
}
