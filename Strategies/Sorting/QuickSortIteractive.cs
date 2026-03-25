namespace Projekt1_gr2.Strategies.Sorting;

public class QuickSortIterative
{
    public static void Sort(int[] array)
    {
        if (array.Length <= 1)
            return;

        // stos przechowujący granice podtablic do posortowania
        Stack<(int Low, int High)> stack = new Stack<(int, int)>();

        // inicjalizacja stosu pełnym zakresem tablicy
        stack.Push((0, array.Length - 1));

        while (stack.Count > 0)
        {
            var (low, high) = stack.Pop();

            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);

                // dodajemy lewą i prawą część na stos
                if (pivotIndex - low > high - pivotIndex)
                {
                    stack.Push((low, pivotIndex - 1));
                    stack.Push((pivotIndex + 1, high));
                }
                else
                {
                    stack.Push((pivotIndex + 1, high));
                    stack.Push((low, pivotIndex - 1));
                }
            }
        }
    }
    
    private static int Partition(int[] array, int low, int high)
    {
        int mid = low + (high - low) / 2;
        
        if (array[low] > array[mid]) Swap(array, low, mid);
        if (array[low] > array[high]) Swap(array, low, high);
        if (array[mid] > array[high]) Swap(array, mid, high);
        Swap(array, mid, high);
        int pivot = array[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    private static void Swap(int[] array, int a, int b)
    {
        (array[a], array[b]) = (array[b], array[a]);
    }
}