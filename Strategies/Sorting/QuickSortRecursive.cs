namespace Projekt1_gr2.Strategies.Sorting;

public static class QuickSortRecursive
{
    private static readonly Random _random = new Random();

    public static void Sort(int[] array)
    {
        if (array.Length <= 1)
            return;
        Sort(array, 0, array.Length - 1);
    }

    private static void Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right);
            Sort(array, left, pivotIndex - 1);
            Sort(array, pivotIndex + 1, right);
        }
    }

    private static int Partition(int[] array, int left, int right)
    {
        int randomIndex = _random.Next(left, right + 1);
        
        // zamiana losowego elementu z ostatnim
        Swap(array, randomIndex, right);

        int pivot = array[right];
        int i = left - 1; 
        
        for (int j = left; j < right; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, right);
        
        return i + 1; // zwracamy indeks, w którym znajduje się pivot
    }

    private static void Swap(int[] array, int a, int b)
    {
        (array[a], array[b]) = (array[b], array[a]);
    }
}
