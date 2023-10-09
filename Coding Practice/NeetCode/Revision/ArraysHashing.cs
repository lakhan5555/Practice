using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class ArraysHashing
    {
        #region Main 
        public void Main()
        {
            var s = "luffy";
            var ans = LengthOfLastWord(s);
        }
        #endregion

        #region Question 1 - Replace Elements with Greatest Element on Right Side
        public int[] ReplaceElements(int[] arr)
        {
            int maxEle = -1, temp;
            for(int i = arr.Length-1;i >= 0;i--)
            {
                temp = arr[i];
                arr[i] = maxEle;
                maxEle = Math.Max(maxEle, temp);
            }
            return arr;
        }
        #endregion

        #region Question 2 - Length of Last Word
        public int LengthOfLastWord(string s)
        {
            int max = 0;
            for(int i = s.Length-1;i >=0;i--)
            {
                if (s[i] == ' ' && max > 0)
                    break;
                if (s[i] != ' ')
                    max++;
            }
            return max;
        }
        #endregion

        #region Question 3 - Is Subsequence
        public bool IsSubsequence(string s, string t)
        {
            int i = 0, j = 0;
            while(i < s.Length && j < t.Length) 
            {
                if (s[i] == t[j])
                    i++;
                j++;
            }
            return i == s.Length;
        }
        #endregion

        #region Question 3 - Is Substring
        public bool IsSubstring(string s, string t)
        {
            int i = 0, j = 0, k = 0;
            while (i < s.Length && j < t.Length)
            {
                if (s[i] == t[j])
                {
                    if (j - k > 1)
                        break;
                    i++;
                }
                j++;
                k = j;
            }
            return i == s.Length;
        }
        #endregion
    }
}
