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
            int[] nums = { 1, 2, 3 };
            var a = Subsets(nums);
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
            for(int i = start;i< nums.Length; i++)
            {
                tmpList.Add(nums[i]);
                SubsetsBackTrack(list,tmpList,nums,i+1);
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
            for(int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                    continue;
                tmpList.Add(nums[i]);
                SubsetsWithDupBacktract(list,tmpList,nums,i+1);
                tmpList.RemoveAt(tmpList.Count - 1);
            }
        }
        
        #endregion
    }
}
