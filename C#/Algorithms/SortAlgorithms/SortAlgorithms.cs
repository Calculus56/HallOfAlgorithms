using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globals;

/*
    Used to rearrange lists of elements in an order.
*/
class SortAlgorithms{

    int[] arr;

    public SortAlgorithms(int[] arr){
        this.arr = arr;
    }

    public void MergeSortRun()
    {
        Console.WriteLine("Given array is [{0}]", string.Join(", ", arr));

        var obj = new object[]{arr, 0, arr.Length - 1};
        //ob.Sort(arr, 0, arr.Length - 1);
        Timing.RunMethodAndStopWatch<MergeSort>(new MergeSort(), obj, "Sort");
        Console.WriteLine("\nSorted array is");
        // The array is changed even though we didn't return anything because arrays are reference types.
        PrintArray();
    }

    public void QuickSortRun(){
        Console.WriteLine("Given array is [{0}]", string.Join(", ", arr));

        var obj = new object[]{arr, 0, arr.Length - 1};
        //ob.Sort(arr, 0, arr.Length - 1);
        Timing.RunMethodAndStopWatch<QuickSort>(new QuickSort(), obj, "Sort");
        Console.WriteLine("\nSorted array is");
        // The array is changed even though we didn't return anything because arrays are reference types.
        PrintArray();
    }

    void Setup<T>(){
        Console.WriteLine("Given array is [{0}]", string.Join(", ", arr));

        var obj = new object[]{arr, 0, arr.Length - 1};
        //ob.Sort(arr, 0, arr.Length - 1);
        Timing.RunMethodAndStopWatch<T>(new T(), obj, "Sort");
        Console.WriteLine("\nSorted array is");
        // The array is changed even though we didn't return anything because arrays are reference types.
        PrintArray();
    }

    // A utility function to
    // print array of size n
    void PrintArray()
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}