using System.Globalization;
using CsvHelper;
using Projekt1_gr2.Models;
using Projekt1_gr2.Strategies.Generation;
using Projekt1_gr2.Strategies.Sorting;

namespace Projekt1_gr2.Services;

public class ExperimentManager
{
    private readonly List<ISortingStrategy> _algorithms = new();
    private readonly List<ISequenceGenerator> _generators = new();
    
    public void AddAlgorithm(ISortingStrategy algorithm) => _algorithms.Add(algorithm);
    public void AddGenerator(ISequenceGenerator generator) => _generators.Add(generator);

    public void Run(int[] nValues, int repetitions)
    {
        // Create CSV file
        using var writer = new StreamWriter("result.csv");
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                    
        csv.WriteHeader<SortStatistics>();
        csv.NextRecord();
        
        // Loop for every value n = {1000, 2000, 5000, ...}
        foreach (int n in nValues)
        {
            Console.WriteLine($"=== TESTOWANIE DLA n = {n} ===");
            
            // 1. Prepare test data
            List<(int[] Data, SequenceShape Shape)> testSuite = new();
            
            for (int i = 0; i < repetitions; i++)
            {
                // Choose generator
                var generator = _generators[i % _generators.Count];
                testSuite.Add((generator.Generate(n), generator.Shape));
            }
            
            // 2. Loop through algorithms
            foreach (var algorithm in _algorithms)
            {
                Console.WriteLine($"--- Algorytm: {algorithm.Name} ---");
                
                // 3. Repeat sorting to sort all test data
                for (int i = 0; i < repetitions; i++)
                {
                    var (originalData, shape) = testSuite[i];
                    
                    int[] dataCopy = (int[])originalData.Clone();

                    var result = algorithm.Sort(dataCopy);
                    result.Shape = shape;
                    
                    // Write record to console
                    Console.WriteLine($"n: {result.Size} | shape: {result.Shape} | time: {result.TimeMs} | comparisons: {result.Comparisons} | swaps: {result.Swaps} | sorted correctly: {result.IsSortedCorrectly}");
                    
                    // Write record to CSV file
                    csv.WriteRecord(result);
                    csv.NextRecord();
                }
            }
        }
    }
}