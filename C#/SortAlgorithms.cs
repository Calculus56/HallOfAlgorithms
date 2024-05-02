using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
    Used to rearrange lists of elements in an order.
*/
class SortAlgorithms{
    // Driver code
    public void SortMain()
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Given array is");
        PrintArray(arr);
        MergeSort ob = new MergeSort();
        ob.Sort(arr, 0, arr.Length - 1);
        Console.WriteLine("\nSorted array is");
        PrintArray(arr);
    }
    class MergeSort {
        
        // Merges two subarrays of []arr.
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        void Merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2) {
                if (L[i] <= R[j]) {
                    arr[k] = L[i];
                    i++;
                }
                else {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1) {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2) {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        public void Sort(int[] arr, int l, int r)
        {
            if (l < r) {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                Sort(arr, l, m);
                Sort(arr, m + 1, r);

                // Merge the sorted halves
                Merge(arr, l, m, r);
            }
        }
    }

    // A utility function to
    // print array of size n
    static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}