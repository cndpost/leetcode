using System;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;

        int[] result = MaxSlidingWindow(nums, k);

        Console.WriteLine("=== Sliding Window Maximum Test ===");
        Console.WriteLine("nums: " + string.Join(", ", nums));
        Console.WriteLine("k = " + k);
        Console.WriteLine("Result: " + string.Join(", ", result));
    }

    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        int n = nums.Length;
        int[] result = new int[n - k + 1];
        Deque<int> dq = new Deque<int>();

        for (int i = 0; i < n; i++)
        {
            if (!dq.IsEmpty() && dq.Front() <= i - k)
                dq.PopFront();

            while (!dq.IsEmpty() && nums[dq.Back()] <= nums[i])
                dq.PopBack();

            dq.PushBack(i);

            if (i >= k - 1)
                result[i - k + 1] = nums[dq.Front()];
        }

        return result;
    }
}

public class Deque<T>
{
    private LinkedList<T> list = new LinkedList<T>();

    public void PushBack(T val) => list.AddLast(val);
    public void PopBack() => list.RemoveLast();
    public void PopFront() => list.RemoveFirst();
    public T Front() => list.First.Value;
    public T Back() => list.Last.Value;
    public bool IsEmpty() => list.Count == 0;
}
