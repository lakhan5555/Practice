using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class PriorityQueuee
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

        #region PriorityQueue using Heap
        // link - https://www.geeksforgeeks.org/priority-queue-using-binary-heap/

        public int heapSize = 0;
        public int[] heapArray = new int[1000];

        public int Parent(int i)
        {
            return (i - 1) / 2;
        }
        public int LeftChild(int i)
        {
            return 2 * i + 1;
        }
        public int RightChild(int i)
        {
            return 2 * i + 2;
        }

        // Function to shift up the node in order to maintain the heap property
        public void ShiftUp(int i)
        {
            while(i > 0 && heapArray[i] > heapArray[Parent(i)])
            {
                int parent = Parent(i);

                int temp = heapArray[i];
                heapArray[i] = heapArray[parent];
                heapArray[parent] = temp;

                i = parent;
            }
        }
        public void ShiftDown(int i)
        {
            int leftChild = LeftChild(i);
            int rightChild = RightChild(i);
            int larget = i;
            if(leftChild < heapSize && heapArray[leftChild] > heapArray[larget])
                larget = leftChild;
            if (rightChild < heapSize && heapArray[rightChild] > heapArray[larget])
                larget = rightChild;

            if(i != larget)
            {
                int temp = heapArray[i];
                heapArray[i] = heapArray[larget];
                heapArray[larget] = temp;

                ShiftDown(larget);
            }
        }

        #region Insert. Time - O(logn)
        public void Insert(int p)
        {
            heapSize++;
            heapArray[heapSize - 1] = p;
            ShiftUp(heapSize - 1);
        }
        #endregion

        #region ExtractMax. Time - O(logn)
        public int ExtractMax()
        {
            int root = heapArray[0];
            heapArray[0] = heapArray[heapSize - 1];
            heapSize--;

            ShiftDown(0);
            return root;
        }
        #endregion

        #region Change priority of element at index i to p, Time - O(nlogn)
        public void ChangePriority(int i, int p)
        {
            int oldP = heapArray[i];
            heapArray[i] = p;
            if (p > oldP)
                ShiftUp(i);
            else
                ShiftDown(i);

        }
        #endregion

        #region GetMax, Time - O(1)
        public int GetMax()
        {
            return heapArray[0];
        }
        #endregion

        #region Remove. Time - O(logn)
        public void Remove(int i)
        {
            heapArray[i] = GetMax() + 1;
            ShiftUp(i);
            ExtractMax();
        }
        #endregion


        #endregion
    }
}
