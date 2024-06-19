using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class LinearSearch
{
    /*
        Linear Search is where we check every element until we find the target value.
        Time Complexity: O(n)
    */
    public int LinearSearchRun(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
}