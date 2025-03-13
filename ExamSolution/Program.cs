namespace ExamSolution;

class Program
{
    public static int BiggestLongest(int[] arr)
    {
        // need to initialize the sum and maxSum to the first element because the loop starts from the second element
        int sum = arr[0];
        int maxSum = 0;
        int length = 1;
        int maxLength = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            // if the current element is greater than the previous element, add it to the sum and increment the length
            if (arr[i-1] < arr[i])
            {
                sum += arr[i];
                length++;
            }
            // if the current element is not greater than the previous element, reset the sum and length
            else
            {
                sum = arr[i];
                length = 1;
            }

            // update the maxSum and maxLength
            maxLength = Math.Max(length, maxLength);
            if (maxLength == length)
                maxSum = Math.Max(sum, maxSum);
        }

        return maxSum;
    }

    public static void DecodeOnce(int[] arr, int x)
    {
        // shift the array to the left once and remove x from each element
        int temp = arr[0] - x;
        for (int i = 1; i < arr.Length; i++)
        {
            arr[i - 1] = arr[i] - x;
        }
        arr[arr.Length - 1] = temp;
    }

    public static int[] DeCode(int[] source, int x, int y)
    {
        // copy the array to avoid modifying the original array
        int[] copy = new int[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            copy[i] = source[i];
        }
        // make sure y is positive
        y = y < 1 ? 1 : y;
        // decode y times
        for (int i = 0; i < y; i++)
        {
            DecodeOnce(copy, x);
        }

        return copy;
    }

    static void Main(string[] args)
    {
        int[] arr = { 0, 10, 6, 8, 11, 9, 17 };
        Console.WriteLine(string.Join(", ", DeCode(arr, 2, 3)));

        int[] arr2 = { 3, 5, 6, 6, 7, 8, 9, 2, 3, 4, 5, 4, 6, 7, 8 } ;
        Console.WriteLine(BiggestLongest(arr2));
    }
}
