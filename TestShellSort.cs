using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace HSTDD.TestAlgorithm.Sort
{
    [TestClass]
    public class TestShellSort
    {
        static void ShellSort(List<int> list)
        {
            int step = list.Count / 2;
            while (step >= 1)
            {
                for (int i = step; i < list.Count; i++)
                {
                    var temp = list[i];
                    int j;

                    for (j = i - step; j >= 0 && temp < list[j]; j = j - step)
                    {
                        list[j + step] = list[i];
                    }
                    list[j + step] = temp;
                }
                step = step / 2;
            }
        }

        [TestMethod]
        public void test_shell_sort()
        {
            for (int i = 1; i <= 6; i++)
            {
                List<int> list = new List<int>();

                //Insert 10000 random sum
                for (int j = 0; j < 100; j++)
                {
                    Thread.Sleep(1);
                    list.Add(new Random((int)DateTime.Now.Ticks).Next(1000, 100000));
                }

                Stopwatch watch = new Stopwatch();

                watch.Start();

                ShellSort(list);

                watch.Stop();

                Console.WriteLine("Run time of Quicksort:" + watch.ElapsedMilliseconds);
                Console.WriteLine("Input the front ten nums:" + string.Join(",", list.Take(10).ToList()));

            }
        }
    }
}
