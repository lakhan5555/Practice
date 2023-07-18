using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision_2
{
    public class DP
    {
        #region Climbing Stairs
        // link - https://leetcode.com/problems/climbing-stairs/description/
        public int ClimbStairs(int n)
        {
            if(n <= 0) return 0;
            if(n == 1) return 1;
            if(n == 2) return 2;

            int prevPrev = 1, prev = 2, curr = 0;
            for(int i = 3; i <= n; i++)
            {
                curr = prev + prevPrev;
                prevPrev = prev;
                prev = curr;
            }
            return curr;
        }
        #endregion

        #region Min Cost Climbing Stairs
        // link - https://leetcode.com/problems/min-cost-climbing-stairs/description/
        #region Approach1 - Space - O(n)
        public int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i < 2)
                    dp[i] = cost[i];
                else
                    dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);
            }
            return Math.Min(dp[n - 1], dp[n - 2]);
        }
        #endregion

        #region Approach2 - Space - (1)
        public int MinCostClimbingStairs1(int[] cost)
        {
            int n = cost.Length;
            int first = cost[0], second = cost[1], curr;
            if(n <= 2)
                return Math.Min(first, second); 

            for(int i = 2; i < n; i++)
            {
                curr = cost[i] + Math.Min(first, second);
                first = second;
                second = curr;
            }
            return Math.Min(first, second);

        }
        #endregion
        #endregion

        #region Coin Change
        // link - https://leetcode.com/problems/coin-change/
        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            int maxValue = amount + 1;
            for (int i = 0; i <= amount; i++)
                dp[i] = maxValue;
            dp[0] = 0;
            for(int i = 1; i <= amount; i++)
            {
                for(int j = 0; j < coins.Length; j++)
                {
                    if(i >= coins[j])
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }
        #endregion

    }
}
