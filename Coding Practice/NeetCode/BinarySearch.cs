using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Practice
{
    public class BinarySearch
    {
        public int BinarySearchIterative(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left)/2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }

        public int BinarySearchRecursive(int[] nums, int target)
        {
            return BinarySearchRecursiveUtil(nums, target, 0, nums.Length - 1);
        }

        public int BinarySearchRecursiveUtil(int[] nums, int target, int left, int right)
        {
            if(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] > target)
                    BinarySearchRecursiveUtil(nums, target, left, mid - 1);
                return BinarySearchRecursiveUtil(nums, target, mid + 1, right);
            }
            return -1;
        }

        #region Question1
        //link - https://leetcode.com/problems/binary-search/
        public int Search(int[] nums, int target)
        {
            return fn(nums, target, 0, nums.Length - 1);
        }

        public int fn(int[] nums, int target, int left, int right)
        {
            int mid = left + (right - left) / 2;
            if (left <= right)
            {
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] > target)
                    return fn(nums, target, left, mid - 1);
                else
                    return fn(nums, target, mid + 1, right);
            }
            return -1;
        }
        #endregion


        #region  Question2
        //link - https://leetcode.com/problems/search-a-2d-matrix/
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            int l = 0;
            int r = n * m - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (matrix[mid / m][mid % m] == target)
                    return true;
                if (matrix[mid / m][mid % m] > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return false;
        }
        #endregion


        #region  Question3
        //link - https://leetcode.com/problems/koko-eating-bananas/
        public int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1, right = piles.Max();
            while (left < right)
            {
                int mid = left + ((right - left) >> 1);  // right shift by 1 means divide by 2
                if (CountHours(piles, mid) <= h)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
        public int CountHours(int[] piles, int k)
        {
            int c = 0;
            foreach (var item in piles)
            {
                c += item / k;
                if (item % k != 0)
                    c += 1;
            }
            return c;
        }
        #endregion

        #region Question4
        //link - https://leetcode.com/problems/search-in-rotated-sorted-array/
        public int Search1(int[] nums, int target)
        {
            int n = nums.Length;
            int lo = 0, hi = n - 1;
            while(lo < hi)
            {
                int mid = lo + ((hi - lo) >> 1);
                if (nums[mid] > nums[hi])
                    lo = mid + 1;
                else
                    hi = mid;
            }
            int start = lo;
            lo = 0;
            hi = n - 1;
            while (lo <= hi)
            {
                int mid = lo + ((hi - lo) >> 1);
                int realmid = (mid + start) % n;
                if (nums[realmid] == target)
                    return realmid;
                if (nums[realmid] > target)
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }
            return -1;

        }
        #endregion

        #region Question5
        //link - https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        public int FindMin(int[] nums)
        {
            int n = nums.Length;
            int lo = 0, hi = n - 1;
            while (lo < hi)
            {
                int mid = lo + ((hi - lo) >> 1);
                if (nums[mid] > nums[hi])
                    lo = mid + 1;
                else
                    hi = mid;
            }
            return nums[lo];
        }
        #endregion

        #region Todo
        //link - https://leetcode.com/problems/time-based-key-value-store/
        //    - https://leetcode.com/problems/kth-missing-positive-number/
        //    - https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/
        //    - https://leetcode.com/problems/find-the-smallest-divisor-given-a-threshold/
        //    - https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/
        //    - https://leetcode.com/problems/split-array-largest-sum/
        #endregion

    }
}
