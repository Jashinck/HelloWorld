using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HSTDD.TestAlgorithm.Search
{
    [TestClass]
    public class TestSequenceSearch
    {
        static int SequenceSearch(List<int> list, int key)
        {
            for(int i=0;i<list.Count;i++)
            {
                if (key == list[i])
                    return i;
            }
            return -1;

        }

        [TestMethod]
        public void test_sequence_search()
        {
            List<int> list = new List<int>() { 2, 3, 5, 8, 7 };
            var result = SequenceSearch(list, 3);
            if (result != -1)
                Console.WriteLine("3 has been found at: " + result);
            else
                Console.WriteLine("It was not been found.");
            Console.Read();
        }
    }
}
