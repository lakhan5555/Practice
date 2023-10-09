using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class Stack
    {
        #region Valid Parentheses
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(')');
                else if (s[i] == '{')
                    stack.Push('}');
                else if (s[i] == '[')
                    stack.Push(']');
                else if (stack.Count == 0 || stack.Pop() != s[i])
                    return false;
            }
            return stack.Count == 0;
        }
        #endregion

        #region Min Stack
        public class MinStack
        {
            

            public Node head;
            public MinStack()
            {

            }
            public void Push(int val)
            {
                if(head == null)
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
            public Node(int val, int min, Node next)
            {
                this.val = val;
                this.min = min;
                this.next = next;
            }
        }

        #endregion

        #region Evaluate Reverse Polish Notation
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            int first, second;
            int ans = 0;
            foreach(var item in tokens)
            {
                if(item == "+")
                {
                    second = stack.Pop();
                    first = stack.Pop();
                    stack.Push(first + second);
                }
                else if (item == "-")
                {
                    second = stack.Pop();
                    first = stack.Pop();
                    stack.Push(first - second);
                }
                else if (item == "*")
                {
                    second = stack.Pop();
                    first = stack.Pop();
                    stack.Push(first * second);
                }
                else if (item == "/")
                {
                    second = stack.Pop();
                    first = stack.Pop();
                    stack.Push(first / second);
                }
                else
                {
                    stack.Push(Convert.ToInt32(item));
                }
            }
            return stack.Pop();
        }
        #endregion
    }
}
