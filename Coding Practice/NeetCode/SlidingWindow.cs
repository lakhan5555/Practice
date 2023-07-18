using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Practice
{
    public class SlidingWindow
    {
        #region Question1
        //link - https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public int MaxProfit(int[] prices)
        {
            int i = 0;
            int j = 1;
            int max_profit = 0;
            while (j < prices.Length)
            {
                max_profit = Math.Max(max_profit, (prices[j] - prices[i]));
                if (prices[i] >= prices[j])
                {
                    i = j;
                    j++;
                }
                else
                    j++;
            }
            return max_profit;
        }
        #endregion

        #region Question2
        //link - https://leetcode.com/problems/longest-substring-without-repeating-characters/
        public int LengthOfLongestSubstring(string s)
        {
            int max_so_far = 0;
            var dict = new Dictionary<char, int>();
            for (int i = 0, j = 0; j < s.Length; j++)
            {
                if (dict.ContainsKey(s[j]))
                {
                    i = Math.Max(i, dict[s[j]] + 1);
                    dict[s[j]] = j;
                }
                else
                {
                    dict.Add(s[j], j);
                }
                max_so_far = Math.Max(max_so_far, j - i + 1);
            }
            return max_so_far;
        }
        #endregion
    }
}
