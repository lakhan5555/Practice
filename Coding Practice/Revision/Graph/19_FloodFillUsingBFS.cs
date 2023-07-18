using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph19
{
    public class Graph
    {
        public void FloodFillUsingBFS(int[,] matrix, int x, int y, int newC)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(x, y));
            int prevC = matrix[x, y];
            int m = matrix.GetUpperBound(0);
            int n = matrix.GetUpperBound(1);
            matrix[x, y] = newC;
            while(queue.Count > 0)
            {
                var temp = queue.Dequeue();
                var posX = temp.Item1;
                var posY = temp.Item2;
                if (IsValid(matrix, posX-1, posY, newC, prevC, m, n))
                {
                    matrix[posX - 1, posY] = newC;
                    queue.Enqueue(new Tuple<int, int>(posX - 1, posY));
                }
                if (IsValid(matrix, posX , posY-1, newC, prevC, m, n))
                {
                    matrix[posX, posY-1] = newC;
                    queue.Enqueue(new Tuple<int, int>(posX, posY-1));
                }
                if (IsValid(matrix, posX+1, posY, newC, prevC, m, n))
                {
                    matrix[posX + 1, posY] = newC;
                    queue.Enqueue(new Tuple<int, int>(posX + 1, posY));
                }
                if (IsValid(matrix, posX, posY+1, newC, prevC, m, n))
                {
                    matrix[posX, posY+1] = newC;
                    queue.Enqueue(new Tuple<int, int>(posX, posY+1));
                }
            }
        }
        public bool IsValid(int[,] matrix, int x, int y, int newC, int prevC, int m, int n)
        {
            if (x < 0 || x >= m || y < 0 || y >= n || matrix[x, y] != prevC || matrix[x, y] == newC)
                return false;
            return true;
        }
    }
}
