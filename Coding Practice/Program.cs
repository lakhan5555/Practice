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

namespace Coding_Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new DPMain().main();
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
