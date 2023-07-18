using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.GfgMustDo.ForProductBasedCompanies
{
    public class Maths
    {
        #region Question 1 - Missing number in array - Important - see the sln
        // link - https://practice.geeksforgeeks.org/problems/missing-number-in-array1416/1

        // normal approach sum of n natural numbers. But int that integer overflows problem arrives. so use below sln
        public int MissingNumber(int[] arr, int n)
        {
            int len = arr.Length;
            for(int i = 0;i < len; i++) 
            {
                int absVal = Math.Abs(arr[i]);
                if (absVal <= len)
                {
                    arr[absVal - 1] = -1 * arr[absVal - 1];
                }
            }
            for(int i = 0; i < len; i++)
            {
                if (arr[i] > 0)
                    return i + 1;
            }
            return n;
        }
        #endregion

        #region Question 2 - Trailing zeroes in factorial - Important Question
        // link - https://practice.geeksforgeeks.org/problems/trailing-zeroes-in-factorial5134/1
        // sln link - https://www.geeksforgeeks.org/count-trailing-zeroes-factorial-number/

        public int trailingZeroes(int N)
        {
            int count = 0;
            for(int i = 5; N / i >= 1; i *= 5)
            {
                count += N / i;
            }
            return count;
        }
        #endregion

        #region Question 3 - A Simple Fraction - Important
        // link - https://practice.geeksforgeeks.org/problems/a-simple-fraction0921/1
        // sln link - https://www.geeksforgeeks.org/represent-the-fraction-of-two-numbers-in-the-string-format/
        #endregion
    }
}
