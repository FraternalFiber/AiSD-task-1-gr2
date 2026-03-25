using System.Diagnostics;
using Projekt1_gr2.Models;
using Projekt1_gr2.Services;

namespace Projekt1_gr2.Strategies.Sorting;

public class QuickSortRecursive : ISortingStrategy
{
    public string Name => "QuickSortRecursive";
    private static int comparisons = 0;
    private static int swaps = 0;
    
    private static readonly Random _random = new Random();
    
    public SortStatistics Sort(int[] array)
    {
        var stats = new SortStatistics{AlgorithmName = Name, Size=array.Length};
        Stopwatch sw= Stopwatch.StartNew();
        
        Sort(array, 0, array.Length - 1);
        
        stats.TimeMs = sw.Elapsed.TotalMilliseconds;
        stats.IsSortedCorrectly = DataValidator.ValidateAscending(array);
        stats.Comparisons = comparisons;
        stats.Swaps= swaps;
        return stats;
        
    }

    private static void Sort(int[] array, int left, int right)
    {
        comparisons++;
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
        swaps++;

        int pivot = array[right];
        int i = left - 1; 
        
        for (int j = left; j < right; j++)
        {
            comparisons++;
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
                swaps++;
            }
        }

        Swap(array, i + 1, right);
        swaps++;
        
        return i + 1; // zwracamy indeks, w którym znajduje się pivot
    }

    private static void Swap(int[] array, int a, int b)
    {
        (array[a], array[b]) = (array[b], array[a]);
    }
}
