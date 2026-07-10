using System;
using System.Collections.Generic;

// trick: deserialize using pre-order traversal: root, left, right
// serilize also use pre-order traversal: root, left, right
//

class Program
{
    static void Main(string[] args)
    {
        /*
                 1
               /   \
              2     3
                   / \
                  4   5
        */

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        root.right.left = new TreeNode(4);
        root.right.right = new TreeNode(5);

        string serialized = Serialize(root);
        Console.WriteLine("Serialized Tree:");
        Console.WriteLine(serialized);

        TreeNode restored = Deserialize(serialized);
        Console.WriteLine("\nDeserialized Tree (Preorder Print):");
        PrintPreorder(restored);
    }

    public static string Serialize(TreeNode root)
    {
        List<string> list = new List<string>();
        SerializeHelper(root, list);
        return string.Join(",", list);
    }

    private static void SerializeHelper(TreeNode node, List<string> list)
    {
        if (node == null)
        {
            list.Add("null");
            return;
        }

        list.Add(node.val.ToString());
        SerializeHelper(node.left, list);
        SerializeHelper(node.right, list);
    }

    public static TreeNode Deserialize(string data)
    {
        Queue<string> tokens = new Queue<string>(data.Split(','));
        return DeserializeHelper(tokens);
    }

    private static TreeNode DeserializeHelper(Queue<string> tokens)
    {
        string val = tokens.Dequeue();

        if (val == "null")
            return null;

        TreeNode node = new TreeNode(int.Parse(val));
        node.left = DeserializeHelper(tokens);
        node.right = DeserializeHelper(tokens);

        return node;
    }

    public static void PrintPreorder(TreeNode node)
    {
        if (node == null)
        {
            Console.Write("null ");
            return;
        }

        Console.Write(node.val + " ");
        PrintPreorder(node.left);
        PrintPreorder(node.right);
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
