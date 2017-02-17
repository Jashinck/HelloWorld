using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HSTDD.TestAlgorithm.Search
{
    [TestClass]
    public class TestBinarySearch
    {
        public static int BinarySearch(List<int> list,int key)
        {
            int low = 0;
            int high = list.Count - 1;
            while(low<=high)
            {
                var middle = (low + high) / 2;

                if (list[middle] == key)
                {
                    return middle;
                }
                else
                    if (list[middle] > key)
                    {
                        high = middle - 1;
                    }
                    else
                    {
                        low = middle + 1;
                    }

            }
            return -1;
        }
        [TestMethod]
        public void test_binary_search()
        {
            List<int> list = new List<int>() { 3, 7, 6, 8, 22, 99, 102, 221 };
            var result = BinarySearch(list, 99);
            if (result != -1)
                Console.WriteLine("99 has been found, index is:" + result);
            else
                Console.WriteLine("It has not been found.");

            Console.Read();
        }
    }
}
