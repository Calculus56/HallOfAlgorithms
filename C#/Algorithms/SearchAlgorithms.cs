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
        Timing.RunMethodAndStopWatch<SearchAlgorithms>(new SearchAlgorithms(), obj, "Linear Search");
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
                
                Console.Write("Visted Order: ");
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

                Console.Write("Visted Order: ");
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