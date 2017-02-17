using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HSTDD.TestAlgorithm.Search
{
    [TestClass]
    public class TestHashSearch
    {
        //"除法取余法"
        static int hashLength = 13;

        //"原数据"
        static List<int> list = new List<int>() { 13, 23, 35, 56, 67, 79, 98 };

        //“哈希表长度”
        static int[] hash = new int[hashLength];

        static int SearchHash(int[] hash,int hashLength,int key)
        {
            int hashAddress = key % hashLength;

            while(hash[hashAddress]!=0&&hash[hashAddress]!=key)
            {
                hashAddress = (++hashAddress) % hashLength;
            }

            if (hash[hashAddress] == 0)
                return -1;
            return hashAddress;

        }

        static void InsertHash(int[] hash,int hashLength,int data)
        {
            int hashAddress = data % 13;
            while(hash[hashAddress]!=0)
            {
                hashAddress = (++hashAddress) % hashLength;
            }

            hash[hashAddress] = data;
        }

        [TestMethod]
        public void test_hash_search()
        {
            for(int i=0;i<list.Count;i++)
            {
                InsertHash(hash, hashLength, list[i]);
            }

            Console.WriteLine("Hash data: " + string.Join(",", hash));

            while(true)
            {
                Console.WriteLine("\n Please input the num for search:");
                int result = int.Parse(Console.ReadLine());
                var index = SearchHash(hash, hashLength, result);

                if (index != -1)
                    Console.WriteLine("Num" + result + "the index place:" + index);
                else
                    Console.WriteLine("The " + result + "has not been there");
            }
        }
    }
}
