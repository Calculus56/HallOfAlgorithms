using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

/*
    Designed to check and retrieve an element from a data structure.
*/
class SearchAlgorithms {
    Stopwatch sw = new Stopwatch();
    void TimeStopwatch<T>(MethodInfo method, T classInstance, object[] obj, string algorithm){
        sw.Start();
        method.Invoke(classInstance, obj);
        sw.Stop();
        Console.WriteLine("{0} Elapsed Time={1}\n", algorithm ,sw.Elapsed);
        sw.Reset();
    }

    void RunMethodAndStopWatch<T>(T instance, object[] items, string method_name){
        var types = new List<Type>();
        items.ToList().ForEach(item => types.Add(item.GetType()));
        MethodInfo method = typeof(T).GetMethod(method_name.Replace(" ", ""), types.ToArray());
        TimeStopwatch<T>(method, instance, items, method_name);
    }

    public void LinearSearchRun(int[] vals, int value_to_find){
        Stopwatch test = new Stopwatch();
        var obj = new object[]{vals, value_to_find};

        Console.WriteLine("Given Edges is [{0}]\n", string.Join(", ", vals));
        RunMethodAndStopWatch<SearchAlgorithms>(new SearchAlgorithms(), obj, "Linear Search");
    }

    public void BinarySearchRun(int vertices, (int, int)[] vals, int start){
        Console.WriteLine("Given Edges is [{0}]\n", string.Join(", ", vals));
        var binary_search = new BinarySearch();
        var obj = new object[]{start};

        var graph = binary_search.SetupGraph(vertices, vals);
        RunMethodAndStopWatch<BinarySearch.Graph>(graph, obj, "DFS");
        graph = binary_search.SetupGraph(vertices, vals);
        RunMethodAndStopWatch<BinarySearch.Graph>(graph, obj, "BFS");
    }

    /*
        Linear Search is where we check every element until we find the target value.
        Time Complexity: O(n)
    */
    public int LinearSearch(int[] numbers, int target)
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

    // Binary Search: Depth First Search (DFS), Breath First Search (BFS)
    /*
      Time complexity: O(V + E), where V is the number of vertices
      and E is the number of edges in the graph.
     */
    public class BinarySearch {
        public class Graph {
            int V;
            List<int>[] adj;
            public Graph(int v) {
                V = v;
                adj = new List<int>[v];
                for (int i = 0; i < v; ++i) {
                    adj[i] = new List<int>();
                }
            }

            public void AddEdge((int, int) edge) {
                adj[edge.Item1].Add(edge.Item2);
            }

            public void DFSUtil(int v, bool[] visited) {
                visited[v] = true;
                Console.Write(v + " ");

                List<int> vList = adj[v];
                foreach (var n in vList) {
                    if (!visited[n])
                        DFSUtil(n, visited);
                }
            }

            /*
            Searches as far into a single path before backtracking and then searching another path.
            */
            public void DFS(int v) {
                bool[] visited = new bool[V];

                DFSUtil(v, visited);
                Console.WriteLine();
            }
            
            /*
            Search all nodes level by level. Each time a node is searched, new nodes are put into Queue.

            */
            public void BFS(int startNode)
            {
                // Create a queue for BFS, this is nessary because the order is important.
                Queue<int> queue = new Queue<int>();
                bool[] visited = new bool[V];
        
                // Mark the current node as visited and enqueue it
                visited[startNode] = true;
                queue.Enqueue(startNode);
        
                // Iterate over the queue
                while (queue.Count != 0) {
                    // Dequeue a vertex from queue and print it
                    int currentNode = queue.Dequeue();
                    Console.Write(currentNode + " ");
        
                    // Get all adjacent vertices of the dequeued
                    // vertex currentNode If an adjacent has not
                    // been visited, then mark it visited and
                    // enqueue it
                    foreach(int neighbor in adj[currentNode])
                    {
                        if (!visited[neighbor]) {
                            visited[neighbor] = true;
                            queue.Enqueue(neighbor);
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        public Graph SetupGraph(int vertices, (int, int)[]edge_ls) {
            Graph g = new Graph(vertices);

            foreach((int, int) edge in edge_ls){
                g.AddEdge(edge);
            }
            return g;
        }

    }
}