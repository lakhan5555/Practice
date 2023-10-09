using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode.Revision
{
    public class BitManipulation
    {
        public void Main()
        {
            int[] arr = { 3,0,1 };
            var ans = MissingNumber(arr);
        }

        #region Question 1 - Given a set of numbers where all elements occur an even number of times except one number, find the odd occurring number
        public int FindOddNumber(int[] arr)
        {
            int x = 0;
            for(int i=0;i<arr.Length;i++)
            {
                x ^= arr[i];
            }
            return x;
        }
        #endregion

        #region Question 2 - Missing Number
        public int MissingNumber(int[] nums)
        {
            int x1 = 0, x2 = 0;
            for(int i = 0; i <= nums.Length;i++)
            {
                x1 ^= i;
                if(i < nums.Length)
                    x2 ^= nums[i];
            }
            return x1 ^ x2;
        }
        #endregion

        #region Question 3 - Single Number
        public int SingleNumber(int[] nums)
        {
            int x = 0;
            foreach(var item in nums)
                x ^= item;
            return x;
        }
        #endregion

        #region Question 4 - Number of 1 Bits
        public int HammingWeight(uint n)
        {
            uint count = 0;
            while(n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return (int)count;
        }
        #endregion

        #region Question 5 - Counting Bits
        public int[] CountBits(int n)
        {
            int[] arr = new int[n+1];
            arr[0] = 0;
            for (int i = 1; i <= n; i++)
                arr[i] = arr[i / 2] + i % 2;
            return arr;
        }
        #endregion

    }
}
