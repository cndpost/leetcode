using System;

// the generic tree serializer and deserializer need to pass a token list or token queue to the child
// need a parse token or toekn to string convresion.
//
// the BST assume string data is separated by ',' and just need to print an integer or parse 
// a substring into an int.parse(string)
// 
// a generic tree need to deal with null node and preserve "null" in serialized storage.

class Program
{
    static void Main(string[] args)
    {
        /*
                 6
               /   \
              3     8
             / \   / \
            2   4 7   9
        */

        TreeNode root = new TreeNode(6);
        root.left = new TreeNode(3);
        root.right = new TreeNode(8);

        root.left.left = new TreeNode(2);
        root.left.right = new TreeNode(4);

        root.right.left = new TreeNode(7);
        root.right.right = new TreeNode(9);

        BSTCodec codec = new BSTCodec();

        string serialized = codec.Serialize(root);
        Console.WriteLine("Serialized BST:");
        Console.WriteLine(serialized);

        TreeNode restored = codec.Deserialize(serialized);
        Console.WriteLine("\nDeserialized BST (Preorder):");
        PrintPreorder(restored);
    }

    public static void PrintPreorder(TreeNode node)
    {
        if (node == null)
            return;

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

public class BSTCodec
{
    // Serialize BST using preorder traversal (no nulls)
    public string Serialize(TreeNode root)
    {
        List<int> list = new List<int>();
        Preorder(root, list);
        return string.Join(",", list);
    }

    private void Preorder(TreeNode node, List<int> list)
    {
        if (node == null)
            return;

        list.Add(node.val);
        Preorder(node.left, list);
        Preorder(node.right, list);
    }

    // Deserialize by inserting values into BST
    public TreeNode Deserialize(string data)
    {
        if (string.IsNullOrEmpty(data))
            return null;

        string[] parts = data.Split(',');
        TreeNode root = null;

        foreach (string s in parts)
        {
            int val = int.Parse(s);
            root = Insert(root, val);
        }

        return root;
    }

    private TreeNode Insert(TreeNode node, int val)
    {
        if (node == null)
            return new TreeNode(val);

        if (val < node.val)
            node.left = Insert(node.left, val);
        else
            node.right = Insert(node.right, val);

        return node;
    }
}
