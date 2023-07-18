using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.Practice
{
    public class BitWise
    {
        #region Bitwise operators

        //link gfg - https://www.geeksforgeeks.org/bitwise-operators-in-c-cpp/
        #endregion

        #region Right shift operator
        //Link - https://www.youtube.com/watch?v=27p2Dcc-B5o
        #endregion

        #region Left shift operator
        //Link - https://www.youtube.com/watch?v=cy2JF6iFv8k
        #endregion

        #region Find number is odd or even
        public bool IsEven(int num)
        {
            if((num & 1) == 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Find the element that appears once

        // Given an array where every element occurs three times, except one element which occurs only once.
        // Find the element that occurs once. The expected time complexity is O(n) and O(1) extra space. 

        // link = https://www.geeksforgeeks.org/find-the-element-that-appears-once/



        #endregion
    }
}
