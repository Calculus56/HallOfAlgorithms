using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class SearchAlgorithms {
    static void Main(string[] args){
        var alg = new SearchAlgorithms();
        var vals = new int[]{1, 2, 3};
        
        Console.Write(alg.LinearSearch(vals, 2));
    }
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

    // Binary Search: Depth First Search (DFS)
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

            public void AddEdge(int v, int w) {
                adj[v].Add(w);
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

            public void DFS(int v) {
                bool[] visited = new bool[V];

                DFSUtil(v, visited);
            }
        }
        void DepthFirstSearch() {
            Graph g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Following is Depth First Traversal (starting from vertex 2)");

            // Function call
            g.DFS(2);
            
            Console.ReadKey();
        }
    }
}
    /*
      Time complexity: O(V + E), where V is the number of vertices
      and E is the number of edges in the graph.
     */