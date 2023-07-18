using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision.Graph
{
    //link - https://www.geeksforgeeks.org/shortest-path-in-a-binary-maze/

    public class _20_ShortestPathInaBinaryMaze
    {
        public class Point
        {
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public class QueueNode
        {
            public Point pt;
            public int dist;
            public QueueNode(Point pt, int dist)
            {
                this.pt = pt;
                this.dist = dist;
            }
        }
        public bool IsValid(int x, int y, int m, int n)
        {
            return x >= 0 && x < m && y >= 0 && y < n;
        }
        public int ShortestPathInaBinaryMaze(int[,] matrix, Point src, Point dest)
        {
            if (matrix[src.x, src.y] != 1 || matrix[dest.x, dest.y] != 1)
                return -1;
            int[] row = { -1, 0, 1, 0 };
            int[] col = { 0, -1, 0, 1 };
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            var visited = new bool[m, n];
            Queue<QueueNode> q = new Queue<QueueNode>();
            var s = new QueueNode(src, 0);
            q.Enqueue(s);
            visited[src.x, src.y] = true;
            while(q.Count > 0)
            {
                var temp = q.Dequeue();
                if (temp.pt.x == dest.x && temp.pt.y == dest.y)
                    return temp.dist;
                for(int i = 0; i < 4; i++)
                {
                    int r = temp.pt.x + row[i];
                    int c = temp.pt.y + col[i];
                    if(IsValid(r,c,m,n) && matrix[r,c] == 1 && !visited[r, c])
                    {
                        visited[r, c] = true;
                        q.Enqueue(new QueueNode(new Point(r, c), temp.dist+1));
                    }
                }
            }
            return -1;
        }
    }
}
