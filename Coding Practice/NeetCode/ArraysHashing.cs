using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode
{
    public class ArraysHashing
    {
        #region Question 1 - Contains Duplicate
        // link - https://leetcode.com/problems/contains-duplicate/
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var item in nums)
            {
                if (!set.Add(item))
                    return true;
            }
            return false;
        }
        #endregion

        #region Question 2 - Valid Anagram
        // link - https://leetcode.com/problems/valid-anagram/description/

        public bool IsAnagram(string s, string t)
        {
            int[] arr = new int[26];
            foreach(char c in s)
                arr[(int)c - 97]++;
            foreach (char c in t)
                arr[(int)c - 97]--;
            foreach (int i in arr)
                if (i != 0)
                    return false;
            return true;
        }
        #endregion

        #region Question 3 - Two Sum
        // link - https://leetcode.com/problems/two-sum/description/

        public int[] TwoSum(int[] nums, int target)
        {
            int[] arr = new int[2];
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                var otherNum = target - nums[i];
                if (dict.ContainsKey(otherNum))
                {
                    arr[0] = i;
                    arr[1] = dict[otherNum];
                }
                else
                {
                    dict[nums[i]] = i;
                }
            }
            return arr;
        }
        #endregion

        #region Question 4 - Group Anagrams
        //link - https://leetcode.com/problems/group-anagrams/

        #region Approach1 - using sorting
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> ans = new List<IList<string>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach(var s in strs)
            {
                var sortedSArray = s.ToArray();
                Array.Sort(sortedSArray);
                string sortedS = new string(sortedSArray);
                if (dict.ContainsKey(sortedS))
                {
                    dict[sortedS].Add(s);
                }
                else
                {
                    var list = new List<string>();
                    list.Add(s);
                    dict.Add(sortedS, list);
                }
            }
            foreach(var item in dict)
            {
                ans.Add(item.Value);
            }
            return ans;
        }
        #endregion

        #region Approach2 - without sorting
        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {
            IList<IList<string>> ans = new List<IList<string>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (var s in strs)
            {
                char[] ch = new char[26];
                foreach(char c in s)
                {
                    ch[c - 'a']++;
                }
                string newS = new string(ch);
                if (dict.ContainsKey(newS))
                {
                    dict[newS].Add(s);
                }
                else
                {
                    var list = new List<string>();
                    list.Add(s);
                    dict.Add(newS, list);
                }
            }
            foreach (var item in dict)
            {
                ans.Add(item.Value);
            }
            return ans;
        }
        #endregion
        #endregion

        #region question 5 - Top K Frequent Elements
        //link - https://leetcode.com/problems/top-k-frequent-elements/
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> myDict = new Dictionary<int, int>();

            foreach (var i in nums)
            {
                if (myDict.ContainsKey(i))
                {
                    myDict[i]++;
                }
                else
                {
                    myDict[i] = 1;
                }
            }
            var aa = myDict.ToList();

            aa.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            int[] ans = new int[k];

            for (int i = 0; i < k; i++)
            {
                ans[i] = aa[i].Key;
            }
            return ans;
        }
        #endregion

        #region Question 6 - Product of Array Except Self
        //link - https://leetcode.com/problems/product-of-array-except-self/
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            res[0] = 1;
            for(int i = 1;i < n; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }
            int right = 1;
            for(int i = (n-1);i >= 0; i--)
            {
                res[i] *= right;
                right *= nums[i];
            }
            return res;
        }
        #endregion

        #region Question 6 - Longest Consecutive Sequence
        #region Approach 1 - using set. Searching in set is O(1)
        // sln link - https://leetcode.com/problems/longest-consecutive-sequence/solutions/41057/simple-o-n-with-explanation-just-walk-each-streak/
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> set = nums.ToHashSet();
            int ans = 0;
            foreach(var x in set)
            {
                if (set.Contains(x - 1))
                    continue;
                int y = x + 1;
                while (set.Contains(y))
                    y++;
                ans = Math.Max(ans, y - x);
            }
            return ans;
        }
        #endregion

        #region Approach 2 - Using Dictionary
        // sln link - https://leetcode.com/problems/longest-consecutive-sequence/solutions/41055/my-really-simple-java-o-n-solution-accepted/
        public int LongestConsecutive1(int[] nums)
        {
            Dictionary<int,int> dict = new Dictionary<int,int>();
            int ans = 0;
            foreach(var x in nums)
            {
                int left = dict.ContainsKey(x-1) ? dict[x-1] : 0;
                int right = dict.ContainsKey(x+1) ? dict[x+1] : 0;

                int sum = left + right + 1;
                dict[x] = sum;
                ans = Math.Max(ans, sum);
                if(left != 0)
                    dict[x-left] = sum;
                if(right != 0)
                    dict[x+right] = sum;
            }
            return ans;
        }
        #endregion
        #endregion
    }
}
