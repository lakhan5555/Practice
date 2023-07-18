using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode
{
    public class Stack
    {
        #region Question1 - Valid Parentheses
        //link - https://leetcode.com/problems/valid-parentheses/
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach(char c in s)
            {
                if(c == '(')
                {
                    stack.Push(')');
                    continue;
                }
                if (c == '{')
                {
                    stack.Push('}');
                    continue;
                }
                if (c == '[')
                {
                    stack.Push(']');
                    continue;
                }
                if (stack.Count == 0 || c != stack.Pop())
                    return false;
            }
            return stack.Count == 0;
        }
        #endregion

        #region Question2 - Min Stack
        //link https://leetcode.com/problems/min-stack/
        public class MinStack
        {
            public Node head;
            public MinStack()
            {
                
            }

            public void Push(int val)
            {
                if (head == null)
                    head = new Node(val, val, null);
                else
                    head = new Node(val, Math.Min(val, head.min), head);
            }

            public void Pop()
            {
                head = head.next;
            }

            public int Top()
            {
                return head.val;
            }

            public int GetMin()
            {
                return head.min;
            }
        }
        public class Node
        {
            public int val;
            public int min;
            public Node next;
            public Node(int x, int y, Node next)
            {
                this.val = x;
                this.min = y;
                this.next = next;
            }
        }
        #endregion

        #region Question3 - Evaluate Reverse Polish Notation
        //link - https://leetcode.com/problems/evaluate-reverse-polish-notation/
        public int EvalRPN(string[] tokens)
        {
            var stc = new Stack<int>();
            foreach (string s in tokens)
            {
                int top;
                int nextTop;
                if (s == "+")
                {
                    top = stc.Pop();
                    nextTop = stc.Pop();
                    stc.Push(top + nextTop);
                }
                else if (s == "-")
                {
                    top = stc.Pop();
                    nextTop = stc.Pop();
                    stc.Push(nextTop - top);
                }
                else if(s == "*")
                {
                    top = stc.Pop();
                    nextTop = stc.Pop();
                    stc.Push(top * nextTop);
                }
                else if(s == "/")
                {
                    top = stc.Pop();
                    nextTop = stc.Pop();
                    stc.Push(nextTop / top);
                }
                else
                    stc.Push(Convert.ToInt32(s));
            }
            return stc.Pop();
        }
        #endregion

        #region Question4 - Generate Parentheses
        //link - https://leetcode.com/problems/generate-parentheses/
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> ans = new List<string>();
            Backtrack(ans, "", 0, 0, n);
            return ans;
        }
        public void Backtrack(IList<string> list,string str, int low, int high, int n)
        {
            if(str.Length == 2 * n)
            {
                list.Add(str);
                return;
            }
            if (low < n)
                Backtrack(list, str + "(", low + 1, high, n);
            if (high < low)
                Backtrack(list, str + ")", low, high + 1, n);
        }
        #endregion

        #region question5 - Daily Temperatures
        //link - https://leetcode.com/problems/daily-temperatures/

        #region Approach1 - Stack
        public int[] DailyTemperatures(int[] temperatures)
        {
            Stack<int> stack = new Stack<int>();
            int[] ans = new int[temperatures.Length];
            for(int i = 0; i < temperatures.Length; i++)
            {
                while(stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
                {
                    int j = stack.Pop();
                    ans[j] = i - j;
                }
                stack.Push(i);
            }
            return ans;
        }
        #endregion

        #region Approach2 - Array
        public int[] DailyTemperatures1(int[] temperatures)
        {
            int[] ans = new int[temperatures.Length];
            int[] arr = new int[temperatures.Length];
            int top = -1;
            for (int i = 0; i < temperatures.Length; i++)
            {
                while (top > -1 && temperatures[i] > temperatures[arr[top]])
                {
                    int j = arr[top--];
                    ans[j] = i - j;
                }
                arr[++top] = i;
            }
            return ans;
        }
        #endregion

        #endregion
    }
}
