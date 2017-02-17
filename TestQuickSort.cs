using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/** 
* ———————————————————————————
* | Summary | 
* ———————————————————————————
* | Authors | Xiaoyao Zhou (XiaoyaoZhou@Outlook.com)
* ———————————————————————————
**/
namespace HSTDD.TestAlgorithm.Sort
{
	[TestClass]
	public class TestQuickSort
	{

        private static void QuickSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                ////Accomplish the Num Division to got bl(left);
                int bl = left, br = right;
                int baseNum = list[bl];
                while (bl < br)
                {
                    while (bl < br && list[br] >= baseNum) br--;

                    list[bl] = list[br];

                    while (bl < br && list[bl] <= baseNum) bl++;

                    list[br] = list[bl];
                }

                list[bl] = baseNum;

                int div = bl;

                QuickSort(list, left, div - 1);

                QuickSort(list, div + 1, right);

            }
        }




        [TestMethod]
		public void test_quick_sort()
		{
            for(int i = 1; i <= 6; i++)
            {
                List<int> list = new List<int>();

                for(int j = 0; j < 100; j++)
                {
                    Thread.Sleep(1);
                    list.Add(new Random((int)DateTime.Now.Ticks).Next(1000, 100000));
                }

                Stopwatch watch = new Stopwatch();

                watch.Start();

                QuickSort(list, 0, list.Count - 1);

                watch.Stop();

                Console.WriteLine("Run time of Quicksort:" + watch.ElapsedMilliseconds);
                Console.WriteLine("Input the front ten nums:" + string.Join(",", list.Take(10).ToList()));

            }
		}
	}
}
