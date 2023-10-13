using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class BackTracking
    {
        // cheat sheet - https://leetcode.com/problems/permutations/solutions/18239/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partioning)/
        public void main()
        {
            //int[] nums = { 2, 3, 6, 7 };
            //var a = CombinationSum(nums,7);

            string s = "aab";
            var ans = Partition(s);
        }

        #region Subsets
        // link - https://leetcode.com/problems/subsets/description/
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            SubsetsBackTrack(list, new List<int>(), nums, 0);
            return list;
        }
        public void SubsetsBackTrack(IList<IList<int>> list, IList<int> tmpList, int[] nums, int start)
        {
            list.Add(new List<int>(tmpList));
            for (int i = start; i < nums.Length; i++)
            {
                tmpList.Add(nums[i]);
                SubsetsBackTrack(list, tmpList, nums, i + 1);
                tmpList.RemoveAt(tmpList.Count - 1);
            }
        }
        #endregion

        #region Subsets II
        // link - https://leetcode.com/problems/subsets-ii/description/
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> list = new List<IList<int>>();
            SubsetsWithDupBacktract(list, new List<int>(), nums, 0);
            return list;
        }
        public void SubsetsWithDupBacktract(IList<IList<int>> list, IList<int> tmpList, int[] nums, int start)
        {
            list.Add(new List<int>(tmpList));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                    continue;
                tmpList.Add(nums[i]);
                SubsetsWithDupBacktract(list, tmpList, nums, i + 1);
                tmpList.RemoveAt(tmpList.Count - 1);
            }
        }

        #endregion

        #region Permutations
        // link - https://leetcode.com/problems/permutations/
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            PermuteBacktest(list, new List<int>(), nums);
            return list;
        }
        public void PermuteBacktest(IList<IList<int>> list, IList<int> tempList, int[] nums)
        {
            if (tempList.Count == nums.Length)
            {
                list.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (tempList.Contains(nums[i]))
                        continue;
                    tempList.Add(nums[i]);
                    PermuteBacktest(list, tempList, nums);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
        #endregion

        #region Permutations II
        // link - https://leetcode.com/problems/permutations-ii/
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Array.Sort(nums);
            PermuteUniqueBacktest(list, new List<int>(), nums, new bool[nums.Length]);
            return list;
        }
        public void PermuteUniqueBacktest(IList<IList<int>> list, IList<int> tempList, int[] nums, bool[] used)
        {
            if (tempList.Count == nums.Length)
                list.Add(new List<int>(tempList));
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]))
                        continue;
                    tempList.Add(nums[i]);
                    used[i] = true;
                    PermuteUniqueBacktest(list, tempList, nums, used);
                    used[i] = false;
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
        #endregion

        #region Combination Sum
        // link - https://leetcode.com/problems/combination-sum/
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            CombinationSumBacktest(list, new List<int>(), candidates, target, 0);
            return list;
        }
        public void CombinationSumBacktest(IList<IList<int>> list, IList<int> tempList, int[] nums, int remain, int start)
        {
            if (remain < 0) return;
            else if (remain == 0)
                list.Add(new List<int>(tempList));
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    tempList.Add(nums[i]);
                    CombinationSumBacktest(list, tempList, nums, remain - nums[i], i);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
        #endregion

        #region Combination Sum II
        // link - https://leetcode.com/problems/combination-sum-ii/
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> list = new List<IList<int>>();
            CombinationSum2Backtect(list, new List<int>(), candidates, target, 0);
            return list;
        }
        public void CombinationSum2Backtect(IList<IList<int>> list, IList<int> tempList, int[] nums, int remain, int start)
        {
            if (remain < 0) return;
            else if (remain == 0)
                list.Add(new List<int>(tempList));
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (i > start && nums[i] == nums[i - 1])
                        continue;
                    tempList.Add(nums[i]);
                    CombinationSum2Backtect(list, tempList, nums, remain - nums[i], i + 1);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
        #endregion

        #region  Palindrome Partitioning
        // link - https://leetcode.com/problems/palindrome-partitioning/
        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> list = new List<IList<string>>();
            PartitionBacktest(list, new List<string>(), s, 0);
            return list;
        }
        public void PartitionBacktest(IList<IList<string>> list, IList<string> tempList, string s, int start)
        {
            if (start == s.Length)
                list.Add(new List<string>(tempList));
            else
            {
                for (int i = start; i < s.Length; i++)
                {
                    if (isPalindrome(s, start, i))
                    {
                        tempList.Add(s.Substring(start, i - start + 1));
                        PartitionBacktest(list, tempList, s, i + 1);
                        tempList.RemoveAt(tempList.Count - 1);
                    }
                }
            }
        }
        public bool isPalindrome(string s, int low, int high)
        {
            while (low < high)
            {
                if (s[low++] != s[high--])
                    return false;
            }
            return true;
        }
        #endregion

        #region Word Search
        // link - https://leetcode.com/problems/word-search/
        public bool Exist(char[][] board, string word)
        {
            for(int i = 0;i<board.Length;i++)
            {
                for(int j = 0; j < board[i].Length;j++)
                {
                    if (ExistBacktest(board, word, i, j, 0)) 
                        return true;
                }
            }
            return false;
        }
        public bool ExistBacktest(char[][] board, string word, int row, int cell, int ind)
        {
            if (ind == word.Length)
                return true;
            if (row < 0 || row >= board.Length || cell < 0 || cell >= board[row].Length || board[row][cell] != word[ind])
                return false;
            board[row][cell] = '*';
            bool result = ExistBacktest(board, word, row+1, cell, ind+1) ||
                ExistBacktest(board, word, row-1, cell, ind+1) ||
                ExistBacktest(board, word, row, cell+1, ind+1) || 
                ExistBacktest(board, word, row, cell-1, ind + 1);
            board[row][cell] = word[ind];
            return result;
        }
        #endregion

    }
}
