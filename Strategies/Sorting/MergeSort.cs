using System.Diagnostics;
using Projekt1_gr2.Models;
using Projekt1_gr2.Services;

namespace Projekt1_gr2.Strategies.Sorting;

public class MergeSort : ISortingStrategy
{
    public string Name => "MergeSort";
    private static int comparisons = 0;
    private static int merges = 0;
    public SortStatistics Sort(int[] array) 
    {
        var stats = new SortStatistics{AlgorithmName = Name, Size=array.Length};
        Stopwatch sw= Stopwatch.StartNew();
        Sort(array, 0, array.Length - 1);
        
        sw.Stop();
        stats.TimeMs = sw.Elapsed.TotalMilliseconds;
        stats.IsSortedCorrectly = DataValidator.ValidateAscending(array);
        stats.Comparisons = comparisons;
        stats.Merges= merges;
        return stats;
    }
    /// dzielenie tablic na mniejsze części
    private static void Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            Sort(array, left, middle);
            Sort(array, middle + 1, right);
            
            Merge(array, left, middle, right);
        }
        
    }
    
    private static void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;
        // tworzenie tablic pomocniczych
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, middle + 1, rightArray, 0, n2);

        int i = 0, j = 0;
        int k = left;

        while (i < n1 && j < n2)
        { 
            comparisons++;
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        // kopiowanie pozostałych elementów z leftArray
        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        // kopiowanie pozostałych elementów z rightArray
        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }
}