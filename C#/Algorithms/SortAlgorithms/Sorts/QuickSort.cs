using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Uses "divide and conquer" strategy to sort elements.
// We take a pivot point that we compare the first and last element too.
// The pibot can be: The first or last element, a random element,
// a median element of the array.
// Selecting the middle point of the array is costly because you have to do this
// for every iteration. Instead use the median-of-three approach where you take the
// first, middle, and last elements of the array and determine the median based off
// of that.

// Each time we partition the array, the array is halved. Therefore since we have 
// N array elements and log2 N partitioning levels, the best-case scenario of 
// quicksort is O(N log N).
public class QuickSort
{
    public int[] Sort(int[] arr, int leftIndex, int rightIndex){
        var i = leftIndex;
        var j = rightIndex;
        var pivot = arr[leftIndex];

        // We traverse across the array until we reach the middle point.
        // 
        while (i <= j)
        {
            // We use i which is the leftmost index to get the element of the array.
            // When the returned element is less then the pivot, we know 
            while (arr[i] < pivot)
            {
                i++;
            }
            
            // We use j which is the rightmost index to get the element of the array.
            // As long as the pivot is greater than the returned array, then we
            // keep moving to the left of the array. 
            while (arr[j] > pivot)
            {
                j--;
            }

            // When both i and j are equal the if statment will run, increasing i
            // and decreasing j. Resulting in the next iteration stopping the while loop.
            if (i <= j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
        }

        // Recusively calls the Sort method until we reach the mid point.
        // Every we recursively call Sort, the pivot value is changed to the
        // element index given in the second parameter. 
        
        // Sorting left subarray
        if (leftIndex < j)
            Sort(arr, leftIndex, j);
        
        // Sorting right subarray
        if (i < rightIndex)
            Sort(arr, i, rightIndex);
        
        // After sorting both subarrays we return the array. 
        return arr;
    }

    void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}