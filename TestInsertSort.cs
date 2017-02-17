using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HSTDD.TestAlgorithm.Sort
{
    [TestClass]
    public class TestInsertSort
    {
        public static void InserSort(List<int> list)
        {
            for(int i=1;i<list.Count;i++)
            {
                var temp = list[i];
                int j;

                for(j=i-1;j>=0&&temp<list[j];j--)
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = temp;
            }
        }


        [TestMethod]
        public static void test_insert_sort()
        {

            List<int> list = new List<int>() { 3, 6, 7, 2, 8, 1, 9 };

            Console.WriteLine("Befor SortNum:" + string.Join(",", list));

            InserSort(list);

            Console.WriteLine("After SortNum:" + string.Join(",", list));

        }
    }



    
}
