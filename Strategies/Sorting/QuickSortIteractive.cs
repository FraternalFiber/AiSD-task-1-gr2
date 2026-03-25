using System.Diagnostics;
using Projekt1_gr2.Models;
using Projekt1_gr2.Services;

namespace Projekt1_gr2.Strategies.Sorting;

public class QuickSortIterative : ISortingStrategy
{
    public string Name => "QuickSortIterative";
    private static int comparisons = 0;
    private static int swaps = 0;
    public SortStatistics Sort(int[] array)
    {
        var stats = new SortStatistics{AlgorithmName = Name, Size=array.Length};
        Stopwatch sw= Stopwatch.StartNew();

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
        stats.TimeMs = sw.Elapsed.TotalMilliseconds;
        stats.IsSortedCorrectly = DataValidator.ValidateAscending(array);
        stats.Comparisons = comparisons;
        stats.Swaps= swaps;
        return stats;
    }
    
    private static int Partition(int[] array, int low, int high)
    {
        int mid = low + (high - low) / 2;
        
        comparisons++;
        if (array[low] > array[mid])
        {
            Swap(array, low, mid);
            swaps++;
        }
        
        comparisons++;
        if (array[low] > array[high])
        {
            Swap(array, low, high);
            swaps++;
        }
        
        comparisons++;
        if (array[mid] > array[high])
        {
            Swap(array, mid, high);
            swaps++;
        }
        
        Swap(array, mid, high);
        swaps++;
        
        int pivot = array[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            comparisons++;
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
                swaps++;
            }
        }

        Swap(array, i + 1, high);
        swaps++;
        return i + 1;
    }

    private static void Swap(int[] array, int a, int b)
    {
        (array[a], array[b]) = (array[b], array[a]);
    }
}