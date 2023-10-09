using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class PriorityQueue
    {
        // link - https://www.geeksforgeeks.org/priority-queue-set-1-introduction/


        #region PriorityQueue using Array

        public int size = 0;
        public Item[] pq = new Item[1000];
        public class Item
        {
            public int value;
            public int priority;
        }

        #region Enqueue - Time -O(1)
        public void Enqueue(int val, int priority)
        {
            size++;
            pq[size - 1] = new Item();
            pq[size - 1].value = val;
            pq[size - 1].priority = priority;
        }
        #endregion

        #region Peek - Time - O(n)
        // Function to check the top element with highest priority
        public int Peek()
        {
            int highestPriority = int.MinValue;
            int ind = -1;
            for(int i = 0; i < size; i++)
            {
                if(highestPriority == pq[i].priority && ind > -1 && pq[ind].value < pq[i].value || highestPriority < pq[i].priority) 
                {
                    highestPriority = pq[i].priority;
                    ind = i;
                }
            }
            return ind;
        }
        #endregion

        #region Dequeue - Time - O(n)
        public void Dequeue()
        {
            int ind = Peek();

            for (int i = ind; i < size-1; i++)
                pq[i] = pq[i + 1];

            size--;
        }
        #endregion

        #endregion

        #region PriorityQueue using LinkedList
        public class Node
        {
            public int value;
            public int priority;
            public Node next;
        }

        #region Push - Time - O(n)
        public Node Push(Node head, int val, int priority)
        {
            Node temp = NewNode(val,priority);

            if(head == null)
            {
                head = temp;
                return head;
            }

            Node start = head;
            if(head.priority < priority)
            {
                temp.next = head;
                head = temp;
            }
            else
            {
                while (start.next != null && start.next.priority > priority)
                    start = start.next;

                temp.next = start.next;
                start.next = temp;
            }
            return head;
        }

        public Node NewNode(int val, int priority)
        {
            Node temp = new Node();
            temp.value = val; temp.priority = priority;temp.next = null;
            return temp;
        }
        #endregion

        #region Peek - Time - O(1)
        public int Peek(Node head)
        {
            return head.value;
        }
        #endregion

        #region Pop - O(1)
        public Node Pop(Node head)
        {
            head = head.next;
            return head;
        }
        #endregion 

        #endregion
    }
}
