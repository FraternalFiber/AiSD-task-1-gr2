namespace Projekt1_gr2.Models;


public class SortStatistics
{
    public string AlgorithmName { get; set; }
    public SequenceShape Shape { get; set; }
    public double Time { get; set; }
    public long Comparisons { get; set; }
    public long Swaps { get; set; } 
    public List<string> Metadata { get; set; } = new List<string>(); 
    public bool IsSortedCorrectly { get; set; }
}