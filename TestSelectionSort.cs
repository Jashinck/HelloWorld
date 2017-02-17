using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HSTDD.TestAlgorithm.Sort
{
    [TestClass]
    public class TestSelectionSort
    {
        static List<int> SelectionSort(List<int> list)
        {
            for(int i = 0; i < list.Count - 1; i++)
            {
                int tempIndex = i;
                for(int j = i + 1; j < list.Count; j++)
                {
                    if (list[tempIndex] > list[j])
                        tempIndex = j;
                }

                var tempData = list[tempIndex];
                list[tempIndex] = list[i];
                list[i] = tempData;

            }
            return list;
        }
        
        [TestMethod]
        public void test_selection_sort()
        {
            for(int i = 1; i <= 7; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < 10000; j++)
                {
                    Thread.Sleep(1);
                    list.Add(new Random((int)DateTime.Now.Ticks).Next(1, 10000));
                }
                Console.WriteLine("\nThe" + i + "time print:");

                Stopwatch watch = new Stopwatch();
                watch.Start();
                SelectionSort(list);
                watch.Stop();

                Console.WriteLine("\n The time cost by selection_sort:" + watch.ElapsedMilliseconds);
                Console.WriteLine("Input the front num:" + string.Join(",", list.Take(10).ToList()));

            }
        } 
    }
}
