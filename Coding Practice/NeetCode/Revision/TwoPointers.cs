using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class TwoPointers
    {
        #region Two Sum II - Input Array Is Sorted
        public int[] TwoSum(int[] numbers, int target)
        {
            int i = 0, j = numbers.Length - 1, sum = 0;
            int[] ans = new int[2];
            while(i < j)
            {
                sum = numbers[i] + numbers[j];
                if(sum == target)
                {
                    ans[0] = i + 1; ans[1] = j+1;
                    break;
                }
                else if(sum > target)
                    j--;
                else
                    i++;
            }
            return ans;
        }
        #endregion

        #region 3Sum
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> ans = new List<IList<int>>();

            for(int i = 0; i < nums.Length-1;i++)
            {
                if (nums[i] > 0)   // since array is sorted and this is positive. so sum cannot be zero
                    break;
                if (i > 0 && nums[i] == nums[i - 1])   // to remove duplicate
                    continue;

                int l = i + 1, r = nums.Length - 1, target = -nums[i];
                while(l < r)
                {
                    int sum = nums[l] + nums[r];
                    if (sum > target)
                        r--;
                    else if (sum < target)
                        l++;
                    else
                    {
                        IList<int> subIns = new List<int>
                        {
                            nums[i],
                            nums[l],
                            nums[r]
                        };

                        ans.Add(subIns);

                        int lastL = nums[l], lastR = nums[r];
                        while (l < r && nums[l] == lastL)
                            l++;
                        while (l < r && nums[r] == lastR)
                            r--;
                    }
                }
            }
            return ans;

        }
        #endregion

        #region Valid Palindrome II
        public bool ValidPalindrome(string s)
        {
            int i = 0, j = s.Length - 1;
            while(i < j)
            {
                if (s[i] != s[j])
                    return isPalindrome(s, i + 1, j) || isPalindrome(s, i, j - 1);
                i++;
                j--;
            }
            return true;
        }
        public bool isPalindrome(string s, int i, int j)
        {
            while(i < j)
            {
                if (s[i] != s[j]) return false;
                i++;j--;
            }
            return true;
        }
        #endregion

        #region Merge Sorted Array
        // link - https://leetcode.com/problems/merge-sorted-array/description/
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while( i >= 0 && j >= 0)
            {
                if (nums1[i] < nums2[j])
                    nums1[k--] = nums2[j--];
                else
                    nums1[k--] = nums1[i--];
            }
            while(j >= 0)
            {
                nums1[k--] = nums2[j--];
            }
        }
        #endregion

    }
}
