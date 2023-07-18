using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.StringFolder
{
    public class String
    {
        #region Question 1 - Reverse words in a given string
        // link - https://practice.geeksforgeeks.org/problems/reverse-words-in-a-given-string5459/1
        public string reverseWords(string s)
        {
            var stringArray = s.Split('.');
            stringArray = stringArray.Reverse().ToArray();
            return string.Join('.', stringArray);
        }
        #endregion

        #region Question 2 - Permutations of a given string
        // link - https://practice.geeksforgeeks.org/problems/permutations-of-a-given-string2041/1

        #region Approach 1 - using backtraking
        public HashSet<string> find_permutation(string S)
        {
            HashSet<string> result = new HashSet<string>();
            find_permutation(S, 0, S.Length - 1, result);
            return result;
        }
        public void find_permutation(string S, int l, int r, HashSet<string> result)
        {
            if (l == r)
                result.Add(S);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    S = swap(S, i, l);
                    find_permutation(S, l + 1, r, result);
                    swap(S, i, l);
                }
            }
        }
        public string swap(string S, int i, int l)
        {
            var arr = S.ToCharArray();
            var temp = arr[i];
            arr[i] = arr[l];
            arr[l] = temp;
            return new string(arr);
        }
        #endregion
        public HashSet<string> find_permutation1(string S)
        {
            var resultList = new HashSet<string>();
            find_permutationUtil1(S, "", resultList);
            return resultList;
        }
        public void find_permutationUtil1(string S, string answer, HashSet<string> resultList)
        {
            if (S.Length == 0)
                resultList.Add(answer);
            else
            {
                for (int i = 0; i < S.Length; i++)
                {
                    char ch = S[i];
                    string leftStr = S.Substring(0, i);
                    string rightStr = S.Substring(i + 1);
                    string rest = leftStr + rightStr;
                    find_permutationUtil1(rest, answer + ch, resultList);
                }
            }
        }
        #endregion
    }
}
