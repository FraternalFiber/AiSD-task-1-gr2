using Projekt1_gr2.Strategies.Sorting;

namespace Projekt1_gr2;

class Program
{
    static void Main(string[] args)
    {
        int[] liczby = { 12, 11, 13, 5, 6, 7 };
        
        Console.WriteLine("Przed sortowaniem: " + string.Join(", ", liczby));
        
        ShellSort.Sort(liczby);
        
        Console.WriteLine("Po sortowaniu: " + string.Join(", ", liczby));
    }
}