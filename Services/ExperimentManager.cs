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
        /*
         * W pliku CSV:
         * nazwa_algorytmu ; n (długość) ; kształt ; czy_poprawnie ; czas_sortowania ; liczba_operacji
         */
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
                    Console.WriteLine($"n: {result.Size} | shape: {shape} | time: {result.TimeMs} | comparisons: {result.Comparisons} | swaps: {result.Swaps} | sorted correctly: {result.IsSortedCorrectly}");
                }
            }
        }
    }
}