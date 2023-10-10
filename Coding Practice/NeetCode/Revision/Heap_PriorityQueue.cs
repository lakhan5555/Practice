using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class Heap_PriorityQueue
    {
        public void main()
        {
            //int[] nums = { 4, 5, 8, 2 };
            //int k = 3;
            //var a = new KthLargest(k, nums);
            //var b = a.Add(3);
            //b = a.Add(5);
            //b = a.Add(10);
            //b = a.Add(9);
            //b = a.Add(4);

            //int[] stones = { 3,7,8 };
            //int ans = LastStoneWeight(stones);

            //int[][] points = new int[2][];
            //points[0] = new int[2]{ 1,3};
            //points[1] = new int[2] { 2,-2};

            //var ans = KClosest(points, 1);

            int[] arr = { 3, 2, 1, 5, 6, 4 };
            var ans = FindKthLargest(arr, 2);
        }

        #region Kth Largest Element in a Stream
        public class KthLargest
        {
            int k;
            int[] pq;
            int size = 0;
            public KthLargest(int k, int[] nums)
            {
                this.k = k;
                pq = new int[this.k];
                foreach (var item in nums)
                    Insert(item);
            }

            public int Add(int val)
            {
                Insert(val);
                return GetMin();
            }
            public void Insert(int item)
            {
                if(size < k)
                {
                    size++;
                    pq[size - 1] = item;
                    ShiftUp(size - 1);
                }
                else
                {
                    int min = GetMin();
                    if(min < item)
                    {
                        pq[0] = item;
                        ShiftDown(0);
                    }
                }
            }
            public void ShiftUp(int i)
            {
                while(i > 0 && pq[i] < pq[Parent(i)])
                {
                    int parent = Parent(i);
                    int temp = pq[i];
                    pq[i] = pq[parent];
                    pq[parent] = temp;

                    i = parent;
                }
            }
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
            public int GetMin()
            {
                return pq[0];
            }
            public void ShiftDown(int i)
            {
                int leftChild = LeftChild(i);
                int rightChild = RightChild(i);
                int smallest = i;

                if(leftChild < size && pq[leftChild] < pq[smallest])
                    smallest= leftChild;
                if(rightChild < size && pq[rightChild] < pq[smallest])
                    smallest= rightChild;

                if(i != smallest)
                {
                    int temp = pq[i];
                    pq[i] = pq[smallest];
                    pq[smallest] = temp;
                    ShiftDown(smallest);
                }
            }
        }
        #endregion

        #region Last Stone Weight
        // link - https://leetcode.com/problems/last-stone-weight/
        public int LastStoneWeight(int[] stones)
        {
            int size = 0;
            int[] pq = new int[stones.Length]; 
            foreach(var item in stones)
            {
                size = Insert(item, pq, size);
            }
            LastStoneWeightUtil(pq, ref size);
            if (size == 0)
                return 0;
            else
                return pq[0];
        }
        public int Insert(int item, int[] pq, int size)
        {
            size++;
            pq[size-1] = item;
            ShiftUp(size-1,pq);
            return size;
        }
        public void ShiftUp(int i, int[] pq)
        {
            while(i  > 0 && pq[i] > pq[Parent(i)])
            {
                int parent = Parent(i);
                int temp = pq[i];
                pq[i] = pq[parent];
                pq[parent] = temp;
                i = parent;
            }
        }
        public void ShiftDown(int i, int[] pq, int size)
        {
            int leftChild = LeftChild(i);
            int rightChild = RightChild(i);
            int largest = i;
            if (leftChild < size && pq[leftChild] > pq[largest])
                largest = leftChild;
            if(rightChild < size && pq[rightChild] > pq[largest])
                largest = rightChild;

            if(i != largest)
            {
                int temp = pq[i];
                pq[i] = pq[largest];
                pq[largest] = temp;
                ShiftDown(largest, pq, size);
            }
        }
        public void ExtractMax(int[] pq, int size)
        {
            pq[0] = pq[size - 1];
            ShiftDown(0, pq, size-1);
        }
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
        public void LastStoneWeightUtil(int[] pq,ref int size)
        {
            if(size > 1)
            {
                int root = pq[0];
                int largest = 1;
                if(size > 2)
                    if(pq[largest] < pq[2])
                    {
                        largest = 2;
                    }

                int diff = root - pq[largest];
                if(diff > 0)
                {
                    ExtractMax(pq, size);
                    size--;
                    pq[0] = diff;
                    ShiftDown(0, pq, size);
                }
                else
                {
                    ExtractMax(pq, size);
                    size--;
                    ExtractMax(pq, size);
                    size--;
                }
                LastStoneWeightUtil(pq, ref size);
            }
        }
        #endregion

        #region K Closest Points to Origin
        int heapSize = 0;
        public int[][] KClosest(int[][] points, int k)
        {
            int[][] pq = new int[k][];
            foreach (var item in points)
                InsertKClosest(pq, item, k);
            return pq;
        }
        public void InsertKClosest(int[][] pq, int[] item, int k)
        {
            if(heapSize < k)
            {
                heapSize++;
                pq[heapSize-1] = item;
                ShiftUpKClosest(pq, heapSize - 1);
            }
            else
            {
                double distFromOrigin = Math.Sqrt(Math.Pow(item[0], 2) + Math.Pow(item[1], 2));
                double distFromRoot = Math.Sqrt(Math.Pow(pq[0][0], 2) + Math.Pow(pq[0][1], 2));
                
                if (distFromOrigin < distFromRoot)
                {
                    pq[0] = item;
                    ShiftDownKClosest(pq, 0);
                }
            }

        }
        public void ShiftUpKClosest(int[][] pq, int i)
        {
            
            while (i > 0 && distFromOrigin(i,pq) > distFromOrigin(ParentKClosest(i),pq))
            {
                int parent = Parent(i);
                var temp = pq[i];
                pq[i] = pq[parent];
                pq[parent] = temp;

                i = parent;
            }
        }
        public void ShiftDownKClosest(int[][] pq, int i)
        {
            int leftChild = LeftChildKClosest(i);
            int rightChild = RightChildKClosest(i);
            int largest = i;
            if (leftChild < heapSize && distFromOrigin(leftChild,pq) > distFromOrigin(largest,pq))
                largest = leftChild;
            if (rightChild < heapSize && distFromOrigin(rightChild, pq) > distFromOrigin(largest, pq))
                largest = rightChild;
            if(i != largest)
            {
                var temp = pq[i];
                pq[i] = pq[largest];
                pq[largest] = temp;
                ShiftDownKClosest(pq, largest);
            }
        }
        public double distFromOrigin(int i, int[][] pq)
        {
            return Math.Sqrt(Math.Pow(pq[i][0], 2) + Math.Pow(pq[i][1], 2));
        }
        public int ParentKClosest(int i)
        {
            return (i - 1) / 2;
        }
        public int LeftChildKClosest(int i)
        {
            return 2 * i + 1;
        }
        public int RightChildKClosest(int i)
        {
            return 2 * i + 2;
        }
        #endregion

        #region Kth Largest Element in an Array
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int,int> priorityQueue= new PriorityQueue<int,int>();
            int pqSize = 0;
            foreach(var item in nums)
            {
                pqSize++;
                priorityQueue.Enqueue(item, -1*item);
            }
            for(int i = 0; i< k-1; i++)
            {
                priorityQueue.Dequeue();
            }
            return priorityQueue.Peek();
        }
        #endregion
    }
}
