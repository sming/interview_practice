using System;

namespace QuickSort
{

    public class QuickSort
    {
        // Driver program 


        public static void Sort(int[] arr)
        {
            int highIdx = arr.Length - 1;
            int lowIdx = 0;

            RecursiveSort(arr, lowIdx, highIdx);
        }

        private static void RecursiveSort(int[] arr, int lowIdx, int highIdx)
        {
            if (highIdx > lowIdx)
            {

                int pivot = Partition(arr, lowIdx, highIdx);

                RecursiveSort(arr, lowIdx, pivot - 1);
                RecursiveSort(arr, pivot + 1, highIdx);
            }
        }

        private static int Partition(int[] arr, int lowIdx, int highIdx)
        {
            int pivot = arr[highIdx];

            // 1 7 3 5 6
            int pivotIdx = lowIdx - 1;  // we need to find where to put the pivot in this span
            for (int j = lowIdx; j < highIdx; j++)
            {
                if (arr[j] < pivot)
                {
                    pivotIdx++;

                    int tmp = arr[j];
                    arr[j] = arr[pivotIdx];
                    arr[pivotIdx] = tmp;
                }
            }

            // Now we need to put the pivot in the right place
            int tmpVal = arr[pivotIdx + 1];
            arr[pivotIdx + 1] = arr[highIdx];
            arr[highIdx] = tmpVal;

            return pivotIdx + 1;
        }
    }
}
