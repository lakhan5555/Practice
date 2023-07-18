using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph18
{
    public class Graph
    {
        public void FloodFill(int[,] matrix, int x, int y, int newC)
        {
            int m = matrix.GetUpperBound(0);
            int n = matrix.GetUpperBound(1);
            int prevC = matrix[x, y];
            FloodFillUtil(matrix, x, y, newC, prevC, m, n);
        }
        public void FloodFillUtil(int[,] matrix, int x, int y, int newC, int prevC,int m, int n)
        {
            if (x < 0 || x >= m || y < 0 || y >= n || matrix[x, y] != prevC || matrix[x, y] == newC)
                return;
            matrix[x, y] = newC;
            FloodFillUtil(matrix, x-1, y, newC, prevC, m, n);
            FloodFillUtil(matrix, x, y-1, newC, prevC, m, n);
            FloodFillUtil(matrix, x+1, y, newC, prevC, m, n);
            FloodFillUtil(matrix, x, y+1, newC, prevC, m, n);
        }
    }
}
