using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;
using Projekt1_gr2.Models;
using Projekt1_gr2.Services;

namespace Projekt1_gr2.Strategies.Sorting;

public class BubbleSort : ISortingStrategy
{
    public string Name => "BubbleSort";
    
    public SortStatistics Sort(int[] arr)
    {
        var stats = new SortStatistics{AlgorithmName = Name, Size=arr.Length};
        Stopwatch sw= Stopwatch.StartNew();
        int n = arr.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            stats.Comparisons++;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    stats.Swaps++;
                    (arr[j], arr[j + 1]) = (arr[j+1], arr[j]);
                }
            }
            if (!swapped)
                break;
        }
        sw.Stop();
        stats.TimeMs = sw.Elapsed.TotalMilliseconds;
        stats.IsSortedCorrectly = true;
        return stats;
    }
}