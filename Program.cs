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
        manager.AddAlgorithm(new ShellSort());
        manager.AddAlgorithm(new MergeSort());
        manager.AddAlgorithm(new HeapSort());
        manager.AddAlgorithm(new QuickSortIterative());
        manager.AddAlgorithm(new QuickSortRecursive());
        
        // Register generating algorithms
        manager.AddGenerator(new RandomGenerator());
        manager.AddGenerator(new AscendingGenerator());
        manager.AddGenerator(new DescendingGenerator());
        manager.AddGenerator(new AShapeGenerator());
        manager.AddGenerator(new VShapeGenerator());
        
        // TODO: Add more n values
        int[] nValues = { 100, 500, 1000, 2000, 5000}; 
        int repetitions = 10;
        
        manager.Run(nValues, repetitions);

        Console.WriteLine("Testing ended. Press any key to exit.");
    }
}