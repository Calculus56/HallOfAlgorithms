using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using Globals;

/*
    Designed to check and retrieve an element from a data structure.
*/
class SearchAlgorithms {

    public void LinearSearchRun(int[] arr, int value_to_find){
        Console.Write("Given Array is [{0}]\n", string.Join(", ", arr));

        var obj = new object[]{arr, value_to_find};
        Timing.RunMethodAndStopWatch<LinearSearch>(new LinearSearch(), obj, "Linear Search Run");
    }

    public void BinarySearchRun(int vertices, (int, int)[] edges, int start_node){
        Console.WriteLine("Given Edges is [{0}]\n", string.Join(", ", edges));
        var binary_search = new BinarySearch();
        var obj = new object[]{start_node};

        var graph = binary_search.SetupGraph(vertices, edges);
        Timing.RunMethodAndStopWatch<BinarySearch.Graph>(graph, obj, "DFS");
        graph = binary_search.SetupGraph(vertices, edges);
        Timing.RunMethodAndStopWatch<BinarySearch.Graph>(graph, obj, "BFS");
    }
    
}