using System;
using System.Collections.Generic;


// amazon SDE may ask this. 
//the trick is to scan pair into required preq, if preq reaches 0, it can add to courses.
// and do a BFT. Put courses with K preqs into K-th later of the graph.
//
//
class Program
{
    static void Main(string[] args)
    {
        int n = 4;
        int[][] prereq =
        {
            new[] {0, 1},
            new[] {1, 2},
            new[] {2, 3}
        };

        List<int> order = FindCourseOrder(n, prereq);

        Console.WriteLine("=== Course Schedule Test ===");
        Console.WriteLine("Courses: " + n);
        Console.WriteLine("Prerequisites:");
        foreach (var p in prereq)
            Console.WriteLine($"  {p[0]} -> {p[1]}");

        if (order == null)
        {
            Console.WriteLine("No valid course order (cycle detected).");
        }
        else
        {
            Console.WriteLine("Valid Course Order: " + string.Join(", ", order));
        }
    }

    public static List<int> FindCourseOrder(int n, int[][] prereq)
    {
        List<int>[] graph = new List<int>[n];
        int[] indegree = new int[n];

        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (var p in prereq)
        {
            int a = p[0];
            int b = p[1];
            graph[a].Add(b);
            indegree[b]++;
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < n; i++)
            if (indegree[i] == 0)
                q.Enqueue(i);

        List<int> order = new List<int>();

        while (q.Count > 0)
        {
            int course = q.Dequeue();
            order.Add(course);

            foreach (int next in graph[course])
            {
                indegree[next]--;
                if (indegree[next] == 0)
                    q.Enqueue(next);
            }
        }

        return order.Count == n ? order : null;
    }
}
