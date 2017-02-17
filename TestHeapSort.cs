using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Linq;

namespace HSTDD.TestAlgorithm.Sort
{
    [TestClass]
    public class TestHeapSort
    {
        static void HeapAdjust(List<int> list,int parent,int length)
        {
            int temp = list[parent];
            int child = 2 * parent + 1;
            while(child<length)
            {
                if (child + 1 < length && list[child] < list[child + 1]) child++;
                if (temp >= list[child]) break;
                list[parent] = list[child];
                parent = child;
                child = 2 * parent + 1;
            }
            list[parent] = temp;
        }

        public static void HeapSort(List<int> list)
        {
            for(int i=list.Count/2-1;i>=0;i--)
            {
                HeapAdjust(list, i, list.Count);
            }

            for(int i=list.Count-1;i>0;i--)
            {
                int temp = list[0];
                list[0] = list[i];
                list[i] = temp;

                HeapAdjust(list, 0, i);
            }
        }
        [TestMethod]
        public void test_heap_sort()
        {
            for(int j=1;j<=5;j++)
            {
                List<int> list = new List<int>();
                for(int i=0;i<20000;i++)
                {
                    Thread.Sleep(1);
                    list.Add(new Random((int)DateTime.Now.Ticks).Next(1000, 100000));
                }

                Console.WriteLine("\n The" + j + "Time Compare:");

                Stopwatch watch = new Stopwatch();
                watch.Start();
                var result = list.OrderBy(single => single).ToList();
                watch.Stop();
                Console.WriteLine("\nQuickSort Cost Time:" + watch.ElapsedMilliseconds);
                Console.WriteLine("Output Ten Num:" + string.Join(",", result.Take(10).ToList()));

                watch = new Stopwatch();
                watch.Start();
                HeapSort(list);
                watch.Stop();
                Console.WriteLine("\nHeapSort Cost Time:" + watch.ElapsedMilliseconds);
                Console.WriteLine("Output Ten Nums" + string.Join(",", list.Take(10).ToList()));
            }
        }
    }
}
