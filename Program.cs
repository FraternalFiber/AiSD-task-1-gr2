using Projekt1_gr2.Algorithms;
namespace Projekt1_gr2;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        int x = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter second number: ");
        int y = Convert.ToInt32(Console.ReadLine());
        
        int result = TestAlgorithm.Sum(x, y);
        
        Console.WriteLine($"Sum: {result}");
    }
}