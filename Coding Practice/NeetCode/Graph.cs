using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode
{
    public class Graph
    {
        #region Number of Islands
        //link - https://leetcode.com/problems/number-of-islands/

        public class Graph1
        {
            public List<List<int>> adj;
            public Graph1()
            {
                this.adj = new List<List<int>>();
            }
            public void Set_Edges(int src, int dest)
            {
                adj.Add(new List<int>() { src, dest });
            }
        }
        public int NumIslands(char[][] grid)
        {
            Graph1 g = new Graph1();
            int k = 0;
            int m = grid.Length;
            int n = grid[0].Length;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(grid[i][j] == '1')
                    {
                        if (IsSafe(i, j - 1, m, n, grid))
                            g.Set_Edges(k, k - 1);
                        if(IsSafe(i, j + 1, m, n, grid))
                            g.Set_Edges(k, k + 1);
                        if(IsSafe(i-1, j, m, n, grid))
                            g.Set_Edges(k, k - grid[i].Length);
                        if(IsSafe(i+1, j, m, n, grid))
                            g.Set_Edges(k, k + grid[i].Length);
                        if (IsSelfLoop(i, j - 1, m, n, grid) && IsSelfLoop(i, j + 1, m, n, grid) && IsSelfLoop(i - 1, j, m, n, grid) && IsSelfLoop(i + 1, j, m, n, grid))
                            g.Set_Edges(k, k);
                    }
                    k++;    
                }
            }
            bool[] visited = new bool[m*n];
            int count = 0;
            foreach(var item in g.adj)
            {
                if (!visited[item[0]])
                {
                    count++;
                    NumIslandsUtil(visited, g, item[0]);
                }
            }
            return count;
        }
        public void NumIslandsUtil(bool[] visited,Graph1 g, int src)
        {
            visited[src] = true;
            var adjacent = g.adj.Where(x => x[0] == src).ToList();
            foreach(var item in adjacent)
            {
                if (!visited[item[1]])
                    NumIslandsUtil(visited, g, item[1]);
            }
        }
        public bool IsSafe(int x, int y, int m, int n, char[][] grid)
        {
            return x >= 0 && x < m && y >= 0 && y < n && grid[x][y] == '1';
        }
        public bool IsSelfLoop(int x, int y, int m, int n, char[][] grid)
        {
            if (x < 0 || x >= m || y < 0 || y >= n)
                return true;
            return grid[x][y] == '0';
        }
        #endregion
    }
}
