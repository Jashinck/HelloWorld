using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HSTDD.TestAlgorithm.Sort
{
    [TestClass]
    public class TestMergeSort
    {
        static void Merge(int[] array,int[] temparray,int left,int middle,int right)
        {
            int leftEnd = middle - 1;
            int rightStart = middle;
            int tempIndex = left;
            int tempLength = right - left + 1;
            while((left<=leftEnd)&&(rightStart<=right))
            {
                if (array[left] < array[rightStart])
                    temparray[tempIndex++] = array[left++];
                else
                    temparray[tempIndex++] = array[rightStart++];
            }

            while (left <= leftEnd)
                temparray[tempIndex++] = array[left++];

            while (rightStart <= right)
                temparray[tempIndex++] = array[rightStart++];

            for(int i=0;i<tempLength;i++)
            {
                array[right] = temparray[right];
                right--;
            }

        }

        static void MergeSort(int[] array,int[] temparray,int left,int right)
        {
            if(left<right)
            {
                int middle = (left + right) / 2;
                MergeSort(array, temparray, left, middle);
                MergeSort(array, temparray, middle + 1, right);
                Merge(array, temparray, left, middle + 1, right);
            }
        }
        [TestMethod]
        public void test_merge_sort()
        {

            int[] array = { 3, 6, 8, 2, 9, 1, 7, 5 };
            MergeSort(array, new int[array.Length], 0, array.Length - 1);
            Console.WriteLine(string.Join(",", array));

        }
    }
}
