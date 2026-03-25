using System.Diagnostics;
using Projekt1_gr2.Models;
using Projekt1_gr2.Utils;

namespace Projekt1_gr2.Strategies.Sorting;

public class BubbleSort : ISortingStrategy
{
    public string Name => "Bubble Sort";

    public SortStatistics Sort(int[] array)
    {
        var stats = new SortStatistics {AlgorithmName = Name, Size = array.Length};

        Stopwatch sw = Stopwatch.StartNew();
        
        int n = array.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                // Count comparisons number
                stats.Comparisons++;

                if (array[j] > array[j + 1])
                {
                    // Count swaps number
                    stats.Swaps++;

                    // Swap
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        
        sw.Stop();
        stats.TimeMs = sw.Elapsed.TotalMilliseconds;
        stats.IsSortedCorrectly = Utils.ValidateSorting.ValidateAscending(array);
        return stats;
    }
}