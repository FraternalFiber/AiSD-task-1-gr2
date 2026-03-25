using Projekt1_gr2.Services;
using Projekt1_gr2.Strategies.Generation;
using Projekt1_gr2.Strategies.Sorting;

namespace Projekt1_gr2;

class Program
{
    static void Main(string[] args)
    {
        var manager = new ExperimentManager();
        
        // Register sorting algorithms
        manager.AddAlgorithm(new BubbleSort());
        
        // Register generating algorithms
        manager.AddGenerator(new RandomGenerator());
        manager.AddGenerator(new AscendingGenerator());
        manager.AddGenerator(new DescendingGenerator());
        manager.AddGenerator(new AShapeGenerator());
        manager.AddGenerator(new VShapeGenerator());
        
        // Tests
        int[] nValues = { 500, 1000, 2000 };
        int repetitions = 10;
        
        manager.Run(nValues, repetitions);

        Console.WriteLine("Testing ended. Press any key to exit.");
        Console.ReadKey();
    }
}