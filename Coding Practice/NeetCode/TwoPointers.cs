using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Practice
{
    public class TwoPointers
    {
        #region Question1
        //link - https://leetcode.com/problems/valid-palindrome/
        public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            int l = 0, r = s.Length-1;
            while(l < r)
            {
                var ls = (int)s[l];
                var rs = (int)s[r];
                if (((ls >= 48 && ls <= 57) || (ls >= 97 && ls <= 122)) && ((rs >= 48 && rs <= 57) || (rs >= 97 && rs <= 122)) && ls != rs)
                {
                    return false;
                }
                else if (((ls >= 48 && ls <= 57) || (ls >= 97 && ls <= 122) )&& ((rs >= 48 && rs <= 57) || (rs >= 97 && rs <= 122) )&& ls == rs)
                {
                    l++;
                    r--;
                }
                else
                {
                    if (!((ls >= 48 && ls <= 57) || (ls >= 97 && ls <= 122)))
                    {
                        l++;
                    }
                    if (!((rs >= 48 && rs <= 57) || (rs >= 97 && rs <= 122)))
                    {
                        r--;
                    }
                }
                
            }
            return true;
        }
        #endregion

        #region Question2
        //link - https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

        //it has 3 different solution. link -https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/discuss/51249/Python-different-solutions-(two-pointer-dictionary-binary-search).

        public int[] TwoSum(int[] numbers, int target)
        {
            int l = 0, r = numbers.Length - 1;
            int[] ans = new int[2];
            while (l < r)
            {
                if ((numbers[l] + numbers[r]) == target)
                {
                    ans[0] = l + 1;
                    ans[1] = r + 1;
                    break;
                }
                else if ((numbers[l] + numbers[r]) < target)
                    l++;
                else
                    r--;
            }
            return ans;
        }
        #endregion

        #region Question3
        //link - https://leetcode.com/problems/3sum/
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(nums);
            for(int i = 0;i<(nums.Length-2);i++)
            {
                int item = nums[i];
                int target = -1 * item;
                int l = i + 1, r = nums.Length - 1;
                while (l < r)
                {
                    if ((nums[l] + nums[r]) == target)
                    {
                        IList<int> anss = new List<int>();
                        anss.Add(item);
                        anss.Add(nums[l]);
                        anss.Add(nums[r]);
                        var a = ans.Where(x => x[0] == item && x[1] == nums[l] && x[2] ==nums[r]).ToList();
                        if (!(a!= null && a.Count>0))
                        {
                            ans.Add(anss);
                        }
                        l++;
                        r--;
                    }
                    else if ((nums[l] + nums[r]) < target)
                        l++;
                    else
                        r--;
                }
            }
            return ans;
        }
        #endregion

        #region Question4
        //link - https://leetcode.com/problems/container-with-most-water/
        public int MaxArea(int[] height)
        {
            int l = 0, r = height.Length - 1;
            int w = 0;
            while (l < r)
            {
                w = Math.Max(w, (r - l) * Math.Min(height[l], height[r]));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return w;
        }
        #endregion
    }
}
