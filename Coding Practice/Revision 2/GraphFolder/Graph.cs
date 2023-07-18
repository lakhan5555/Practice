using Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.LinkedListFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision_2.GraphFolder
{
    public class Graph
    {
        #region Adjacency Matrix
        public class AdjacencyMatrix
        {
            public int vertex;
            public int[,] matrix;
            public Dictionary<string, int> vertexDict;
            public string[] vertexList;

            public AdjacencyMatrix(int vertex)
            {
                this.vertex = vertex;
                this.matrix = new int[vertex, vertex];
                this.vertexDict = new Dictionary<string, int>();
                this.vertexList = new string[vertex];
            }

            public void set_Vertex(int vtx, string id)
            {
                if(vtx >= 0 && vtx < vertex)
                {
                    vertexList[vtx] = id;
                    vertexDict[id] = vtx;
                }
            }
            public void set_Edge(string from, string to, int cost = 0)
            {
                int fromInt = vertexDict[from];
                int toInt = vertexDict[to];

                matrix[fromInt, toInt] = cost;   
                matrix[toInt, fromInt] = cost;     // for undirected graph
            }
            public string[] get_Vertices()
            {
                return vertexList;
            }
            public List<Tuple<string,string,int>> get_edges()
            {
                int m = matrix.GetUpperBound(0);
                int n = matrix.GetUpperBound(1);
                List<Tuple<string,string,int>> ans = new List<Tuple<string,string,int>>();
                for(int i = 0; i < m; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        if (matrix[i,j] != 0)
                        {
                            Tuple<string, string, int> tuple = Tuple.Create(vertexList[i], vertexList[j], matrix[i, j]);
                            ans.Add(tuple);
                        }
                    }
                }
                return ans;
            }



        }
        #endregion

        #region Adjancency List
        public class AdjancencyList
        {
            public class GraphNode
            {
                public int val;
                public GraphNode next;
                public GraphNode(int val)
                {
                    this.val = val;
                }
            }

            public int vertex;
            public GraphNode[] array;
            public AdjancencyList(int vertex)
            {
                this.vertex = vertex;
            }

            public void set_Edge(int src, int dest)
            {
                GraphNode destNode = new GraphNode(dest);
                destNode.next = array[src];
                array[src] = destNode;

                // for undirected graph
                GraphNode srcNode = new GraphNode(src);
                srcNode.next = array[dest];
                array[dest] = srcNode;
            }

            public Dictionary<int, GraphNode> get_Edges()
            {
                Dictionary<int, GraphNode> dict = new Dictionary<int, GraphNode>();
                for(int i = 0; i < array.Length; i++)
                {
                    dict.Add(i, array[i]);
                }
                return dict;
            }
        }
        #endregion

        #region DFS
        public class DFSClass
        {
            public int vertex;
            public List<int>[] adj;
            public DFSClass(int vertex)
            {
                this.vertex = vertex;
                this.adj = new List<int>[vertex];
                for(int i = 0; i < vertex; i++)
                {
                    adj[i] = new List<int>();
                }
            }
            public void setEdge(int src, int dest)
            {
                adj[src].Add(dest);
            }
            public List<int> DFS(int startingVertex)
            {
                List<int> ans = new List<int>();
                bool[] visited = new bool[vertex];
                DFSUtil(startingVertex, visited, ans);
                return ans;
            }
            public void DFSUtil(int v, bool[] visited, List<int> ans)
            {
                visited[v] = true;
                ans.Add(v);
                foreach(var vertex in adj[v])
                    if (!visited[vertex])
                        DFSUtil(vertex, visited, ans);
                
            }
        }
        #endregion

        #region BFS
        public class BFSClass
        {
            public int vertex;
            public List<int>[] adj;
            public BFSClass(int vertex)
            {
                this.vertex = vertex;
                this.adj = new List<int>[vertex];
                for(int i = 0; i < vertex; i++)
                {
                    adj[i] = new List<int>();
                }
            }
            public List<int> BFS(int startingVertex)
            {
                List<int> ans = new List<int>();
                Queue<int> queue = new Queue<int>();
                bool[] visited = new bool[vertex];
                queue.Enqueue(startingVertex);
                visited[startingVertex] = true;
                while(queue.Count > 0)
                {
                    int temp = queue.Dequeue();
                    ans.Add(temp);
                    foreach (var vertex in adj[temp])
                    {
                        if (!visited[vertex])
                        {
                            visited[vertex] = true;
                            queue.Enqueue(temp);
                        }
                    }
                }
                return ans;
            }
        }
        #endregion

        #region Cycle in Undirected Graph using DFS
        public class CycleInUndirectedGraphUsingDFSClass
        {
            public int vertex;
            public List<int>[] adj;
            public CycleInUndirectedGraphUsingDFSClass(int vertex)
            {
                this.vertex = vertex;
                this.adj= new List<int>[vertex];
                for(int i = 0; i < vertex; i++)
                {
                    this.adj[i] = new List<int>();
                }
            }
            public void setEdge(int src, int dest)
            {
                adj[src].Add(dest);
                adj[dest].Add(src);
            }
            public bool CycleInUndirectedGraphUsingDFS()
            {
                bool[] visited = new bool[vertex];
                for(int i = 0; i < this.vertex;i++)
                {
                    if (!visited[i])
                        if(CycleInUndirectedGraphUsingDFSUtil(i,visited,-1))
                            return true;
                }
                return false;
            }
            public bool CycleInUndirectedGraphUsingDFSUtil(int v, bool[] visited, int parent)
            {
                visited[v] = true;
                foreach(var i in adj[v])
                {
                    if (!visited[i])
                        if (CycleInUndirectedGraphUsingDFSUtil(i, visited, v))
                            return true;
                    else if (i != parent)
                        return true;
                }
                return false;
            }
        }
        #endregion

        #region Cycle in Undirected Graph using BFS
        public class CycleInUndirectedGraphUsingBFSClass
        {
            public int vertex;
            public List<int>[] adj;
            public CycleInUndirectedGraphUsingBFSClass(int vertex)
            {
                this.vertex = vertex;
                this.adj = new List<int>[vertex];
                for(int i = 0; i < vertex; i++)
                {
                    this.adj[i] = new List<int>();
                }
            }
            public void setEdge(int src, int dest)
            {
                adj[src].Add(dest);
                adj[dest].Add(src);
            }
            public bool CycleInUndirectedGraphUsingBFS()
            {
                bool[] visited = new bool[vertex];
                for(int i = 0; i < vertex; i++)
                {
                    if (!visited[i])
                        if (CycleInUndirectedGraphUsingBFS(i, visited))
                            return true;
                }
                return false;
            }
            public bool CycleInUndirectedGraphUsingBFS(int v, bool[] visited)
            {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(v);
                visited[v] = true;
                int[] parent = new int[vertex];
                for (int i = 0; i < vertex; i++)
                    parent[i] = -1;

                while(queue.Count > 0)
                {
                    int curr = queue.Dequeue();
                    foreach(var item in adj[curr])
                    {
                        if (!visited[item])
                        {
                            visited[item] = true;
                            queue.Enqueue(item);
                            parent[item] = curr;
                        }
                        else if (item != parent[curr])
                            return true;
                    }
                }
                return false;
            }
        }
        #endregion

        #region Cycle in Directed Graph
        public class CycleInDirectedGraphClass
        {
            public int vertex;
            public List<int>[] adj;
            public CycleInDirectedGraphClass(int vertex)
            {
                this.vertex = vertex;
                this.adj = new List<int>[vertex];
                for(int i = 0;i<vertex; i++)
                    adj[i] = new List<int>();
            }
            public void setEdge(int src, int dest)
            {
                adj[src].Add(dest);
            }
            public bool CycleInDirectedGraph()
            {
                bool[] visited = new bool[vertex];
                bool[] recurStack = new bool[vertex];
                for(int i = 0; i < vertex; i++)
                {
                    if (!visited[i])
                        if(CycleInDirectedGraphUtil(i, visited, recurStack))
                            return true;
                }
                return false;
            }
            public bool CycleInDirectedGraphUtil(int v, bool[] visited, bool[] recurStack)
            {
                visited[v] = true;
                recurStack[v] = true;
                foreach(var item in adj[v])
                {
                    if (!visited[item])
                        if(CycleInDirectedGraphUtil(item,visited,recurStack))
                            return true;
                    else if (recurStack[item])
                        return true;
                }
                return false;
            }
        }
        #endregion

        #region Cycle in Directed Graph Using Colors
        public class CycleInDirectedGraphUsingColorsClass
        {
            public int vertex;
            public List<int>[] adj;
            public CycleInDirectedGraphUsingColorsClass(int vertex)
            {
                this.vertex = vertex;
                this.adj = new List<int>[vertex];
                for(int i = 0; i < vertex; i++)
                    adj[i] = new List<int>();
            }
            public void setEdge(int src, int dest)
            {
                adj[src].Add(dest);
            }
            public bool CycleInDirectedGraphUsingColors()
            {
                string[] colors = new string[vertex];
                for(int i = 0; i < vertex; i++)
                {
                    colors[i] = "WHITE";
                }
                for(int i = 0; i < vertex; i++)
                {
                    if (colors[i] == "WHITE")
                        if(CycleInDirectedGraphUsingColorsUtil(i, colors))
                            return true;
                }
                return false;
            }
            public bool CycleInDirectedGraphUsingColorsUtil(int v, string[] colors)
            {
                colors[v] = "GREY";
                foreach(int item in adj[v])
                {
                    if (colors[item] == "GREY")
                        return true;
                    if (colors[item] == "WHITE" && CycleInDirectedGraphUsingColorsUtil(item, colors))
                        return true;
                }
                colors[v] = "BLACK";
                return false;
            }
        }
        #endregion

        #region Clone Graph
        public class CloneGraphClass
        {
            public class GraphNode
            {
                public int val;
                public List<GraphNode> neighbours;
                public GraphNode(int val)
                {
                    this.val = val;
                    neighbours = new List<GraphNode>();
                }
            }
            public GraphNode CloneGraph(GraphNode node)
            {
                Queue<GraphNode> queue = new Queue<GraphNode>();
                queue.Enqueue(node);

                Dictionary<GraphNode, GraphNode> dict = new Dictionary<GraphNode, GraphNode>();
                GraphNode newHead = new GraphNode(node.val);
                dict.Add(node, newHead);
                while(queue.Count > 0)
                {
                    GraphNode curr = queue.Dequeue();
                    foreach(var item in curr.neighbours)
                    {
                        if (!dict.ContainsKey(item))
                        {
                            GraphNode newNode = new GraphNode(item.val);
                            dict.Add(item, newNode);
                            dict[curr].neighbours.Add(newNode);
                            queue.Enqueue(item);
                        }
                        else
                        {
                            dict[curr].neighbours.Add(dict[item]);
                        }
                    }
                }
                return newHead;
            }
        }
        #endregion

        #region Clone Directed Acyclic Graph
        public class CloneDirectedAcyclicGraphClass
        {
            public int vertex;

            public class GraphNode
            {
                public int val;
                public List<GraphNode> neighbours;
                public GraphNode(int val)
                {
                    this.val = val;
                    neighbours = new List<GraphNode>();
                }
            }
            public GraphNode CloneDirectedAcyclicGraph(GraphNode node)
            {
                bool[] visited = new bool[vertex];
                GraphNode newNode = new GraphNode(node.val);
                return CloneDirectedAcyclicGraphUtil(node, newNode, visited);
            }
            public GraphNode CloneDirectedAcyclicGraphUtil(GraphNode oldNode, GraphNode newNode, bool[] visited)
            {
                GraphNode clone = null;
                if (!visited[oldNode.val] && oldNode.neighbours.Count > 0)
                {
                    foreach(var node in oldNode.neighbours)
                    {
                        if (clone == null || clone != null && clone.val != node.val)
                            clone = new GraphNode(node.val);
                        newNode.neighbours.Add(clone);
                        CloneDirectedAcyclicGraphUtil(node, clone, visited);
                        visited[node.val] = true;
                    }
                }
                return newNode;
            }
        }
        #endregion


    }
}
