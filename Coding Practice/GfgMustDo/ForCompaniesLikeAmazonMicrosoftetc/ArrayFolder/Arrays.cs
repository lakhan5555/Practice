using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.ArrayFolder
{
    public class Arrays
    {
        #region Question 1 - Subarray with Given Sum  - Important Question
        // link - https://practice.geeksforgeeks.org/problems/subarray-with-given-sum-1587115621/1
        // sln link - https://www.geeksforgeeks.org/find-subarray-with-given-sum/

        public List<int> subarraySum(int[] arr, int n, int s)
        {
            int currentSum = arr[0], start = 0;
            List<int> ans = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                while (currentSum > s && start < i - 1)
                {
                    currentSum -= arr[start];
                    start++;
                }
                if (currentSum == s)
                {
                    ans.Add(start + 1);
                    ans.Add(i);
                    break;
                }
                if (i < n)
                    currentSum += arr[i];
            }
            if (ans.Count == 0)
                ans.Add(-1);
            return ans;
        }
        #endregion

        #region Question 2 - Count the triplets - Important
        // link - https://practice.geeksforgeeks.org/problems/count-the-triplets4615/1

        #region Approach 1 - O(n*3)
        public int countTriplet(int[] arr, int n)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr.Contains(arr[i] + arr[j]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        // I think time complexity for above is O(n*3) as arr.Contains will take n time
        #endregion

        #region Approach 2 - Time Com - O(n*2), space com - O(n)
        public int countTriplet1(int[] arr, int n)
        {
            var set = arr.ToHashSet();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (set.Contains(arr[i] + arr[j]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        #endregion

        #region Approach 3 - Time Com - O(n*2), Space Com - O(1)
        public int countTriplet2(int[] arr, int n)
        {
            Array.Sort(arr);
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                int l = 0;
                int h = i - 1;
                while (l < h)
                {
                    if (arr[l] + arr[h] == arr[i])
                        count++;
                    else if (arr[i] > arr[l] + arr[h])
                        l++;
                    else
                        h--;
                }
            }
            return count;
        }
        #endregion
        #endregion

        #region Question 3 - Kadane's Algorithm - Important Question
        //link - https://practice.geeksforgeeks.org/problems/kadanes-algorithm-1587115620/1
        // sln link - https://www.geeksforgeeks.org/largest-sum-contiguous-subarray/

        public long maxSubarraySum(int[] arr, int n)
        {
            int max_so_far = int.MinValue, max_ending_here = 0;
            foreach (int item in arr)
            {
                max_ending_here += item;
                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;
                if (max_ending_here < 0)
                    max_ending_here = 0;
            }
            return max_so_far;
        }
        #endregion

        #region Question 4 - Missing number in array
        //link - https://practice.geeksforgeeks.org/problems/missing-number-in-array1416/1

        #region Approach 1 - issue - Integaer overflow in sumOfSerries and sumOfArray
        public int MissingNumber(int[] arr, int n)
        {
            int sumOfSerries = n * (n + 1) / 2;
            int sumOfArray = arr.Sum();
            return sumOfSerries - sumOfArray;
        }
        #endregion

        #region Approach 2 - 
        public int MissingNumber1(int[] arr, int n)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != n)
                    arr[Math.Abs(arr[i] - 1)] *= -1;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                    return i + 1;
            }
            return n;
        }
        #endregion
        #endregion

        #region Question 5 - Merge Without Extra Space - Important Question
        // link - https://practice.geeksforgeeks.org/problems/merge-two-sorted-arrays-1587115620/1
        // sln link - https://www.geeksforgeeks.org/merge-two-sorted-arrays-o1-extra-space/

        #region Approach 1 - Time Complexity - O(n*m)
        public void merge(int[] arr1, int[] arr2, int m, int n)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                int last = arr1[m - 1], j;
                for (j = m - 2; j >= 0 && arr1[j] > arr2[i]; j--)
                {
                    arr1[j + 1] = arr1[j];
                }
                if (last > arr2[i])
                {
                    arr1[j + 1] = arr2[i];
                    arr2[i] = last;
                }
            }
        }
        #endregion

        #region Approach 2 - Time Complexity - O((n+m)log(n+m))

        public void merge1(int[] arr1, int[] arr2, int m, int n)
        {
            int i, j, k = m - 1;
            for (i = 0, j = 0; i <= k && j < n;)
            {
                if (arr1[i] < arr2[j])
                    i++;
                else
                {
                    var temp = arr2[j];
                    arr2[j] = arr1[k];
                    arr1[k] = temp;
                    j++; k--;
                }
            }
            Array.Sort(arr1);
            Array.Sort(arr2);
        }
        #endregion
        #endregion

        #region Question 6 - Rearrange Array Alternately - Important Question
        // link - https://practice.geeksforgeeks.org/problems/-rearrange-array-alternately-1587115620/1

        #region Approach 1 - With extra space complexity. Time complexity - O(n). Space complexity - O(n)
        // sln link - https://www.geeksforgeeks.org/rearrange-array-maximum-minimum-form/
        public void rearrange(int[] arr, int n)
        {
            int[] tempArray = new int[n];
            bool flag = true;  // if flag = true, then take maximum element, else take minimum element

            int min_index = 0, max_index = n - 1;
            for (int i = 0; i < n; i++)
            {
                if (flag)
                    tempArray[i] = arr[max_index--];
                else
                    tempArray[i] = arr[min_index++];
                flag = !flag;
            }
        }
        #endregion

        #region Approach 2 - Without extra space complexity. Time complexity - O(n). Space complexity - O(1)
        // sln link - https://www.geeksforgeeks.org/rearrange-array-maximum-minimum-form-set-2-o1-extra-space/
        public void rearrange1(int[] arr, int n)
        {
            int max_index = n - 1;
            int min_index = 0;
            int max_element = arr[n - 1] + 1;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    arr[i] += arr[max_index] % max_element * max_element;
                    max_index--;
                }
                else
                {
                    arr[i] += arr[min_index] % max_element * max_element;
                    min_index++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                arr[i] /= max_element;
            }
        }
        #endregion
        #endregion

        #region Question 7 - Number of pairs - Important Question
        // link - https://practice.geeksforgeeks.org/problems/number-of-pairs-1587115620/1
        // sln  link - https://www.geeksforgeeks.org/find-number-pairs-xy-yx/
        #endregion

        #region Question 8  - Sort an array of 0s, 1s and 2s
        // link - https://practice.geeksforgeeks.org/problems/sort-an-array-of-0s-1s-and-2s4231/1
        #region Approach 1 - Time - O(n), Space - O(1)
        public void sort012(int[] arr, int n)
        {
            int CountOfOs = 0, CountOf1s = 0, CountOf2s = 0;
            foreach (var item in arr)
            {
                switch (item)
                {
                    case 0:
                        CountOfOs++;
                        break;
                    case 1:
                        CountOf1s++;
                        break;
                    case 2:
                        CountOf2s++;
                        break;
                }
            }
            int i = 0;
            while (CountOfOs > 0)
            {
                arr[i] = 0;
                i++;
                CountOfOs--;
            }
            while (CountOf1s > 0)
            {
                arr[i] = 1;
                i++;
                CountOf1s--;
            }
            while (CountOf2s > 0)
            {
                arr[i] = 2;
                i++;
                CountOf2s--;
            }
        }
        #endregion

        #region Approach 2 - Duction National Flag approach - Time - O(n), Space - O(1)
        // sln link - https://www.geeksforgeeks.org/sort-an-array-of-0s-1s-and-2s/
        public void Sort012(int[] arr, int n)
        {
            int low = 0, mid = 0, high = n - 1;
            while (mid <= high)
            {
                switch (arr[mid])
                {
                    case 0:
                        {
                            int temp = arr[low];
                            arr[low] = arr[mid];
                            arr[mid] = temp;
                            low++;
                            mid++;
                            break;
                        }
                    case 1:
                        {
                            mid++;
                            break;
                        }
                    case 2:
                        {
                            int temp = arr[high];
                            arr[high] = arr[mid];
                            arr[mid] = temp;
                            high--;
                            break;
                        }
                }
            }
        }
        #endregion
        #endregion

        #region Question 9 - Equilibrium Point
        // link - https://practice.geeksforgeeks.org/problems/equilibrium-point-1587115620/1
        public int equilibriumPoint(long[] arr, int n)
        {
            long leftSum = 0;
            long rightSum = arr.Sum(); ;

            for (int i = 0; i < n; i++)
            {
                rightSum -= arr[i];
                if (leftSum == rightSum)
                    return i + 1;
                leftSum += arr[i];
            }
            return -1;
        }
        #endregion

        #region Question 10 - Leaders in an array
        // link - https://practice.geeksforgeeks.org/problems/leaders-in-an-array-1587115620/1

        public List<int> leaders(int[] arr, int N)
        {
            List<int> ans = new List<int>();
            int rightSum = arr.Sum();
            foreach (var item in arr)
            {
                rightSum -= item;
                if (item >= rightSum)
                    ans.Add(item);
            }
            return ans;
        }
        #endregion

        #region Question 11 - Reverse array in groups
        // link - https://practice.geeksforgeeks.org/problems/reverse-array-in-groups0255/1

        public void reverseInGroups(int[] A, int N, int K)
        {
            int max = A.Max() + 1;
            int start = 0, index, i;
            for (i = 0; i < N; i++)
            {
                if (i % K == 0)
                    start = i;
                if (N - start < K)
                    break;
                index = start + K - (i - start) - 1;
                A[index] += A[i] % max * max;
            }
            K = N - i;
            start = i;
            while (i < N)
            {
                index = start + K - (i - start) - 1;
                A[index] += A[i] % max * max;
                i++;
            }
            for (i = 0; i < N; i++)
            {
                A[i] = A[i] / max;
            }
        }
        #endregion
    }
}
