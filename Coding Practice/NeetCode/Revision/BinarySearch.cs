using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class BinarySearch
    {
        public void Main()
        {
            int a = 2147395599;
            var b = MySqrt(a);
        }

        #region Cheat Template
        // link - https://leetcode.com/discuss/study-guide/786126/Python-Powerful-Ultimate-Binary-Search-Template.-Solved-many-problems
        #endregion

        #region First Bad Version
        // link - https://leetcode.com/problems/first-bad-version/description/
        public int FirstBadVersion(int n)
        {
            int left = 1, right = n, mid;
            while(left < right)
            {
                mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
        public bool IsBadVersion(int n)
        {
            return false;
        }
        #endregion

        #region Sqrt(x)
        // link - https://leetcode.com/problems/sqrtx/description/
        public int MySqrt(int x)
        {
            if (x <= 1) return x;
            int left = 1, right = x, mid;
            while(left < right)
            {
                mid = left + (right-left) / 2;
                if (mid > x/mid)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left - 1;
        }
        #endregion

        #region Search Insert Position
        // link - https://leetcode.com/problems/search-insert-position/description/
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length, mid;
            while(left < right)
            {
                mid = left+ (right-left) / 2;
                if (nums[mid] >= target)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
        #endregion

        #region Capacity To Ship Packages Within D Days
        // link - https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/description/
        public int ShipWithinDays(int[] weights, int days)
        {
            int left = weights.Max(), right = weights.Sum(), mid;
            while(left < right)
            {
                mid = left + (right- left) / 2;
                if(IsFeasible(weights,days,mid))
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
        public bool IsFeasible(int[] weights, int days, int cap)
        {
            int d = 1, total = 0;
            foreach(var item in weights)
            {
                total += item;
                if(total > cap)
                {
                    total = item;
                    d++;
                    if (d > days)
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region Split Array Largest Sum
        // link - https://leetcode.com/problems/split-array-largest-sum/description/
        public int SplitArray(int[] nums, int m)
        {
            int left = nums.Max(), right = nums.Sum(), mid;
            while(left < right)
            {
                mid = left + (right - left) / 2;
                if(IsFeasible(nums,m, mid))
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
        #endregion

        #region Minimum Number of Days to Make m Bouquets
        // link - https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/
        public int MinDays(int[] bloomDay, int m, int k)
        {
            if (m * k > bloomDay.Length) return -1;
            int left = 1, right = bloomDay.Max(), mid;
            while(left < right)
            {
                mid = left + (right - left) / 2;
                if(IsBouquetMade(bloomDay,m,k,mid))
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
        public bool IsBouquetMade(int[] bloomday, int m, int k, int days)
        {
            int flower = 0, bouquet = 0;
            foreach(var item in bloomday)
            {
                if (item > days)
                    flower = 0;
                else
                {
                    bouquet += (flower + 1) / k;
                    flower = (flower + 1) % k;
                }
            }
            return bouquet >= m;
        }
        #endregion
    }
}
