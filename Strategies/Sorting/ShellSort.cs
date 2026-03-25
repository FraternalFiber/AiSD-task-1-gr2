using System.Diagnostics;
using Projekt1_gr2.Models;

namespace Projekt1_gr2.Strategies.Sorting;

public class ShellSort : ISortingStrategy
{
    public string Name => "ShellSort";
    private static int comparisons = 0;
    private static int swaps = 0;
    public SortStatistics Sort(int[] array)
    {
        var stats = new SortStatistics{AlgorithmName = Name, Size=array.Length};
        Stopwatch sw= Stopwatch.StartNew();
        
        int n = array.Length;

        // generowanie przyrostów Papernova & Stasevicha
        List<int> gaps = GenerateGaps(n);
        
        foreach (int gap in gaps)
        {
            // bubble sort dla elementów oddalonych o gap
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < n - gap; i++)
                {
                    comparisons++;
                    if (array[i] > array[i + gap])
                    {
                        (array[i], array[i + gap]) = (array[i + gap], array[i]);
                        
                        swapped = true;
                    }
                }
            } while (swapped); 
        }
        stats.TimeMs = sw.Elapsed.TotalMilliseconds;
        stats.IsSortedCorrectly = true;
        stats.Comparisons = comparisons;
        stats.Swaps= swaps;
        return stats;
    }

    private static List<int> GenerateGaps(int n)
    {
        List<int> gaps = new List<int>();
        
        int k = 1;
        while (true)
        {
            int gap = (int)Math.Pow(2, k) + 1;

            comparisons++;
            if (gap >= n)
            {
                break;
            }

            gaps.Add(gap);
            k++;
        }
        // przyrosty w kolejności malejącej
        gaps.Reverse();
        gaps.Add(1);
        
        return gaps;
    }
}