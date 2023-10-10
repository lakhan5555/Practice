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

            int[] stones = { 3,7,8 };
            int ans = LastStoneWeight(stones);
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
    }
}
