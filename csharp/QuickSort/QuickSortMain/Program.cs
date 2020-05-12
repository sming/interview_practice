using System;

namespace QuickSort
{
    class Program
    {
        public static void Main()
        {
            //1 5 0 7 2 9 
            int[] arr = { 10, 7, 8, 9, 1, 5 };
            QuickSort.Sort(arr);
            Console.WriteLine("sorted array ");
            PrintArray(arr);
        }

        // A utility function to print array of size n 
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }

    }
}
