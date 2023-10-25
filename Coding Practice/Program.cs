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

namespace Coding_Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new NeetCode.Revision.DP().main();
            //IList<int> nums = new List<int> { 1, 1, 2, 2, 2, 3 };
            //var a = new Program().MinLengthAfterRemovals(nums);
            //int[] nums = { 14, 12, 14, 14, 12, 14, 14, 12, 12, 12, 12, 14, 14, 12, 14, 14, 14, 12, 12 };
            //var ans = new Program().MinOperations(nums);
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
