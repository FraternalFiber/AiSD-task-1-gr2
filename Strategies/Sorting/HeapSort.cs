using System.Diagnostics;
using Projekt1_gr2.Models;
using Projekt1_gr2.Services;

namespace Projekt1_gr2.Strategies.Sorting;

public class HeapSort : ISortingStrategy
{
    public string Name => "HeapSort";
    private static int comparisons = 0;
    private static int swaps = 0;
    
    public SortStatistics Sort(int[] array)
    {
        var stats = new SortStatistics{AlgorithmName = Name, Size=array.Length};
        Stopwatch sw= Stopwatch.StartNew();
        
        int n = array.Length;
        
        
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }
        
        
        for (int i = n - 1; i > 0; i--)
        {
            
            (array[0], array[i])= (array[i], array[0]);
            swaps++;
           
            
            Heapify(array, i, 0);
        }
        sw.Stop();
        stats.TimeMs = sw.Elapsed.TotalMilliseconds;
        stats.IsSortedCorrectly = DataValidator.ValidateAscending(array);
        stats.Comparisons = comparisons;
        stats.Swaps = swaps;
        return stats;
    }

    
    private static void Heapify<T>(T[] array, int n, int i) where T : IComparable<T>
    {
        int largest = i;      
        int left = 2 * i + 1; 
        int right = 2 * i + 2; 
        
        comparisons++;
        if (left < n && array[left].CompareTo(array[largest]) > 0)
        {
            largest = left;
        }
        
        comparisons++;
        if (right < n && array[right].CompareTo(array[largest]) > 0)
        {
            largest = right;
        }
        
        if (largest != i)
        {
            swaps++;
            (array[i], array[largest])= (array[largest], array[i]);
            
            Heapify(array, n, largest);
        }
    }
}