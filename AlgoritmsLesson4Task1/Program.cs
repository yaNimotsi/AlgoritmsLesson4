using System;
using System.Collections.Generic;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AlgoritmsLesson4Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class Banchmark
    {
        string[] arrStr = new string[10000];
        string strToFind;
        int indexStrToFind;

        HashSet<string> hashStrings = new HashSet<string>();
        public Banchmark()
        {
            for (int i = 0; i < 10000; i++)
            {
                arrStr[i] = i.ToString();
                hashStrings.Add(i.ToString());
            }

            GetStrToFind();
        }

        public void GetStrToFind()
        {
            Random random = new Random();

            indexStrToFind = random.Next(arrStr.Length);
            strToFind = arrStr[indexStrToFind];
        }

        public bool FindStrInHashSet()
        {
            return hashStrings.Contains(strToFind);
        }

        public string FindStrInArr()
        {
            foreach(var str in arrStr)
            {
                if (str == strToFind) return str;
            }

            return null;
        }

        [Benchmark]
        public void TestFindInArr()
        {
            FindStrInArr();
        }
        [Benchmark]
        public void TestFindInHashSet()
        {
            FindStrInHashSet();
        }
    }
}
