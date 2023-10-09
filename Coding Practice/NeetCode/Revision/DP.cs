using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class DP
    {
        public void main()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[3] { 1, 3, 1 };
            arr[1] = new int[3] { 1, 5, 1 };
            arr[2] = new int[3] { 4, 2, 1 };

            //var ans = MinPathSum(arr);

            int n = 1, k = 6, target = 3;
            var ans = NumRollsToTarget(n,k, target);
        }

        #region Min Cost Climbing Stairs
        // link - https://leetcode.com/problems/min-cost-climbing-stairs/description/
        public int MinCostClimbingStairs(int[] cost)
        {
            int first = cost[0], second = cost[1], curr;
            for(int i = 2; i < cost.Length; i++)
            {
                curr = Math.Min(first,second) + cost[i];
                first = second;
                second = curr;
            }
            return Math.Min(first,second);
        }
        #endregion

        #region Minimum Path Sum
        // link - https://leetcode.com/problems/minimum-path-sum/description/
        public int MinPathSum(int[][] grid)
        {
            int n = grid.Length, m = grid[0].Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
                dp[i] = new int[m];
            dp[0][0] = grid[0][0];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    if (i == 0)
                        dp[i][j] = dp[i][j - 1] + grid[i][j];
                    else if(j == 0)
                        dp[i][j] = dp[i - 1][j] + grid[i][j];
                    else
                        dp[i][j] = Math.Min(dp[i][j - 1], dp[i - 1][j]) + grid[i][j];
                }
            }
            return dp[n-1][m-1];
        }
        #endregion

        #region Coin Change
        // link - https://leetcode.com/problems/coin-change/description/
        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            int maxAmount = amount + 1;
            for(int i = 0;i<= amount;i++)
                dp[i] = maxAmount;
            dp[0] = 0;
            for(int i = 0;i<= amount; i++)
                for(int j = 0; j < coins.Length; j++)
                    if (i >= coins[j])
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);

            return dp[amount] >= maxAmount ? -1 : dp[amount];
        }

        #endregion

        #region Climbing Stairs
        // link - https://leetcode.com/problems/climbing-stairs/
        public int ClimbStairs(int n)
        {
            if (n <= 2)
                return n;
            int first = 1, second = 2, curr = 0;
            for(int i = 3; i <= n; i++)
            {
                curr = first + second;
                first = second;
                second = curr;
            }
            return curr;
        }
        #endregion

        #region Unique Paths
        // link - https://leetcode.com/problems/unique-paths/description/
        public int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];
            for(int i = 0;i<m;i++)
                for(int j =0;j<n;j++)
                {
                    if (i == 0 || j == 0)
                        dp[i, j] = 1;
                    else
                        dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                }
            return dp[m - 1, n - 1];
        }
        #endregion

        #region Number of Dice Rolls With Target Sum
        // link - https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/description/
        public int NumRollsToTarget(int n, int k, int target)
        {
            int[] dp = new int[target + 1];
            dp[0] = 1;
            int mod = (int)(Math.Pow(10, 9) + 7);
            for(int i = 1;i <= n; i++)
            {
                int[] dp1 = new int[target + 1];
                for (int j = 1; j <= k; j++)
                    for (int l = j; l <= target; l++)
                    {
                        dp1[l] += dp[l - j];
                        dp1[l] %= mod;
                    }
                dp = dp1;
            }
                
            return dp[target];
        }
        #endregion
    }
}
