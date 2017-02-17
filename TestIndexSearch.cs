using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HSTDD.TestAlgorithm.Search
{
    [TestClass]
    public class TestIndexSearch
    {

        class IndexItem
        {
            public int index;
            public int start;
            public int length;
        }

        static int[] students =
        {
            101,102,103,104,105,0,0,0,0,0,
            201,202,203,204,0,0,0,0,0,0,
            301,302,303,0,0,0,0,0,0,0
        };

        static IndexItem[] indexItem =
        {
            new IndexItem() {index=1,start=0,length=5 },
            new IndexItem(){ index=2, start=10, length=4},
            new IndexItem(){ index=3, start=20, length=3},
        };

        public static int indexSearch(int key)
        {
            IndexItem item = null;
            var index = key / 100;
            for(int i=0;i<indexItem.Count();i++)
            {
                if(indexItem[i].index==index)
                {
                    item = new IndexItem() { start = indexItem[i].start, length = indexItem[i].length };
                    break;
                }
            }

            if (item == null)
                return -1;

            for(int i=item.start;i<item.start+item.length;i++)
            {
                if(students[i]==key)
                {
                    return i;
                }

            }
            return -1;

        }

        public static int insert(int key)
        {
            IndexItem item = null;
            var index = key / 100;
            int i = 0;
            for(i=0;i<indexItem.Count();i++)
            {
                if(indexItem[i].index==index)
                {
                    item = new IndexItem()
                    {
                        start = indexItem[i].start,
                        length = indexItem[i].length
                    };
                    break;
                }
            }

            if (item == null)
                return -1;

            students[item.start + item.length] = key;

            indexItem[i].length++;

            return 1;
        }

        [TestMethod]
        public void test_index_search()
        {
            Console.WriteLine("The Initial Data:" + string.Join(",", students));

            int value = 205;
            Console.WriteLine("\n Insert Data:" + value);

            var index = insert(value);

            if(index==1)
            {
                Console.WriteLine("\n Insert Data:" + string.Join(",", students));
                Console.WriteLine("\n Data element: 301 at" + indexSearch(301) + "index");
            }

            Console.ReadLine();

        }
    }
}
