using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.NeetCode
{
    public class MathGeometry
    {
        #region Question1 - Rotate Image
        //link - https://leetcode.com/problems/rotate-image/
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for(int i = 0;i < n / 2; i++){
                for(int j = 0;j < n; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[n - i - 1][j];
                    matrix[n - i - 1][j] = temp;
                }
            }
            for(int i = 0;i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(j > i)
                    {
                        int temp = matrix[i][j];
                        matrix[i][j] = matrix[j][i];
                        matrix[j][i] = temp;
                    }
                }
            }
        }
        #endregion

        #region Question2 - Happy Number
        //link - https://leetcode.com/problems/happy-number/
        public bool IsHappy(int n)
        {
            int slow = n, fast = n;
            do
            {
                slow = SumOfSquareOfDigits(slow);
                fast = SumOfSquareOfDigits(fast);
                fast = SumOfSquareOfDigits(fast);
            } while (slow != fast);
            return slow == 1;
        }
        public int SumOfSquareOfDigits(int n)
        {
            int sum = 0;
            while(n > 0)
            {
                int rem = n % 10;
                sum += rem * rem;
                n /= 10;
            }
            return sum;
        }
        #endregion

        #region Question 3 - Plus One 
        // link- https://leetcode.com/problems/plus-one/

        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length;
            for(int i = n-1;i>= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            int[] newDigits = new int[n + 1];
            newDigits[0] = 1;
            return newDigits;
        }
        #endregion
    }
}
