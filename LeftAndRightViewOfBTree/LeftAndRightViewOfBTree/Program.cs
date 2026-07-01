using System;
using System.Collections.Generic;

public class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Build a sample tree:
        //
        //          1
        //        /   \
        //       2     3
        //      / \     \
        //     4   5     6
        //
        TreeNode root = new TreeNode(1);
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(3);
        root.Left.Left = new TreeNode(4);
        root.Left.Right = new TreeNode(5);
        root.Right.Right = new TreeNode(6);

        Console.WriteLine("Original Tree (Level Order):");
        PrintTreeLevelOrder(root);

        Console.WriteLine("\nLeft View:");
        var leftView = GetLeftView(root);
        PrintList(leftView);

        Console.WriteLine("\nRight View:");
        var rightView = GetRightView(root);
        PrintList(rightView);
    }

    // ---------------------------------------------------------
    // Print tree in level order (BFS)
    // ---------------------------------------------------------
    public static void PrintTreeLevelOrder(TreeNode root)
    {
        if (root == null)
        {
            Console.WriteLine("(empty tree)");
            return;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();
                Console.Write(node.Value + " ");

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }

            Console.WriteLine(); // new line per level
        }
    }

    // ---------------------------------------------------------
    // LEFT VIEW: first node at each level
    // ---------------------------------------------------------
    public static List<int> GetLeftView(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();

                if (i == 0)
                    result.Add(node.Value);

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }

        return result;
    }

    // ---------------------------------------------------------
    // RIGHT VIEW: last node at each level
    // ---------------------------------------------------------
    public static List<int> GetRightView(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode node = queue.Dequeue();

                if (i == levelSize - 1)
                    result.Add(node.Value);

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }

        return result;
    }

    // ---------------------------------------------------------
    // Helper: print list
    // ---------------------------------------------------------
    public static void PrintList(List<int> list)
    {
        foreach (var v in list)
            Console.Write(v + " ");
        Console.WriteLine();
    }
}
