
public class Challenge
{
    public static string Solution(long[] arr)
    {
        if (arr == null || arr.Length == 0)
            return "";

        long leftSum = WalkTreeRecursive(2, arr, 0);
        long rightSum = WalkTreeRecursive(3, arr, 0);

        if (leftSum == rightSum)
            return "";

        return leftSum > rightSum ? "Left" : "Right";
    }

    private static long WalkTreeRecursive(int treeIdx, long[] arr, long sum)
    {
        int actualIdx = treeIdx - 1;
        if (actualIdx > arr.Length - 1)
            return 0;

        long num = arr[actualIdx];
        if (num == -1)
            return 0;

        sum += num;

        sum += WalkTreeRecursive(treeIdx * 2, arr, sum);
        sum += WalkTreeRecursive(treeIdx * 2 + 1, arr, sum);

        return sum;
    }
}

