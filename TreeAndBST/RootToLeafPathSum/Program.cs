using System;
using System.Collections.Generic;

// tricks: need goto leaf, cannot stop in middle. Doing recursion and pass target-root.val
// down to the children. If child is true then return true. If both child not true then
// need back track by remove one node from the path and also return false. Remove the node
// is enough and no need to count the target change since target change only on child recursion
// call which is already done

class Program
{
    static void Main(string[] args)
    {
        /*
                 5
               /   \
              4     8
             /     / \
            11    13  4
           /  \        \
          7    2        1
        */

        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.right = new TreeNode(8);

        root.left.left = new TreeNode(11);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(2);

        root.right.left = new TreeNode(13);
        root.right.right = new TreeNode(4);
        root.right.right.right = new TreeNode(1);

        int target = 22;

        List<int> path = FindPathWithSum(root, target);

        Console.WriteLine($"Path with sum {target}:");
        foreach (int v in path)
            Console.Write(v + " ");
        Console.WriteLine();
    }

    public static List<int> FindPathWithSum(TreeNode root, int target)
    {
        List<int> path = new List<int>();
        if (DFS(root, target, path))
            return path;

        return new List<int>();
    }

    private static bool DFS(TreeNode node, int target, List<int> path)
    {
        if (node == null)
            return false;

        path.Add(node.val);

        if (node.left == null && node.right == null && node.val == target)
            return true;

        if (DFS(node.left, target - node.val, path))
            return true;

        if (DFS(node.right, target - node.val, path))
            return true;

        path.RemoveAt(path.Count - 1);
        return false;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int v)
    {
        val = v;
    }
}
