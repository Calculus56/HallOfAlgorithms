using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Driver{
    static void Main(string[] args)
    {
        RunSortAlg();
    }
    
    static void RunSearchAlg(){
        SearchAlgorithms search_alg = new SearchAlgorithms();
        /*
        SEARCH ALGORITHMS
        */

        // Linear Search
        search_alg.LinearSearchRun(new int[]{ 1, 2, 3 }, 2);
        
        // Binary Search (DFS and BFS)
        var graph_edges = new (int, int)[]{
            (0, 1),
            (0, 2),
            (2, 0),
            (2, 3),
            (3, 3)
        };

        search_alg.BinarySearchRun(4, graph_edges, 2);
    }

    static void RunSortAlg(){
        SortAlgorithms sort_alg = new SortAlgorithms(new int[]{ 38, 27, 43, 15, 45, 10});
        // sort_alg.MergeSortRun();
        sort_alg.QuickSortRun();
    }
}