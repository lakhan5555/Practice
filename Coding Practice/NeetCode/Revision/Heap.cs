using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class Heap
    {
        public int heapSize;
        public void Main()
        {
            heapSize = 0;
            int[] arr = new int[100];
            insertKey(arr, 3);
            insertKey(arr, 10);
            insertKey(arr, 12);
            insertKey(arr, 8);
            insertKey(arr, 2);
            insertKey(arr, 14);
        }

        #region Max Heap
        // link - https://www.geeksforgeeks.org/introduction-to-heap-data-structure-and-algorithm-tutorials/?ref=ghm

        #region Insert
        public void insertKey(int[] arr, int x)
        {
            heapSize++;
            int i = heapSize-1;
            arr[i] = x;

            // restore max heap property
            while (i != 0 && arr[i] > arr[Parent(i)])
            {
                int parent = Parent(i);
                int temp = arr[i];
                arr[i] = arr[parent];
                arr[parent] = temp;

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
        #endregion

        #region Get Max
        public int getMax(int[] arr)
        {
            if (heapSize > 0)
                return arr[0];
            return -1;
        }
        #endregion

        #region Delete Key
        // Deletes a key at given index i
        public void deleteKey(int[] arr, int i)
        {
            increaseKey(arr, i, int.MaxValue);
            removeMax(arr);
        }
        public void increaseKey(int[] arr, int i, int newVal)
        {
            arr[i] = newVal;
            while(i != 0 && arr[i] > arr[Parent(i)])
            {
                int parent = Parent(i);
                int temp = arr[i];
                arr[i] = arr[parent];
                arr[parent] = temp;

                i = parent;
            }
        }


        // Removes the root which in this case contains the maximum element. 
        public int removeMax(int[] arr)
        {
            if(heapSize <= 0) return -1;
            if(heapSize == 1)
            {
                heapSize--;
                return arr[0];
            }

            int root = arr[0];
            arr[0] = arr[heapSize - 1];
            heapSize--;

            maxHeapify(arr, 0);

            return root;
        }

        public void maxHeapify(int[] arr, int i)
        {
            int l = LeftChild(i);
            int r = RightChild(i);
            int largest = i;

            if (l < heapSize && arr[l] > arr[largest])
                largest = l;
            if (r < heapSize && arr[r] > arr[largest])
                largest = r;

            if(largest != i)
            {
                int temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;

                maxHeapify(arr, largest);
            }
        }
        #endregion

        #endregion
    }
}
