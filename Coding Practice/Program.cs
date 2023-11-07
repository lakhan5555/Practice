using Coding_Practice.NeetCode;
using Coding_Practice.Practice;
using Coding_Practice.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using Coding_Practice.Revision;
using Coding_Practice.GfgMustDo;
using Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.LinkedListFolder;
using Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.StackQueueFolder;
using Coding_Practice.Revision_2.Tree;
using Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.TreeFolder;
using Coding_Practice.Revision_2.DPFolder;
using Coding_Practice.NeetCode.Revision;
using Coding_Practice.Leetcode_TopInterviewQuestions;
using Coding_Practice.GfgMustDo.ForCompaniesLikeAmazonMicrosoftetc.ArrayFolder;

namespace Coding_Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new TopInterviewQuestions().Main();
            //IList<int> nums = new List<int> { 1, 1, 2, 2, 2, 3 };
            //var a = new Program().MinLengthAfterRemovals(nums);
            //int[] nums = { 14, 12, 14, 14, 12, 14, 14, 12, 12, 12, 12, 14, 14, 12, 14, 14, 14, 12, 12 };
            //var ans = new Program().MinOperations(nums);

            //IList<int> nums = new List<int>() { 1,2,1};
            //var ans = new Program().SumCounts(nums);

            //string s = "11000111";
            //var ans = new Program().MinChanges(s);

            //int[] nums = { 7, 12, 9, 8, 9, 15 };int k = 4;
            //var ans = new Program().FindKOr(nums, k);

            //int[] arr = { 3, 5, -1, 8, 12 };
            //var ans = ArrayChallenge(arr);

            //string str = ")(((coder)(byte))";
            //var ans = SearchingChallenge(str);
        }

        #region Quantifier research
        #region Question 1 - string challenege
        public bool IsPalindrome(string str)
        {
            int l = 0, r = str.Length - 1;
            while(l < r)
            {
                if (str[l++] != str[r--])
                    return false;
            }
            return true;
        }

        public string StringChallenge(string str)
        {
            if (IsPalindrome(str))
            {
                return "palindrome";
            }

            for (int i = 0; i < str.Length; i++)
            {
                string firstOption = str.Remove(i, 1);
                if (firstOption.Length >= 3 && IsPalindrome(firstOption))
                {
                    return str[i].ToString();
                }

                for (int j = i + 1; j < str.Length; j++)
                {
                    string secondOption = str.Remove(j, 1).Remove(i, 1);
                    if (secondOption.Length >= 3 && IsPalindrome(secondOption))
                    {
                        return str[i].ToString() + str[j];
                    }
                }
            }
            return "not possible";
        }

        #endregion

        #region Question 2 - Array challenge
        public static string ArrayChallenge(int[] arr)
        {
            Array.Sort(arr);

            int highestNum = arr[arr.Length - 1];
            int sum = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                sum += arr[i];
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (i != j)
                    {
                        sum += arr[j];
                        if (sum == highestNum)
                        {
                            return "true";
                        }
                    }
                }
                for (int k = 0; k < arr.Length - 1; k++)
                {
                    if (i != k)
                    {
                        sum -= arr[k];
                        if (sum == highestNum)
                        {
                            return "true";
                        }
                    }
                }
                sum = 0;
            }

            return "false";
        }

        #endregion

        #region Question 3 - Searching challenge
        public static int SearchingChallenge(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach(char item in str)
            {
                if (item == '(')
                    stack.Push(')');
                else if(item == ')')
                {
                    if (stack.Count == 0 || stack.Pop() != item)
                        return 0;
                }
            }
            return stack.Count == 0 ? 1 : 0;
        }
        #endregion

        #endregion

        public int FindKOr(int[] nums, int k)
        {
            int ans = 0, n = nums.Length;
            if(k  == 1)
            {
                ans = nums[0];
                for (int i = 1; i < n; i++)
                    ans = ans | nums[i];
            }
            else if (k == n)
            {
                ans = nums[0];
                for (int i = 1; i < n; i++)
                    ans = ans & nums[i];
            }
            else
            {
                int max = nums.Max();
                for(int i = 0;max >= Math.Pow(2, i); i++)
                {
                    int count = 0;
                    for(int j = 0; j < n; j++)
                    {
                        int bit = Convert.ToInt32(Math.Pow(2, i));
                        if((bit & nums[j]) == bit)
                            count++;
                        if (count == k)
                            break;
                    }
                    if(count == k)
                        ans += Convert.ToInt32(Math.Pow(2, i));
                }
            }
            return ans;
        }
        public int SumCounts(int[] nums)
        {
            int n = nums.Length, ans = 0;
            Int64 mod = Convert.ToInt64(Math.Pow(10, 9)) + 7;
            for(int i = 0; i < n; i++)
            {
                for(int j = i; j < n; j++)
                {
                    HashSet<int> set = new HashSet<int>();
                    int ans1 = 0;
                    for(int k = i; k <= j; k++)
                    {
                        if (!set.Contains(nums[k]))
                            ans1++;
                        set.Add(nums[k]);
                    }

                    if(ans1 != 0 && (ans1 > Int32.MaxValue/ ans1))
                    {
                        Int64 aa = ans1 * ans1;
                        aa = aa % mod;
                        ans += Convert.ToInt32(aa);
                    }
                    else
                        ans += ans1 * ans1;
                    ans = Convert.ToInt32(ans % mod);
                }
            }
            return ans;
        }
        public int MinChanges(string s)
        {
            int NoOf0 = 0, NoOf1 = 0, n = s.Length;
            for(int i = 0; i < n; i++)
            {
                if(i == 0)
                {
                    if (Convert.ToInt32(s[i].ToString()) == 0)
                        NoOf0++;
                    else
                        NoOf1++;
                }
                else
                {
                    int a = Convert.ToInt32(s[i].ToString());
                    if(a == 0)
                    {
                        if (s[i] == s[i - 1])
                            NoOf0--;
                        else
                            NoOf0++;
                    }
                    else
                    {
                        if (s[i] == s[i - 1])
                            NoOf1--;
                        else
                            NoOf1++;
                    }
                }
            }
            return Math.Abs(Math.Max(NoOf0, NoOf1));
        }
        public int MinOperations(IList<int> nums, int k)
        {
            int ans = 0, item;
            HashSet<int> set = new HashSet<int>();
            for (int i = nums.Count-1;i>= 0;i--)
            {
                ans++;
                item = nums[i];
                if (item <= k)
                {
                    if (!set.Contains(item))
                    {
                        set.Add(item);
                    }
                }
                if (set.Count == k)
                    return ans;
            }
            return ans;
        }
        public int MinOperations(int[] nums)
        {
            Dictionary<int,int> dict = new Dictionary<int,int>();
            int[] coins = { 2, 3 };
            foreach (var item in nums)
            {
                if (dict.ContainsKey(item))
                    dict[item]++;
                else
                    dict.Add(item, 1);
            }
            int ans = 0;
            foreach (var item in dict)
            {
                int a = minCoins(coins, 2, item.Value);
                if (a == int.MaxValue)
                    return -1;
                ans += a;
            }
            return ans;
        }
        public int minCoins(int[] coins,
                    int m, int V)
        {
            int[] table = new int[V + 1];

            table[0] = 0;

            for (int i = 1; i <= V; i++)
                table[i] = int.MaxValue;

            for (int i = 1; i <= V; i++)
            {
                for (int j = 0; j < m; j++)
                    if (coins[j] <= i)
                    {
                        int sub_res = table[i - coins[j]];
                        if (sub_res != int.MaxValue &&
                            sub_res + 1 < table[i])
                            table[i] = sub_res + 1;
                    }
            }

            return table[V];

        }
        public int Min(int n)
        {
            int ans = 0;
            if (n % 3 == 0) ans += n / 3;
            else if (n % 2 == 0)
            {
                ans += Math.Min(Min(n - 2), Min(n - 3)) + 1;
            }
            else
                return int.MaxValue;
            return ans;
        }

        public int MinimumRightShifts(IList<int> nums)
        {
            bool firstIncresing = true, firstDecrease = true, secondIncrease = false;
            int maxFirstIncreasing = nums[0], maxSecondIncreasing = 0, ans = 0;
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > nums[i - 1] && firstIncresing)
                {
                    maxFirstIncreasing = nums[i];
                }
                else if (nums[i] < nums[i - 1] && firstDecrease)
                {
                    firstDecrease = false;
                    firstIncresing = false;
                    secondIncrease = true;
                    ans++;
                    maxSecondIncreasing = nums[i];
                }
                else if (nums[i] > nums[i - 1] && secondIncrease)
                {
                    secondIncrease = true;
                    maxSecondIncreasing = nums[i];
                    ans++;
                }
                else
                    return -1;
            }
            if (maxSecondIncreasing > maxFirstIncreasing)
                return -1;
            return ans;
        }

        public int MinLengthAfterRemovals(IList<int> nums)
        {
            int i = 0, j = 1;
            while(j < nums.Count)
            {
                if (nums[i] != nums[j])
                {
                    nums.RemoveAt(j);
                    nums.RemoveAt(i);
                    if(i != 0)
                    {
                        i--;j--;
                    }
                }
                else
                {
                    i++;
                    j++;
                }
            }
            return nums.Count;
        }

        public int CountPairs(IList<IList<int>> coordinates, int k)
        {
            int ans = 0;
            for(int i = 0; i < coordinates.Count-1; i++)
            {
                for(int j = i+1;j < coordinates.Count; j++)
                {
                    var firstPoint = coordinates[i];
                    var secondPoint = coordinates[j];
                    var dist = (firstPoint[0] ^ secondPoint[0]) + (firstPoint[1] ^ secondPoint[1]);
                    if(dist == k) ans++;
                }
            }
            return ans;
        }
    }
    
    public class AbsactractClass
    {
        public void Fn1()
        {
            Console.WriteLine("Hi");
        }
    }
    public class InheritClass : AbsactractClass
    {
        public void Fn1()
        {
            Console.WriteLine("Hello");
        }
    }


    //public static class StaticClass
    //    {
    //        public static Obj obj { get; set; }
    //    }

    //    public class Obj
    //    {
    //        public string Name { get; set; }
    //    }

    //}

    //public class User
    //{
    //    public User(string s)
    //    {
    //        Console.WriteLine("Base Class");
    //    }
    //    public void Hello()
    //    {
    //        Console.WriteLine("Hello of Base");
    //    }
    //}
    //public class Student : User
    //{
    //    public Student(int x) : base("Ram")
    //    {
    //        Console.WriteLine("Inherited Class");
    //    }
    //    public void Hello()
    //    {
    //        Console.WriteLine("Hello of Inherited");
    //    }
    //}
}
