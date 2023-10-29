﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Leetcode_TopInterviewQuestions
{
    public class TopInterviewQuestions
    {
        public void Main()
        {
            #region Roman to Integer
            //string s = "MCMXCIV";
            //int ans = RomanToInt1(s);
            #endregion

            #region Longest Common Prefix
            //string[] str = new string[] { "dog", "racecar", "car" };
            //var ans = LongestCommonPrefix(str);
            #endregion

            string s1 = "mississippi", s2 = "issip";
            var ans = StrStr(s1, s2);
        }

        #region Two Sum
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int,int> map = new Dictionary<int,int>();
            int[] ans = new int[2];
            for(int i = 0; i < nums.Length; i++)
            {
                int remaining = target - nums[i];
                if (map.ContainsKey(remaining))
                {
                    ans[0] = map[remaining];
                    ans[1] = i;
                    break;
                }
                else if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], i);
            }
            return ans;
        }
        #endregion

        #region Roman to Integer
        public int RomanToInt(string s)
        {
            int ans = 0, n = s.Length;
            for(int i = 0; i < n; i++)
            {
                if (s[i] == 'I')
                {
                    if (i < (n - 1) && s[i + 1] == 'V')
                    {
                        ans += 4;
                        i++;
                    }
                    else if (i < (n - 1) && s[i + 1] == 'X')
                    {
                        ans += 9;
                        i++;
                    }
                    else
                        ans += 1;
                }
                else if (s[i] == 'V')
                    ans += 5;
                else if (s[i] == 'X')
                {
                    if (i < (n - 1) && s[i + 1] == 'L')
                    {
                        ans += 40;
                        i++;
                    }
                    else if (i < (n - 1) && s[i + 1] == 'C')
                    {
                        ans += 90;
                        i++;
                    }
                    else
                        ans += 10;
                }
                else if (s[i] == 'L')
                    ans += 50;
                else if (s[i] == 'C')
                {
                    if (i < (n - 1) && s[i + 1] == 'D')
                    {
                        ans += 400;
                        i++;
                    }
                    else if (i < (n - 1) && s[i + 1] == 'M')
                    {
                        ans += 900;
                        i++;
                    }
                    else
                        ans += 100;
                }
                else if (s[i] == 'D')
                    ans += 500;
                else if (s[i] == 'M')
                    ans += 1000;
            }
            return ans;
        }

        #region Clean Code
        public int RomanToInt1(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            map['I'] = 1;
            map['V'] = 5;
            map['X'] = 10;
            map['L'] = 50;
            map['C'] = 100;
            map['D'] = 500;
            map['M'] = 1000;

            int n = s.Length, ans = 0;
            for(int i = 0;i < n; i++)
            {
                if (i < n - 1 && map[s[i]] < map[s[i + 1]])
                    ans -= map[s[i]];
                else
                    ans+= map[s[i]];
            }
            return ans;
        }
        #endregion
        #endregion

        #region Longest Common Prefix
        public string LongestCommonPrefix(string[] strs)
        {
            int n = strs.Length, i = 0;
            for(; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                for(int j = 1;j < n; j++)
                {
                    if (strs[j].Length <= i || strs[j][i] != c)
                        return strs[0].Substring(0, i);
                }
            }
            return strs[0].Substring(0, i);
        }

        #region Other Approach
        public string LongestCommonPrefix1(string[] strs)
        {
            Array.Sort(strs);
            string first = strs[0], second = strs[strs.Length - 1], ans = "";
            int i = 0;
            while(i < first.Length && i < second.Length)
            {
                if (first[i] == second[i])
                    ans += first[i];
                else
                    break;
                i++;
            }
            return ans;
        }
        #endregion
        #endregion

        #region Valid Parentheses
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            for(int i = 0;i<s.Length;i++)
            {
                char c = s[i];
                if (c == '(')
                    stack.Push(')');
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');
                else if (stack.Count == 0 || stack.Pop() != c)
                        return false;
            }
            return stack.Count == 0;
        }
        #endregion

        #region Merge Two Sorted Lists
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode();
            ListNode temp = dummy;
            while(list1 != null && list2 != null)
            {
                if(list1.val < list2.val)
                {
                    temp.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    temp.next = list2;
                    list2 = list2.next;
                }
                temp = temp.next;
            }
            if(list1 != null)
                temp.next = list1;
            if(list2 != null)
                temp.next = list2;
            return dummy.next;
        }
        #endregion

        #region Remove Duplicates from Sorted Array
        public int RemoveDuplicates(int[] nums)
        {
            int i = 1, j = 1, n = nums.Length;
            for (; j < n; j++)
            {
                if (nums[j] != nums[j-1])
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }
        #endregion

        #region Find the Index of the First Occurrence in a String
        public int StrStr(string haystack, string needle)
        {
            int n = haystack.Length, m = needle.Length;
            for(int i = 0;i<n;i++)
            {
                int j = 0;
                for(int k = i;k< n && j < m;k++,j++) 
                {
                    if (haystack[k] != needle[j])
                        break;
                }
                if (j == m)
                    return i;
            }
            return -1;
        }
        #endregion

        #region Plus One
        public int[] PlusOne(int[] digits)
        {
            int carry = 1, n = digits.Length;
            for(int i = n-1; i >= 0; i--)
            {
                if (carry == 0)
                    break;
                int sum = digits[i] + carry;
                digits[i] = sum % 10;
                carry = sum / 10;
            }
            if(carry == 1)
            {
                int[] ans = new int[n + 1];
                ans[0] = 1;
                return ans;
            }
            return digits;
        }
        #endregion

        #region Sqrt(x)
        public int MySqrt(int x)
        {
            if (x <= 1) return x;
            int l = 1, r = x, mid;
            while(l < r)
            {
                mid = l + (r - l) / 2;
                if (mid > x / mid)
                    r = mid;
                else
                    l = mid + 1;
            }
            return l - 1;
        }
        #endregion

        #region Climbing Stairs
        public int ClimbStairs(int n)
        {
            if(n <= 2) return n;
            int first = 1, second = 2, curr = 0;
            for(int i = 3;i<= n; i++)
            {
                curr = first + second;
                first = second;
                second = curr;
            }
            return curr;
        }
        #endregion

        #region Merge Sorted Array
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while(j >= 0)
            {
                if (i >= 0 && nums1[i] > nums2[j])
                    nums1[k--] = nums1[i--];
                else
                    nums1[k--] = nums2[j--];
            }
        }
        #endregion

    }
}