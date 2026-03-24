using Projekt1_gr2.Models;

namespace Projekt1_gr2.Strategies.Sorting;

public interface ISortingStrategy
{
    string Name { get; }
    SortStatistics Sort(int[] array);
}