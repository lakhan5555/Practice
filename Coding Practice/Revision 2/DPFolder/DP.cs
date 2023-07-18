using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Revision_2.DPFolder
{
    public class DP
    {
        #region Total number of we can form a number
        // Given 3 numbers {1, 3, 5}, the task is to tell the total number of ways we can form a
        // number N using the sum of the given three numbers. (allowing repetitions and
        // different arrangements).

        public int TotalNumberOfWays(int n)
        {
            int[] dp = new int[n+1];
            for (int i = 0; i <= dp.Length; i++)
                dp[i] = -1;
            return TotalNumberOfWaysUtil(n, dp);
        }
        public int TotalNumberOfWaysUtil(int n, int[] dp)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (dp[n] != -1)
                return dp[n];
            return dp[n] = TotalNumberOfWaysUtil(n - 1, dp) + TotalNumberOfWaysUtil(n - 3, dp) + TotalNumberOfWaysUtil(n - 5, dp);
        }
        #endregion

        #region Fibonacci Numbers - Memoization(Top down approach). Time - O(n), Space - O(n)
        public int FibonacciNumbers(int n)
        {
            int[] dp = new int[n + 1];
            for(int i = 0; i <= n;i++)
                dp[i] = -1;
            return FibonacciNumbersUtil(n, dp);
        }
        public int FibonacciNumbersUtil(int n, int[] dp)
        {
            if (n <= 1)
                return n;
            if (dp[n] != -1)
                return dp[n];
            return dp[n] = FibonacciNumbersUtil(n - 1, dp) + FibonacciNumbersUtil(n - 2, dp);
        }
        #endregion

        #region Fibonacci Numbers - Tabulation(Bottom Up approach). Time - O(n), Space - O(n)
        public int FibonacciNumbers1(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
                dp[i] = dp[i - 1] + dp[i - 2];
            return dp[n];
        }


        #endregion

        #region Fibonacci Numbers - Constant Time. Time - O(n), Space - O(1)
        public int FibonacciNumbers2(int n)
        {
            if (n <= 1)
                return n;

            int prevPrev = 0, prev = 1, curr = 0;
            for(int i = 2; i <= n; i++)
            {
                curr = prev + prevPrev;
                prevPrev = prev;
                prev = curr;
            }
            return curr;
        }
        #endregion

        #region Min Cost Path
        // Given a cost matrix cost[][] and a position (M, N) in cost[][], write a function that
        // returns cost of minimum cost path to reach (M, N) from (0, 0). You can only traverse down,
        // right and diagonally lower cells from a given cell

        // link - https://www.geeksforgeeks.org/min-cost-path-dp-6/

        #region Approach 1 - Using Recursion

        public int Min(int x, int y, int z)
        {
            if (x < y)
                return x < z ? x : z;
            else
                return y < z ? y : z;
        }
        public int minCostRecur(int[,] matrix, int M, int N)
        {
            if (M < 0 || N < 0)
                return int.MaxValue;
            if (M == 0 || N == 0)
                return matrix[M, N];
            return matrix[M, N] + Min(minCostRecur(matrix, M - 1, N - 1), minCostRecur(matrix, M, N - 1), minCostRecur(matrix, M - 1, N));
        }
        #endregion

        #region Approach 2 - Memoization 
        public int minCostMemoization(int[,] matrix, int M, int N)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    dp[i, j] = -1;
            return minCostMemoizationUtil(matrix, M, N, dp);
        }
        public int minCostMemoizationUtil(int[,] matrix, int M, int N, int[,] dp)
        {
            if (M < 0 || N < 0)
                return int.MaxValue;
            if (M == 0 || N == 0)
                return matrix[M, N];
            if (dp[M, N] != -1)
                return dp[M, N];
            return dp[M, N] = matrix[M, N] + Min(minCostMemoizationUtil(matrix, M - 1, N - 1, dp), minCostMemoizationUtil(matrix, M - 1, N, dp), minCostMemoizationUtil(matrix, M, N - 1, dp));
        }
        #endregion

        #region Tabulation
        public int minCostTabulation(int[,] matrix, int M, int N)
        {
            int[,] dp = new int[M + 1, N + 1];
            dp[0, 0] = matrix[0, 0];
            int i, j;
            for (i = 1; i <= M; i++)
                dp[i, 0] = matrix[i, 0] + dp[i - 1, 0];
            for (j = 1; j <= N; j++)
                dp[0, j] = matrix[0, j] + dp[0, j - 1];

            for(i = 1; i <= M; i++)
            {
                for(j = 1; j <= N; j++)
                {
                    dp[i,j] = matrix[i,j] + Min(dp[i-1,j-1], dp[i-1,j], dp[i,j-1]);
                }
            }
            return dp[M, N];
        }
        #endregion
        #endregion

        #region 0/1 Knapsack Problem
        // link - https://www.geeksforgeeks.org/0-1-knapsack-problem-dp-10/

        #region Approach 1 - Recursion
        public int ZeroOneKnapsackRecur(int[] weight, int w, int[] profit,int n)
        {
            // w - total weight
            // n - total number of elements

            if(n == 0 || w == 0) return 0;

            if (weight[n - 1] > w)
                return ZeroOneKnapsackRecur(weight, w, profit, n - 1);
            return Math.Max(profit[n - 1] + ZeroOneKnapsackRecur(weight, w - weight[n-1], profit, n - 1), ZeroOneKnapsackRecur(weight, w, profit, n - 1));
        }
        #endregion

        #region Approach 2 - Memoization
        public int ZeroOneKnapsackMemoization(int[] weight, int w, int[] profit, int n)
        {
            // w - total weight
            // n - total number of elements

            int[,] dp = new int[n+1,w+1];
            for (int i = 0; i <= n; i++)
                for (int j = 0; j <= w; j++)
                    dp[i, j] = -1;



            if (n == 0 || w == 0) return 0;

            if (weight[n - 1] > w)
                return ZeroOneKnapsackRecur(weight, w, profit, n - 1);
            return Math.Max(profit[n - 1] + ZeroOneKnapsackRecur(weight, w - weight[n - 1], profit, n - 1), ZeroOneKnapsackRecur(weight, w, profit, n - 1));
        }
        public int ZeroOneKnapsackMemoizationUtil(int[] weight, int w, int[] profit, int n, int[,] dp)
        {
            if (n == 0 || w == 0) return 0;

            if (dp[n, w] != 0) return dp[n, w];

            if (weight[n - 1] > w)
                return ZeroOneKnapsackMemoizationUtil(weight, w, profit, n - 1, dp);
            return Math.Max(profit[n - 1] + ZeroOneKnapsackMemoizationUtil(weight, w - weight[n - 1], profit, n - 1, dp), ZeroOneKnapsackMemoizationUtil(weight, w, profit, n - 1, dp));
        }
        #endregion

        #region Approach 3 - Tabulation
        public int ZeroOneKnapsackTabulation(int[] weight, int w, int[] profit, int n)
        {
            // w - total weight
            // n - total number of elements

            int[,] dp = new int[n+1, w+1];
            for(int i = 0;i <= n;i++)
                for(int j = 0;j <= w; j++)
                {
                    if (i == 0 || j == 0)
                        dp[i, j] = 0;
                    else if (weight[i - 1] <= w)
                        dp[i, j] = Math.Max(profit[i - 1] + dp[i - 1, w - weight[i - 1]], dp[i - 1, w]);
                    else
                        dp[i, j] = dp[i - 1, w];
                }

            return dp[n, w];
        }
        #endregion

        #endregion

    }
}
