namespace Projekt1_gr2.Models;

public class SortStatistics
{
    public string AlgorithmName { get; set; } = String.Empty;
    public int Size { get; set; }
    public SequenceShape Shape { get; set; }
    public double TimeMs { get; set; }
    public long Comparisons { get; set; } = 0;
    public long Swaps { get; set; } 
    public List<string> Metadata { get; set; } = new List<string>(); 
    public bool IsSortedCorrectly { get; set; }
}