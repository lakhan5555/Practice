using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class Sorting
    {
        public void Main()
        {
            int[] arr = { 10,80,30,90,40 };
            //SelectionSort(arr);
            QuickSort1(arr);
        }

        #region Selection Sort

        // Complexity- Time - (n*2), Space - O(1)
        // The selection sort never makes more than O(N) swaps and can be useful
        // when memory writing is costly
        public void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0;i< n-1; i++)
            {
                int min_index = i;
                for(int j = i + 1; j < n; j++)
                {
                    if (arr[min_index] > arr[j])
                        min_index = j;
                }
                int temp = arr[min_index];
                arr[min_index] = arr[i];
                arr[i] = temp;
            }
        }

        // The default implementation of the Selection Sort Algorithm is not stable.

        // A sorting algorithm is said to be stable if two objects with equal or same keys
        // appear in the same order in sorted output as they appear in the input array to be sorted

        public void StableSelectionSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0;i<n-1;i++)
            {
                int min_index = i;
                for(int j = i + 1; j < n; j++)
                {
                    if (arr[min_index] > arr[j])
                        min_index = j;
                }

                int key = arr[min_index];
                while(min_index > i)
                {
                    arr[min_index] = arr[min_index - 1];
                    min_index--;
                }
                arr[i] = key;
            }
        }
        #endregion

        #region Bubble Sort

        // Bubble Sort is the simplest sorting algorithm that works by repeatedly swapping
        // the adjacent elements if they are in the wrong order

        // Total no. of passes: n-1
        //Total no.of comparisons: n*(n-1)/2

        // Complexity - Time - O(n*2), Space - O(1)
        public void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for(int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swapped = true;
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                if (swapped == false)
                    break;
            }
        }

        // It is a stable sorting algorithm, meaning that elements with the same key value
        // maintain their relative order in the sorted output.


        #endregion

        #region Insertion Sort

        // The array is virtually split into a sorted and an unsorted part. Values from the
        // unsorted part are picked and placed at the correct position in the sorted part

        // Complexity - Time - O(n*2), Space - O(1)
        public void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while(j >= 0 && arr[j] > key) 
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
        #endregion

        #region Merge Sort
        // Complexity - Time - All case- O(nlogn), Space - O(n)
        public void MergeSort(int[] arr)
        {
            MergeSortRecur(arr, 0, arr.Length - 1);
        }
        public void MergeSortRecur(int[] arr, int l, int r)
        {
            if(l < r)
            {
                int mid = l + (r - l) / 2;
                MergeSortRecur(arr, l, mid);
                MergeSortRecur(arr, mid + 1, r);

                Merge(arr, l, mid, r);
            }
        }

        public void Merge(int[] arr, int l, int mid, int r)
        {
            int n1 = mid - l + 1;
            int n2 = r - mid;
            int i, j;

            int[] temp1 = new int[n1];
            int[] temp2 = new int[n2];

            for (i = 0; i < n1; i++)
                temp1[i] = arr[l + i];
            for(i = 0;i<n2;i++)
                temp2[i] = arr[mid + i + 1];

            i = 0;j = 0;
            int k = l;
            while(i < n1 && j < n2)
            {
                if (temp1[i] <= temp2[j])
                {
                    arr[l+k] = temp1[i];
                    i++;
                }
                else
                {
                    arr[l + k] = temp2[j];
                    j++;
                }
                k++;
            }
            while(i < n1)
            {
                arr[l + k] = temp1[i];
                i++;k++;
            }
            while(j < n2)
            {
                arr[l+k] = temp2[j];
                j++;k++;
            }
        }
        #endregion

        #region Quick Sort

        // Complexity - Time - Best, Average - O(nlogn), Worst - O(n*2), Space - O(1)

        #region Choosing last element as pivot
        // link - https://www.geeksforgeeks.org/quick-sort/?ref=ghm
        public void QuickSort(int[] arr)
        {
            QuickSortRecur(arr, 0, arr.Length - 1);
        }
        public void QuickSortRecur(int[] arr, int l, int r)
        {
            if(l < r)
            {
                int pi = Partition(arr, l, r);

                QuickSortRecur(arr, l, pi - 1);
                QuickSortRecur(arr, pi + 1, r);
            }
        }
        public int Partition(int[] arr, int l, int r)
        {
            int pivot = arr[r];
            int i = l - 1;
            for(int j = l;j<= r - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    swap(arr, i, j);
                }
            }
            swap(arr, i + 1, r);
            return i + 1;
        }
        public void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        #endregion

        #region Choosing first element as pivot
        // link - https://www.geeksforgeeks.org/implement-quicksort-with-first-element-as-pivot/
        public void QuickSort1(int[] arr)
        {
            QuickSortRecur1(arr, 0, arr.Length - 1);
        }
        public void QuickSortRecur1(int[] arr, int l, int r)
        {
            if(l < r)
            {
                int pi = Partition1(arr, l, r);

                QuickSortRecur1(arr, l, pi - 1);
                QuickSortRecur1(arr, pi + 1, r);
            }
        }
        public int Partition1(int[] arr, int l, int r)
        {
            int pivot = arr[l];
            int i = r;
            for(int j = r; j > l; j--)
            {
                if (arr[j] > pivot)
                {
                    swap(arr, j, i--);
                }
            }
            swap(arr, l, i);
            return i;
        }
        #endregion

        #region Choosing  middle element as pivot

        // ans from chat gpt
        public void QuickSort2(int[] arr)
        {
            QuickSortRecur2(arr, 0, arr.Length - 1);
        }
        public void QuickSortRecur2(int[] arr, int l, int r)
        {
            if(l < r)
            {
                int pi = Partition2(arr, l, r);

                QuickSortRecur2(arr, l, pi - 1);
                QuickSortRecur2(arr, pi + 1, r);
            }
        }
        public int Partition2(int[] arr, int l,int r)
        {
            int mid = (l + r) / 2;
            int pivot = arr[mid];
            int left = l, right = r;
            while (true)
            {
                while (arr[left] < pivot)
                    left++;
                while (arr[right] > pivot)
                    right++;

                if (left >= right)
                    return right;

                swap(arr, left, right);
                left++;
                right--;
            }
        }
        #endregion

        #region Choosing Random number as pivot
        // link - https://www.geeksforgeeks.org/quicksort-using-random-pivoting/
        public void QuickSort3(int[] arr)
        {
            QuickSortRecur3(arr, 0, arr.Length - 1);
        }
        public void QuickSortRecur3(int[] arr, int l, int r)
        {
            if(l < r)
            {
                int pi = Partition3(arr, r, l);

                QuickSortRecur3(arr, l, pi - 1);
                QuickSortRecur3(arr, pi + 1, r);
            }
        }

        public int Partition3(int[] arr, int l, int r)
        {
            Random(arr, l, r);

            int pivot = arr[r];
            int i = l - 1;

            for(int j = 0; j <= r - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    swap(arr, i, j);
                }
            }
            swap(arr, i + 1, r);
            return i + 1;
        }
        public void Random(int[] arr, int l, int r)
        {
            Random rnd = new Random();
            int random = rnd.Next(l,r);

            swap(arr, random, r);
        }
        #endregion
        #endregion
    }
}
