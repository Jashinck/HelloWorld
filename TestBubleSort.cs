using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/** 
* ———————————————————————————
* | Summary | 
* ———————————————————————————
* | Authors | Heller Song (HellerSong@Outlook.com)
* ———————————————————————————
**/
namespace HSTDD.TestAlgorithm.Sort
{
	[TestClass]
	public class TestBubleSort
	{
		///		The First Trip: From the first data，the first minimum will up to top;
		///		The Second Trip: From the second data, the second minimum will up to top;
		///		The Least Compare (Negative Sequence): n-1 times
		///		The Maximum Compare (Backward Sequence): n*(n-1)/2 times
		///		Time Complexity: O(n*n)
		private void BubbleSort(int[] dataList)
		{
			if (dataList == null || dataList.Length <= 0)
				throw new ArgumentException();

			int temp = 0;

			for(int i = 0; i < dataList.Length - 1; i++)
			{
				for(int j = i + 1; j < dataList.Length; j++)
				{
					if(dataList[i] < dataList[j])
					{
						temp = dataList[i];
						dataList[i] = dataList[j];
						dataList[j] = temp;
					}
				}
			}
		}

		[TestMethod]
		public void test_bubble_sort()
		{
			int[] dataList = { 8, 23, 1, 45, 98, 53, 4 };

			BubbleSort(dataList);

			foreach (int i in dataList)
				Console.Write(i + " ");
		}
	}
}
