using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph21
{
    //link - https://www.geeksforgeeks.org/find-whether-path-two-cells-matrix/

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
            adj[src].Add(dest);
        }
        public bool FindPath(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int s = 0;
            int d = 0;
            Graph g = new Graph(m*n+1);
            int k = 1; 

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(matrix[i,j] != 0)
                    {
                        if (IsSafe(i, j + 1, m, n))
                            g.Set_Edges(k, k + 1);
                        if (IsSafe(i, j - 1, m, n))
                            g.Set_Edges(k, k - 1);
                        if (IsSafe(i + 1, j, m, n))
                            g.Set_Edges(k, k + n);
                        if (IsSafe(i - 1, j, m, n))
                            g.Set_Edges(k, k - 1);
                    }
                    if (matrix[i, j] == 1)
                        s = k;
                    if (matrix[i, j] == 2)
                        d = k;
                    k++;
                }
            }
            return FindPathUtil(g,s,d);
        }
        public bool IsSafe(int x, int y, int m, int n)
        {
            return x >= 0 && x < m && y >= 0 && y < n;
        }
        public bool FindPathUtil(Graph g, int s, int d)
        {
            if (s == d)
                return true;
            var visited = new bool[V];
            var q = new Queue<int>();
            q.Enqueue(s);
            visited[s] = true;
            while(q.Count > 0)
            {
                var temp = q.Dequeue();
                foreach(var item in adj[temp])
                {
                    if (item == d)
                        return true;
                    if (!visited[item])
                    {
                        visited[item] = true;
                        q.Enqueue(item);
                    }
                }
            }
            return false;
        }
    }
}
