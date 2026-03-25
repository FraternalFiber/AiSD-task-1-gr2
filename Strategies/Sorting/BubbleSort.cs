namespace Projekt1_gr2.Strategies.Sorting;

public static class BubbleSort
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j+1], arr[j]);
                }
            }
            if (!swapped)
                break;
        }
        
    }
}