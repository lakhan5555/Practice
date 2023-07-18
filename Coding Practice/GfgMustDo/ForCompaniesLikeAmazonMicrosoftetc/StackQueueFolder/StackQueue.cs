using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.StackQueueFolder
{
    public class StackQueue
    {
        #region Question 1 - Parenthesis Checker
        // link - https://practice.geeksforgeeks.org/problems/parenthesis-checker2744/1
        public bool ispar(string s)
        {
            Stack<char> stack = new Stack<char>();
            char chr;
            foreach(char c in s)
            {
                switch (c)
                {
                    case '{':
                        {
                            stack.Push(c);
                            break;
                        }
                    case '[':
                        {
                            stack.Push(c);
                            break;
                        }
                    case '(':
                        {
                            stack.Push(c);
                            break;
                        }
                    case ')':
                        {
                            if (stack.Count == 0)
                                return false;
                            chr = stack.Pop();
                            if(chr != '(')
                                return false;
                            break;
                        }
                    case ']':
                        {
                            if (stack.Count == 0)
                                return false;
                            chr = stack.Pop();
                            if (chr != '[')
                                return false;
                            break;
                        }
                    case '}':
                        {
                            if (stack.Count == 0)
                                return false;
                            chr = stack.Pop();
                            if (chr != '{')
                                return false;
                            break;
                        }
                }
            }
            if (stack.Count > 0)
                return false;
            return true;
        }
        #endregion

        #region Question 2 - Next Greater Element
        // link - https://practice.geeksforgeeks.org/problems/next-larger-element-1587115620/1
        public long[] nextLargerElement(long[] arr, int n)
        {
            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            long next, element, indx;
            for(int i = 1; i < n; i++)
            {
                next = arr[i];
                if(stack.Count > 0)
                {
                    indx = stack.Pop();
                    element = arr[indx];
                    while(next > element)
                    {
                        arr[indx] = next;
                        if (stack.Count == 0)
                            break;
                        indx = stack.Pop();
                        element = arr[indx];
                    }
                    if (element > next)
                        stack.Push(indx);
                }
                stack.Push(i);
            }
            foreach(var i in stack)
            {
                arr[i] = -1;
            }
            return arr;
        }
        #endregion

        #region Question 3 - Queue using two Stacks
        // link - https://practice.geeksforgeeks.org/problems/queue-using-two-stacks/1
        Stack<int> st1 = new Stack<int>();
        Stack<int> st2 = new Stack<int>();

        //Complete the functions
        #region Approach 1 - making enqueue costly. 
        public void Push(int x)
        {
            st1.Clear();
            while (st2.Count > 0)
            {
                st1.Push(st2.Pop());
            }
            st2.Push(x);
            while (st1.Count > 0)
            {
                st2.Push(st1.Pop());
            }
        }
        public int Pop()
        {
            if (st2.Count > 0)
                return st2.Pop();
            return -1;
        }
        #endregion

        #region Approach 2 - making Dequeue costly. This is better approach as we are not moving all elements twice  from st2 to st1 and then from st1 to st2 as above. we are moving only when st2 is empty here
        public void Push1(int x)
        {
            st1.Push(x);
        }
        public int Pop1()
        {
            if(st1.Count == 0 && st2.Count == 0) return -1;
            if (st2.Count == 0)
            {
                while(st1.Count > 0)
                    st2.Push(st1.Pop());
            }
            return st2.Pop();
        }
        #endregion

        #endregion

        #region Question 4 - Queue using one Stack
        // sln link - https://www.geeksforgeeks.org/queue-using-stacks/
        Stack<int> st11 = new Stack<int>();
        public void Push2(int x)
        {
            st11.Push(x);
        }
        public int Pop2()
        {
            int x, res;
            if (st11.Count == 0)
                return -1;
            else if(st11.Count == 1)
                return st11.Pop();
            else
            {
                x = st11.Pop();
                res = Pop2();
                st11.Push(x);
                return res;
            }
        }
        #endregion

        #region Question 5 - Stack using two queues
        // link - https://practice.geeksforgeeks.org/problems/stack-using-two-queues/1

        Queue<int> q1 = new Queue<int>();
        Queue<int> q2 = new Queue<int>();

        //Complete the functions
        public void Push3(int x)
        {
            q2.Enqueue(x);
            while (q1.Count > 0)
                q2.Enqueue(q1.Dequeue());
            var temp = q1;
            q1 = q2;
            q2 = temp;
        }

        public int Pop3()
        {
            if (q1.Count == 0) return -1;
            return q1.Dequeue();
        }
        #endregion

        #region Question 6 - Stack using one queue
        // sln link - https://www.geeksforgeeks.org/implement-stack-using-queue/

        Queue<int> q3 = new Queue<int>();

        public void Push4(int x)
        {
            q3.Enqueue(x);
            for(int i = 0; i < q3.Count-1;i++)
                q3.Enqueue(q3.Dequeue());
        }

        public int Pop4()
        {
            if (q3.Count == 0) return -1;
            return q1.Dequeue();
        }
        #endregion

        #region Question 7 - Get minimum element from stack
        // sln link - https://www.geeksforgeeks.org/design-a-stack-that-supports-getmin-in-o1-time-and-o1-extra-space/
        int minEle;
        Stack<int> s;

        /*push element x into the stack*/
        public void push(int x)
        {
            if (s.Count == 0)
            {
                minEle = x;
                s.Push(x);
            }
            else
            {
                if(x >= minEle)
                    s.Push(x);
                else
                {
                    minEle = x;
                    s.Push(2 * x - minEle);
                }
            }
            
        }

        /*returns poped element from stack*/
        public int pop()
        {
            if(s.Count == 0) return -1;
            int t = s.Pop();
            if(t < minEle)
            {
                minEle = 2 * minEle - t;
                t = minEle;
            }
            return t;
        }

        /*returns min element from stack*/
        public int getMin()
        {
            if(s.Count == 0)  return -1;
            return minEle;
        }




        #endregion

        #region Question 8 - LRU Cache
        #region Approach 1 - Dictionary and List. For get and set, Time complexity - O(1)
        class LRUCache
        {
            int size;
            List<int> cache;
            Dictionary<int, int> dict;
            public LRUCache(int cap)
            {
                this.size = cap;
                this.cache = new List<int>();
                this.dict = new Dictionary<int, int>();
            }

            //Function to return value corresponding to the key.
            public int get(int key)
            {
                if (dict.ContainsKey(key))
                {
                    cache.Remove(key);
                    cache.Add(key);
                    return dict[key];
                }
                return -1;
            }

            //Function for storing key-value pair.
            public void set(int key, int value)
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] = value;
                    cache.Remove(key);
                    cache.Add(key);
                }
                else
                {
                    if (cache.Count == size)
                    {
                        var firstKey = cache[0];
                        cache.Remove(firstKey);
                        dict.Remove(firstKey);
                    }
                    dict.Add(key, value);
                    cache.Add(key);
                }
            }

        }
        #endregion

        #region Approach 2 - Dictionary and double linked list. For get and set, Time complexity - O(1)
        class LRU
        {
            public class DoubleNode
            {
                public int key;
                public int value;
                public DoubleNode pre;
                public DoubleNode next;
                public DoubleNode(int key, int value)
                {
                    this.key = key;
                    this.value = value;
                }
            }

            int size;
            DoubleNode head;
            DoubleNode tail;
            Dictionary<int, DoubleNode> dict;
            public LRU(int cap)
            {
                this.size = cap;
                this.head = new DoubleNode(0, 0);
                this.tail = new DoubleNode(0, 0);
                head.next = tail;
                tail.pre = head;
            }
            public int get(int key)
            {
                if (dict.ContainsKey(key))
                {
                    var node = dict[key];
                    RemoveNode(node);
                    moveNextToHead(node);
                    return node.value;
                }
                return -1;
            }
            public void set(int key, int value)
            {
                if (dict.ContainsKey(key))
                {
                    var node = dict[key];
                    dict[key].value = value;
                    RemoveNode(node);
                    moveNextToHead(node);
                }
                else
                {
                    DoubleNode node = new DoubleNode(key, value);
                    if (dict.Count == size)
                    {
                        PopTail();
                    }
                    moveNextToHead(node);
                    dict.Add(key, node);
                }
            }
            public void moveNextToHead(DoubleNode node)
            {
                node.pre = head;
                node.next = head.next;

                head.next.pre = node;
                head.next = node;
            }
            public void RemoveNode(DoubleNode node)
            {
                DoubleNode next = head.next;
                DoubleNode pre = head.pre;

                pre.next = next;
                next.pre = pre;
            }

            public void PopTail()
            {
                DoubleNode tailPre = tail.pre;
                DoubleNode tailPrePre = tailPre.pre;

                tailPrePre.next = tail;
                tail.pre = tailPrePre;

            }
        }
        #endregion
        #endregion

        #region Question 9 - Circular tour
        // link - https://practice.geeksforgeeks.org/problems/circular-tour-1587115620/1
        // sln link - https://www.geeksforgeeks.org/find-a-tour-that-visits-all-stations/
        public int tour(int[] p, int[] d, int n)
        {
            int capacity = 0, insufficient = 0, start = 0;
            for(int i = 0; i < n; i++)
            {
                capacity += p[i] - d[i];
                if(capacity < 0)
                {
                    start = i + 1;
                    insufficient += capacity;
                    capacity = 0;
                }
            }

            return capacity + insufficient < 0 ? -1 : start;
        }
        #endregion

        #region Question 10 - Rotten Oranges
        // link - https://practice.geeksforgeeks.org/problems/rotten-oranges2536/1
        // sln link - https://www.geeksforgeeks.org/minimum-time-required-so-that-all-oranges-become-rotten/

        #region Approach 1 - naive approach. Time - O(nm*nm), Space - O(1)
        public int orangesRotting(ref List<List<int>> grid)
        {
            int ans = 0;
            bool hasChanged = false;
            int n = grid.Count;
            int m = grid[0].Count;
            while (true)
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        if (grid[i][j] == 2)
                        {
                            if (isSafe(i + 1, j, n, m) && grid[i+1][j] == 1 )
                            {
                                hasChanged = true;
                                grid[i + 1][j] = 2;
                            }
                            if (isSafe(i - 1, j, n, m) && grid[i - 1][j] == 1)
                            {
                                hasChanged = true;
                                grid[i - 1][j] = 2;
                            }
                            if (isSafe(i, j + 1, n, m) && grid[i][j+1] == 1)
                            {
                                hasChanged = true;
                                grid[i][j+1] = 2;
                            }
                            if (isSafe(i, j - 1, n, m) && grid[i][j - 1] == 1)
                            {
                                hasChanged = true;
                                grid[i][j - 1] = 2;
                            }
                        }
                    }
                }
                if (!hasChanged)
                    break;
                ans++;
                hasChanged = false;
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 1)
                        return -1;
                }
            }
            return ans;
        }
        public bool isSafe(int i, int j, int n, int m)
        {
            return i >= 0 && i < n && j >= 0 && j < m;
        }
        #endregion

        #region Approach 2 - Using Queue. Time - O(nm). Space - O(nm)
        public int orangesRotting1(ref List<List<int>> grid)
        {
            Queue<Ele> queue = new Queue<Ele>();
            int ans = 0;
            int n = grid.Count, m = grid[0].Count;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        Ele e = new Ele(i, j);
                        queue.Enqueue(e);
                    }
                }
            }
            Ele delimeter = new Ele(-1, -1);
            queue.Enqueue(delimeter);

            while(queue.Count > 0)
            {
                bool hasChanged = false;
                while (!isDelimeter(queue.Peek()))
                {
                    var temp = queue.Dequeue();
                    int x = temp.x;
                    int y = temp.y;
                    if (isSafe(x + 1, y, n, m) && grid[x + 1][y] == 1)
                    {
                        if (!hasChanged)
                        {
                            hasChanged = true;
                            ans++;
                        }
                        grid[x + 1][y] = 2;
                        queue.Enqueue(new Ele(x + 1, y));
                    }
                    if (isSafe(x - 1, y, n, m) && grid[x - 1][y] == 1)
                    {
                        if (!hasChanged)
                        {
                            hasChanged = true;
                            ans++;
                        }
                        grid[x - 1][y] = 2;
                        queue.Enqueue(new Ele(x - 1, y));
                    }
                    if (isSafe(x, y + 1, n, m) && grid[x][y+1] == 1 )
                    {
                        if (!hasChanged)
                        {
                            hasChanged = true;
                            ans++;
                        }
                        grid[x][y+1] = 2;
                        queue.Enqueue(new Ele(x, y+1));
                    }
                    if (isSafe(x, y - 1, n, m) && grid[x][y - 1] == 1)
                    {
                        if (!hasChanged)
                        {
                            hasChanged = true;
                            ans++;
                        }
                        grid[x][y - 1] = 2;
                        queue.Enqueue(new Ele(x, y - 1));
                    }
                }
                queue.Dequeue();
                if (queue.Count > 0)
                    queue.Enqueue(new Ele(-1, -1));
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 1) return -1;
                }
            }
            return ans;

        }
        public bool isDelimeter(Ele ele)
        {
            return ele.x == -1 && ele.y == -1;
        }
        public class Ele
        {
            public int x;
            public int y;
            public Ele(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        #endregion
        #endregion

        #region Question 11 - Maximum of all subarrays of size k
        // link - https://practice.geeksforgeeks.org/problems/maximum-of-all-subarrays-of-size-k3101/1
        // sln link - https://www.geeksforgeeks.org/sliding-window-maximum-maximum-of-all-subarrays-of-size-k/
        public int[] max_of_subarrays(int[] arr, int n, int k)
        {
            int[] ans = new int[n-k+1];
            List<int> queue = new List<int>();
            int i;
            for(i = 0; i< k; i++)
            {
                while(queue.Count > 0 && arr[i] >= arr[queue[queue.Count - 1]]) queue.RemoveAt(queue.Count - 1);
                queue.Add(i);
            }
            for (; i < n; i++)
            {
                ans[i-k] = arr[queue[0]];
                while (queue.Count > 0 && queue[0] <= (i - k)) queue.RemoveAt(0);
                while(queue.Count > 0 && arr[i] >= arr[queue[queue.Count-1]]) queue.RemoveAt(queue.Count-1);
                queue.Add(i);
            }
            ans[i - k] = arr[queue[0]];
            return ans;
        }
        #endregion

    }
}
