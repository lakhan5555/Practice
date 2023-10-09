using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class SlidingWindow
    {
        public void Main()
        {
            var a = "cbaebabacd";
            var b = "abc";
            var c = FindAnagrams(a, b);
        }

        #region Cheat Template
        // link - https://leetcode.com/problems/frequency-of-the-most-frequent-element/solutions/1175088/C++-Maximum-Sliding-Window-Cheatsheet-Template/
        #endregion

        #region Best Time to Buy and Sell Stock

        #region Approach 1 - Brute force. Time - O(n*2)
        public int MaxProfit(int[] prices)
        {
            int max = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    max = Math.Max(max, prices[j] - prices[i]);
                }
            }
            return max;
        }
        #endregion

        #region Approach 2 - Sliding window. Time - O(n)
        public int MaxProfit1(int[] prices)
        {
            if(prices.Length < 2)
                return 0;

            int left = 0, right = 1, max = 0, curr;
            while(right < prices.Length)
            {
                curr = prices[right] - prices[left];
                if(curr < 0)
                    left = right;
                else
                    max = Math.Max(max, curr);

                right++;
            }
            return max;
        }
        #endregion

        #endregion

        #region Longest Substring Without Repeating Characters
        #region Approach 1 - Brute force. Time - O(n*2)
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            if (n < 2)
                return n;
            string maxSubString = string.Empty;
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                maxSubString += s[i];
                for (int j = i + 1; j < n; j++)
                {
                    if (maxSubString.Contains(s[j]))
                    {
                        maxSubString = string.Empty;
                        break;
                    }
                    else
                        maxSubString += s[j];
                    ans = Math.Max(ans, maxSubString.Length);
                }
            }
            return ans;
        }
        #endregion

        #region Approach 2 - Sliding Window. Time - O(n), space - O(n)
        public int LengthOfLongestSubstring1(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int ans = 0;
            for(int i=0,j=0;j < s.Length;j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(i, map[s[j]] + 1);
                    map[s[j]] = j;
                }
                else
                    map.Add(s[j], j);
                ans = Math.Max(ans, j - i + 1);
            }
            return ans;
        }
        #endregion

        #region Approach 3 - SlidingWindow. Time - O(n), space - O(1)
        public int LengthOfLongestSubstring2(string s)
        {
            int i = 0, j = 0, n = s.Length, ans = 0;
            int[] ct = new int[128];
            for (; j < n; j++)
            {
                ct[s[j]]++;
                while (ct[s[j]] > 1) ct[s[i++]]--;
                ans = Math.Max(ans, j - i + 1);
            }
            return ans;
        }
        #endregion

        #endregion

        #region Frequency of the Most Frequent Element
        // link - https://leetcode.com/problems/frequency-of-the-most-frequent-element/description/
        public int MaxFrequency(int[] nums, int k)
        {
            Array.Sort(nums);
            int i = 0, j = 0, n = nums.Length, ans = 1, sum = 0;
            for(;j < n;j++)
            {
                sum += nums[j];
                while ((j - i + 1) * nums[j] - sum > k)
                    sum -= nums[i++];
                ans = Math.Max(ans, j - i + 1);
            }
            return ans;
        }
        #endregion

        #region Longest Subarray of 1's After Deleting One Element
        // link - https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/
        public int LongestSubarray(int[] nums)
        {
            int i = 0, j = 0, n = nums.Length,ans = 0, ct = 0;
            for (; j < n; j++)
            {
                ct += nums[j] == 0 ? 1 : 0;
                while(ct > 1)
                    ct -= nums[i++] == 0 ? 1 : 0;
                ans = Math.Max(ans, j - i);
            }
            return ans;
        }
        #endregion

        #region Subarray Product Less Than K
        // link - https://leetcode.com/problems/subarray-product-less-than-k/description/
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k == 0) return 0;
            int i = 0, j = 0, n = nums.Length, ans = 0, mul = 1;
            for (; j < n; j++)
            {
                mul *= nums[j];
                while (i <=j && mul >= k)
                    mul /= nums[i++];
                ans += j - i + 1;
            }
            return ans;
        }
        #endregion

        #region Longest Repeating Character Replacement
        public int CharacterReplacement(string s, int k)
        {
            int i = 0, j = 0, n = s.Length, maxCount = 0, maxLength = 0;
            int[] ct = new int[26];
            for (;j < n; j++)
            {
                maxCount = Math.Max(maxCount, ++ct[s[j] - 'A']);
                while (j - i + 1 - maxCount > k)
                    ct[s[i++] - 'A']--;
                maxLength = Math.Max(maxLength, j - i + 1);
            }
            return maxLength;
        }
        #endregion

        #region Permutation in String
        public bool CheckInclusion(string s1, string s2)
        {
            if(s1.Length > s2.Length) return false;
            int[] fr1 = new int[26], fr2 = new int[26];
            int i = 0, j = 0,n1= s1.Length, n2 = s2.Length;
            for (i = 0; i < s1.Length; i++)
                fr1[s1[i] - 'a']++;
            i = 0;
            while (j < n2)
            {
                fr2[s2[j] - 'a']++;
                if (j - i + 1 == n1)
                {
                    if (isEqual(fr1, fr2)) return true;
                }
                if (j - i + 1 < n1) j++;
                else
                {
                    fr2[s2[i] - 'a']--;
                    i++;j++;
                }
            }
            return false;
        }
        public bool isEqual(int[] fr1, int[] fr2)
        {
            for(int i = 0; i < fr1.Length; i++)
            {
                if (fr1[i] != fr2[i]) return false;
            }
            return true;
        }
        #endregion

        #region Find All Anagrams in a String
        // link - https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
        public IList<int> FindAnagrams(string s, string p)
        {
            IList<int> list = new List<int>();
            if(p.Length > s.Length) return list;
            int i = 0, j = 0, np = p.Length, ns= s.Length;
            int[] frp = new int[26], frs = new int[26];
            foreach (var item in p)
                frp[item - 'a']++;
            while (j < ns)
            {
                frs[s[j] - 'a']++;
                if(j-i+1 == np)
                {
                    if(isEqual(frp, frs))
                        list.Add(i);
                }
                if (j - i + 1 < np) j++;
                else
                {
                    frs[s[i] - 'a']--;
                    j++;i++;
                }
            }
            return list;
        }
        #endregion

    }
}
