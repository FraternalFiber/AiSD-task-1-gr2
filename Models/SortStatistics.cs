namespace Projekt1_gr2.Models;

public class SortStatistics
{
    public string AlgorithmName { get; set; } = String.Empty;
    public int Size { get; set; }
    public SequenceShape Shape { get; set; }
    public double TimeMs { get; set; }
    public long Comparisons { get; set; } = 0;
    public long Swaps { get; set; } = 0;
    public long Merges { get; set; } = 0;
    public bool IsSortedCorrectly { get; set; }
    public List<int> Pivots = new();
}