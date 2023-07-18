using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.GfgMustDo.ForProductBasedCompanies
{
    public class Searching
    {
        #region Question 1 - Search insert position of K in a sorted array - Important Question 
        // link - https://practice.geeksforgeeks.org/problems/search-insert-position-of-k-in-a-sorted-array/1
        public int searchInsertK(int[] arr, int k)
        {
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid] == k)
                    return mid;
                if (arr[mid] > k)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return l;
        }
        #endregion

        #region Question 2 - Binary Search in forest - Important Question 
        // link - https://practice.geeksforgeeks.org/problems/ffd66b6a0bf7cefb9987fa455974b6ea5695709e/1
        // sln link - https://medium.com/javarevisited/binary-search-in-forest-for-wood-collection-coding-interview-searching-b9273b72306c
        
        public int find_height(int[] arr, int k)
        {
            int low = 1;
            int high = arr.Max();
            while(low <= high)
            {
                int mid = low + (high - low) / 2;
                int count = 0;
                for(int i = 0; i < arr.Length; i++)
                    if(arr[i] > mid)
                        count += arr[i] - mid;
                if (count == k)
                    return mid;
                if (count > k)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1;
        }
        #endregion

        #region Question 3 - Left most and right most index - Important Question
        // link - https://practice.geeksforgeeks.org/problems/find-first-and-last-occurrence-of-x0849/1
        // sln link - https://www.geeksforgeeks.org/find-first-and-last-positions-of-an-element-in-a-sorted-array/

        public int[] indexes(int[] arr, int k)
        {
            int[] ans = new int[2];
            ans[0] = first(arr, k);
            ans[1] = last(arr, k);
            return ans;
        }
        public int first(int[] arr, int k)
        {
            int l = 0, r = arr.Length - 1;
            while(l <= r)
            {
                int mid = l + (r - l) / 2;
                if ((mid == 0 || arr[mid - 1] < k) && arr[mid] == k)
                    return mid;
                if (arr[mid] >= k)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return -1;
        }
        public int last(int[] arr, int k)
        {
            int l = 0, r = arr.Length - 1, n = arr.Length;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if ((mid == n-1 || arr[mid + 1] > k) && arr[mid] == k)
                    return mid;
                if (arr[mid] > k)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return -1;
        }
        #endregion

        #region Question 4 - Bitonic Point - Important Question
        // link - https://practice.geeksforgeeks.org/problems/maximum-value-in-a-bitonic-array3001/1

        public int findMaximum(int[] arr)
        {
            int l = 0, r = arr.Length - 1;
            while(l <= r)
            {
                int mid = l + (r - l) / 2;
                if (mid > 0 && arr[mid] >= arr[mid - 1])
                {
                    if (mid == arr.Length - 1)
                        return arr[mid];
                    else if (mid < arr.Length - 1 && arr[mid] > arr[mid + 1])
                        return arr[mid];
                }
                if (mid > 0 &&  arr[mid] >= arr[mid - 1] && mid < arr.Length - 1 && arr[mid] <= arr[mid + 1])
                    l = mid + 1;
                if (mid > 0 &&  arr[mid] < arr[mid - 1])
                    r = mid - 1;
            }
            return arr[l];
        }
        #endregion

        #region Question 5 - Search an element in sorted and rotated array - Important Question
        // link - https://practice.geeksforgeeks.org/problems/search-in-a-rotated-array0959/1
        // sln link - https://www.geeksforgeeks.org/search-an-element-in-a-sorted-and-pivoted-array/

        #region Approach 1 - using Pivot i.e find maximum value in array
        public int Search(int[] arr, int k)
        {
            int pivot = findPivot(arr);
            int ans = -1;
            if(pivot != -1)
            {
                if (arr[pivot] == k)
                    return pivot;
                else if (arr[pivot] < k)
                    ans = BinarySearch(arr, k, pivot + 1, arr.Length - 1);
                else
                    ans = BinarySearch(arr, k, 0, pivot - 1);
            }
            return ans;
        }
        public int findPivot(int[] arr)
        {
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (mid > 0 && arr[mid] >= arr[mid - 1])
                {
                    if (mid == arr.Length - 1)
                        return mid;
                    else if (mid < arr.Length - 1 && arr[mid] > arr[mid + 1])
                        return arr[mid];
                }
                if (mid > 0 && arr[mid] >= arr[mid - 1] && mid < arr.Length - 1 && arr[mid] <= arr[mid + 1])
                    l = mid + 1;
                if (mid > 0 && arr[mid] < arr[mid - 1])
                    r = mid - 1;
            }
            return -1;
        }
        public int BinarySearch(int[] arr, int k, int l, int r)
        {
            while(l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid] == k)
                    return mid;
                else if (arr[mid] > k)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return -1;
        }
        #endregion

        #region Approach 2 - using single Binary search - better approach
        public int Search1(int[] arr, int k)
        {
            int l = 0, r = arr.Length - 1;
            return BinarySearch1(arr, k, l, r);
            
        }
        public int BinarySearch1(int[] arr, int k, int l, int r)
        {
            int mid = l + (r - l) / 2;
            if (arr[mid] == k)
                return mid;
            else if (arr[mid] >= arr[l])
            {
                if (arr[l] <= k && arr[mid] >= k)
                    return BinarySearch(arr, k, l, mid - 1);
                return BinarySearch(arr, k, mid + 1, r);
            }
            else
            {
                if (arr[r] >= k && arr[mid] <= k)
                    return BinarySearch(arr, k, mid + 1, r);
                return BinarySearch(arr, k, l, mid - 1);
            }
        }
        #endregion
        #endregion

        #region Question 6 - Square root of a number - Important Question
        // link - https://practice.geeksforgeeks.org/problems/square-root/1

        public int floorSqrt(int n)
        {
            int l = 1, r = n;
            while(l <= r)
            {
                int mid = l + (r - l) / 2;
                int sq = mid * mid;
                if (sq == n)
                    return mid;
                else if (sq > n)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return r;
        }
        #endregion
    }
}
