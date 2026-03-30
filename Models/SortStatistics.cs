using CsvHelper.Configuration.Attributes;

namespace Projekt1_gr2.Models;

public class SortStatistics
{
    [Name("Algorithm name")]
    public string AlgorithmName { get; set; } = String.Empty;
    [Name("Length")]
    public int Size { get; set; }
    [Name("Shape")]
    public SequenceShape Shape { get; set; }
    [Name("Time (ms)")]
    public double TimeMs { get; set; }
    [Name("Comparisons")]
    public long Comparisons { get; set; } = 0;
    [Name("Swaps")]
    public long Swaps { get; set; } = 0;
    [Name("Merges")]
    public long Merges { get; set; } = 0;
    [Name("Is sorted correctly")]
    public bool IsSortedCorrectly { get; set; }
    public List<int> Gaps = [];
}