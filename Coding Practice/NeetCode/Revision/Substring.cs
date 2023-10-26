using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    
    public class Substring
    {
        // cheat sheet
        // https://leetcode.com/problems/minimum-window-substring/solutions/26808/Here-is-a-10-line-template-that-can-solve-most-'substring'-problems/
        public void main()
        {
            string s = "ADOBECODEBANC", t = "ABC";
            var ans = MinWindow(s, t);
        }

        #region Minimum Window Substring
        // link - https://leetcode.com/problems/minimum-window-substring/description/
        public string MinWindow(string s, string t)
        {
            int[] arr = new int[128];
            for (int i = 0; i < t.Length; i++)
                arr[t[i]]++;
            int begin = 0, end = 0, counter = t.Length, d = int.MaxValue, head = 0;
            while(end < s.Length)
            {
                if (arr[s[end]] > 0)
                    counter--;
                arr[s[end]]--;
                end++;
                while (counter == 0)
                {
                    if (end - begin < d)
                    {
                        d = end - begin;
                        head = begin;
                    }
                    arr[s[begin]]++;
                    if (arr[s[begin]] > 0)
                        counter++;
                    begin++;
                }
                
            }
            return d == int.MaxValue ? "" : s.Substring(head,d);
        }
        #endregion
    }
}
