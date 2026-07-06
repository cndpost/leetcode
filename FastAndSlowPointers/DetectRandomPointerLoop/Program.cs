using System;

class Program
{
    static void Main()
    {
        // Build nodes
        Node n1 = new Node(1);
        Node n2 = new Node(2);
        Node n3 = new Node(3);
        Node n4 = new Node(4);

        // Link next pointers (normal list)
        n1.next = n2;
        n2.next = n3;
        n3.next = n4;

        // Create random loop: 2 → 4 → 2
        n1.random = n3;
        n3.random = n2;
        n2.random = n4;
        n4.random = n2;

        Console.WriteLine("=== Test 1: random loop present ===");
        bool hasLoop1 = HasRandomLoopTrace(n1);
        Console.WriteLine($"Result: {hasLoop1}");

        // Second test: break the loop
        n4.random = null;

        Console.WriteLine("\n=== Test 2: random loop broken ===");
        bool hasLoop2 = HasRandomLoopTrace(n1);
        Console.WriteLine($"Result: {hasLoop2}");
    }

    public static bool HasRandomLoopTrace(Node head)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return false;
        }

        Node slow = head.random;
        Node fast = head.random?.random;
        int step = 0;

        Console.WriteLine("Tracing random pointers (slow, fast):");

        while (slow != null && fast != null)
        {
            step++;
            Console.WriteLine(
                $"Step {step}: slow at {NodeVal(slow)}, fast at {NodeVal(fast)}");

            if (slow == fast)
            {
                Console.WriteLine(
                    $"Meeting point detected at node with value {NodeVal(slow)}");
                Console.WriteLine("=> Random pointers contain a loop.");
                return true;
            }

            slow = slow.random;
            fast = fast.random?.random;
        }

        Console.WriteLine("Reached null without meeting => no random loop.");
        return false;
    }

    private static string NodeVal(Node node)
    {
        return node == null ? "null" : node.val.ToString();
    }
}

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int v)
    {
        val = v;
    }
}
