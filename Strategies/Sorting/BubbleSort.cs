using System.Diagnostics;
using Projekt1_gr2.Models;
using Projekt1_gr2.Services;

namespace Projekt1_gr2.Strategies.Sorting;

public class BubbleSort : ISortingStrategy
{
    public string Name => "BubbleSort";
    
    public SortStatistics Sort(int[] array)
    {
        var stats = new SortStatistics{AlgorithmName = Name, Size=array.Length};
        Stopwatch sw= Stopwatch.StartNew();
        int n = array.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                stats.Comparisons++;
                if (array[j] > array[j + 1])
                {
                    stats.Swaps++;
                    (array[j], array[j + 1]) = (array[j+1], array[j]);
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }
        sw.Stop();
        stats.TimeMs = sw.Elapsed.TotalMilliseconds;
        stats.IsSortedCorrectly = DataValidator.ValidateAscending(array);
        return stats;
    }
}