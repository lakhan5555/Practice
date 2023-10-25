using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class DP
    {
        public void main()
        {
            //int[][] arr = new int[3][];
            //arr[0] = new int[3] { 1, 3, 1 };
            //arr[1] = new int[3] { 1, 5, 1 };
            //arr[2] = new int[3] { 4, 2, 1 };

            ////var ans = MinPathSum(arr);

            //int n = 1, k = 6, target = 3;
            //var ans = NumRollsToTarget(n,k, target);

            string s = "babad";
            var ans = LongestPalindrome(s);
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

        #region Longest Common Subsequence
        // link - https://leetcode.com/problems/longest-common-subsequence/description/
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int n1 = text1.Length, n2 = text2.Length;
            int[,] dp = new int[n1 + 1, n2 + 1];
            for(int i = 0; i < n1; i++)
                for(int j = 0; j < n2; j++)
                {
                    if (text1[i] == text2[j])
                        dp[i + 1, j + 1] = dp[i, j] + 1;
                    else
                        dp[i + 1, j + 1] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
                }
            return dp[n1, n2];
        }

        #region Space efficient
        // in above solution, we are only using two rows for each i i.e current row and previous row
        public int LongestCommonSubsequence1(string text1, string text2)
        {
            int n1 = text1.Length, n2 = text2.Length;
            int[,] dp = new int[2, n2 + 1];                   // two rows
            for (int i = 0; i < n1; i++)
                for (int j = 0; j < n2; j++)
                {
                    if (text1[i] == text2[j])
                        dp[(i + 1) % 2, j + 1] = dp[i % 2, j] + 1;
                    else
                        dp[(i + 1) % 2, j + 1] = Math.Max(dp[(i + 1) % 2, j], dp[i % 2, j + 1]);
                }
            return dp[n1 % 2, n2];
        }
        #endregion
        #endregion

        #region Longest Common Substring
        public int LongestCommonSubstring(string text1, string text2)
        {
            int n1 = text1.Length, n2 = text2.Length;
            int[,] dp = new int[n1 + 1, n2 + 1];
            for (int i = 0; i < n1; i++)
                for (int j = 0; j < n2; j++)
                {
                    if (text1[i] == text2[j])
                        dp[i + 1, j + 1] = dp[i, j] + 1;
                    else
                        dp[i + 1, j + 1] = 0;
                }
            return dp[n1, n2];
        }
        #endregion

        #region Longest Palindromic Substring
        // link - https://leetcode.com/problems/longest-palindromic-substring/description/

        #region Brute Force. Time - O(n*3)
        public string LongestPalindrome1(string s)
        {
            int n = s.Length;
            string max = string.Empty;
            for(int i = 0; i < n - 1; i++)
            {
                for(int j = i;j < n; j++)
                {
                    if (isPalindrome(s, i, j))
                    {
                        string palinDrome = s.Substring(i, j - i + 1);
                        if (palinDrome.Length > max.Length)
                            max = palinDrome;
                    }
                }
            }
            return max;
        }
        public bool isPalindrome(string s, int i, int j)
        {
            while(i < j)
            {
                if (s[i] != s[j])
                    return false;
                i++;j--;
            }
            return true;
        }
        #endregion

        #region Optimized. Time - O(n*2)
        public string LongestPalindrome(string s)
        {
            string max = string.Empty;
            for(int i = 0; i < s.Length; i++)    // time - O(n)
            {
                string s1 = Extend(s, i, i);        // time - O(n)
                string s2 = Extend(s, i, i + 1);
                if (s1.Length > max.Length)
                    max = s1;
                if (s2.Length > max.Length)
                    max = s2;
            }
            return max;
        }
        public string Extend(string s, int i, int j)
        {
            for (; i >= 0 && j < s.Length; i--, j++)
                if (s[i] != s[j])
                    break;
            return s.Substring(i + 1, j - i - 1);
        }
        #endregion
        #endregion

        #region Palindromic Substrings
        // link - https://leetcode.com/problems/palindromic-substrings/
        public int CountSubstrings(string s)
        {
            int count = 0;
            for(int i = 0; i < s.Length; i++) 
            {
                count += extendPalindrome(s, i, i);
                count += extendPalindrome(s, i, i+1);
            }
            return count;
        }
        public int extendPalindrome(string s, int i, int j)
        {
            int count = 0;
            while(i >= 0 && j < s.Length && s[i] == s[j])
            {
                count++;
                i--;j++;
            }
            return count;
        }
        #endregion

        #region House Robber
        // link - https://leetcode.com/problems/house-robber/description/
        public int Rob(int[] nums)
        {
            if(nums.Length== 0)
                return 0;
            int first = 0, second = nums[0], n = nums.Length, curr = nums[0];
            for(int i = 1; i < n; i++)
            {
                curr = Math.Max(first + nums[i], second);
                first = second;
                second = curr;
            }
            return curr;
        }
        #endregion

        #region House Robber II
        // link - https://leetcode.com/problems/house-robber-ii/description/
        // sln link - https://leetcode.com/problems/house-robber-ii/solutions/59921/9-lines-0ms-o-1-space-c-solution/
        public int Rob1(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            return Math.Max(Robber(nums, 0, n - 2), Robber(nums, 1, n - 1));
        }
        public int Robber(int[] nums, int l, int r)
        {
            int first = 0, second = 0, curr = 0;
            for(int i = l; i <= r; i++)
            {
                curr = Math.Max(first + nums[i], second);
                first = second;
                second = curr;
            }
            return curr;
        }
        #endregion

        #region Revision
        public class Revision
        {
            #region Min Cost Climbing Stairs
            public int MinCostClimbingStairs(int[] cost)
            {
                int first = cost[0], second = cost[1], curr, N = cost.Length;
                for (int i = 2; i < N; i++)
                {
                    curr = Math.Min(first, second) + cost[i];
                    first = second;
                    second = curr;
                }
                return Math.Min(first, second);
            }
            #endregion

            #region Minimum Path Sum
            public int MinPathSum(int[][] grid)
            {
                int m = grid.Length, n= grid[0].Length;
                int[][] dp = new int[m][];
                for (int i = 0; i < m; i++)
                    dp[i] = new int[n];
                for(int i = 0; i < m; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        if(i == 0 && j == 0)
                            dp[0][0] = grid[i][j];
                        else if(i == 0)
                            dp[i][j] = dp[i][j-1] + grid[i][j];
                        else if(j == 0)
                            dp[i][j] = dp[i - 1][j] + grid[i][j];
                        else
                            dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j-1]) + grid[i][j];
                    }
                }
                return dp[m - 1][n - 1];
            }
            #endregion

            #region Coin Change
            public int CoinChange(int[] coins, int amount)
            {
                int[] dp = new int[amount + 1];
                int maxAmount = amount + 1, N = coins.Length;
                for (int i = 0; i < maxAmount; i++)
                    dp[i] = maxAmount;
                dp[0] = 0;
                for(int i = 1;i< maxAmount; i++)
                    for(int j = 0; j < N; j++)
                        if (coins[j] <= i)
                            dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                return dp[amount] == maxAmount ? -1 : dp[amount];
            }
            #endregion

            #region Climbing Stairs
            // tabulation
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
            // Memoization
            public int ClimbStairsMemo(int n)
            {
                int[] memo = new int[n+1];
                return ClimbStairsMemoUtil(n, memo);
            }
            public int ClimbStairsMemoUtil(int n, int[] memo)
            {
                if (memo[n] != 0)
                    return memo[n];
                if(n == 1 || n == 2)
                {
                    memo[n] = n;
                    return n;
                }
                memo[n] = ClimbStairsMemoUtil(n - 1, memo) + ClimbStairsMemoUtil(n - 2, memo);
                return memo[n];
            }
            #endregion

            #region Unique Paths
            public int UniquePaths(int m, int n)
            {
                int[,] dp = new int[m, n];
                for(int i = 0;i<m;i++)
                    for(int j = 0; j < n; j++)
                    {
                        if (i == 0 || j == 0)
                            dp[i, j] = 1;
                        else
                            dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                return dp[m - 1, n - 1];
            }

            public int UniquePathsMemo(int m, int n)
            {
                int[,] memo= new int[m, n];
                return UniquePathsMemoUtil(m-1,n-1,memo);
            }
            public int UniquePathsMemoUtil(int m, int n, int[,] memo)
            {
                if (memo[m, n] != 0)
                    return memo[m, n];
                if(m == 0 || n == 0)
                {
                    memo[m, n] = 1;
                    return 1;
                }
                memo[m, n] = UniquePathsMemoUtil(m - 1, n, memo) + UniquePathsMemoUtil(m, n - 1, memo);
                return memo[m, n];
            }
            #endregion

        }
        #endregion
    }
}
