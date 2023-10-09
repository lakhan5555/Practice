using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class Greedy
    {
        public void Main()
        {
            int[] s = { 1, 4, 5, 9, 2, 7 };
            int[] f = { 2, 4, 10, 10, 4, 8 };
            var ans = ActivitySelection(s, f);
        }

        #region Activity selection 
        // link - https://www.geeksforgeeks.org/activity-selection-problem-greedy-algo-1/
        public List<int> ActivitySelection(int[] start, int[] finish)
        {
            List<int> ans = new List<int>();
            List<int> indices = new List<int>();
            int n = start.Length;
            for(int i = 0;i < n; i++)
            {
                indices.Add(i);
            }

            indices.Sort((a,b) => finish[a].CompareTo(finish[b]));
            ans.Add(indices[0]);

            int prevFinishTime = finish[indices[0]];
            for(int i = 1;i < n; i++)
            {
                int currIndex = indices[i];
                int currentStartTime = start[currIndex];

                if(currentStartTime >= prevFinishTime)
                {
                    ans.Add(currIndex);
                    prevFinishTime = finish[currIndex];
                }
            }
            return ans;
        }
        #endregion

        #region Gas Station
        // link - https://leetcode.com/problems/gas-station/solutions/1706142/java-c-python-an-explanation-that-ever-exists-till-now/
        #region Approach 1 - Brute force. Time - O(n*2), Space - O(1)
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int n = gas.Length;
            for (int i = 0; i < n; i++)
            {
                int count = 0, j = i, fuel = 0;
                while (count < n)
                {
                    fuel += gas[j % n] - cost[j % n];
                    if (fuel < 0) break;
                    count++;
                    j++;
                }
                if (count == n && fuel >= 0) return i;
            }
            return -1;
        }
        #endregion
        #region Approach 2 - Time - O(n). Space - O(1)

        public int CanCompleteCircuit1(int[] gas, int[] cost)
        {
            int total_surplus = 0, surplus = 0, start = 0;
            for(int i = 0; i < gas.Length; i++)
            {
                total_surplus += gas[i] - cost[i];
                surplus += gas[i] - cost[i];
                if(surplus < 0)
                {
                    surplus = 0;
                    start = i + 1;
                }
            }
            return total_surplus >= 0 ? start : -1;
        }
        #endregion
        #endregion

        #region Jump Game
        #region Approach 1 - 
        public bool CanJump(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return true;
            nums[0] *= -1;
            for (int i = 0; i < n - 1; i++)
            {
                int jump = nums[i];
                if (jump < 0)
                {
                    int j = i + 1;
                    jump = Math.Abs(jump);
                    while (jump > 0 && j < n)
                    {
                        if (j == n - 1)
                            return true;
                        nums[j] = Math.Abs(nums[j]) * -1;
                        jump--;
                        j++;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Approach2 -
        public bool CanJump1(int[] nums)
        {
            int reachable = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if(i > reachable) return false;
                reachable = Math.Max(reachable, i + nums[i]);
            }
            return true;
        }
        #endregion

        #region Approach3 -
        public bool CanJump2(int[] nums)
        {
            int n = nums.Length;
            int last = n-1;
            for (int i = n-2;i >= 0;i--)
            {
                if (i + nums[i] >= last) last = i;
            }
            return last <= 0;
        }
        #endregion

        #endregion

        #region Jump 2
        #region Approach 1 - Brute force. Time - O(N!), Space - O(N)
        public int Jump(int[] nums, int pos = 0)
        {
            if (pos >= nums.Length - 1) return 0;
            int minJump = int.MaxValue;
            for(int i = 1;i <= nums[pos]; i++)
            {
                minJump = Math.Min(minJump, 1 + Jump(nums,i+pos));
            }
            return minJump;
        }
        #endregion

        #region Approach2 - Greedy. Time -O(N), Space - O(1)
        public int Jump2(int[] nums)
        {
            int endCur = 0, farthestCur = 0, jump = 0;
            for(int i = 0; i < nums.Length-1; i++)
            {
                farthestCur = Math.Max(farthestCur, i + nums[i]);
                if(i == endCur)
                {
                    jump++;
                    endCur = farthestCur;
                }
            }
            return jump;
        }
        #endregion
        #endregion



    }
}
