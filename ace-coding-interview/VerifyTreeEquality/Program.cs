namespace acecodeinterview
{
    public class Tree
    {
        public int NodeValue { get; set; }
        public Tree? Left { get; set; }
        public Tree? Right { get; set; }
        public static bool IsTreeEqual(Tree root1, Tree root2)
        {
  
            if (root1 == null && root2 == null)
            {
                return true;
            }

            if (root1 == null && root2 != null)
            {
                return false;
            }

            if (root1 != null && root2 == null)
            {
                return false;
            }

            if (root1.NodeValue != root2.NodeValue) {
                return false;
            } else {
                if (IsTreeEqual(root1.Left, root2.Left) && IsTreeEqual(root1.Right, root2.Right)) {
                    return true;
                } else {
                    return false;
                }
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Tree left = new Tree();
            left.NodeValue = 1;
            left.Left = null;
            left.Right = null;

            Tree right = new Tree();
            right.NodeValue = 1;
            right.Left = null;
            right.Right = null;

            Tree root = new Tree();
            root.NodeValue = 0;
            root.Left = left;
            root.Right = right;

            Console.WriteLine("Output suppose to be equal ");
            Console.WriteLine("Actual Output is {0} ", Tree.IsTreeEqual(left,right)?1:0);

            right.NodeValue = 2;
            right.Left = null;
            right.Right = null;
            Console.WriteLine("Output suppose to be NOT equal ");
            Console.WriteLine("Actual Output is {0} ", Tree.IsTreeEqual(left, right) ? 1 : 0);

            Console.WriteLine("Done");
        }
    }
}
