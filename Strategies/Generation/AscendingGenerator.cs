using Projekt1_gr2.Models;

namespace Projekt1_gr2.Strategies.Generation;

public class AscendingGenerator : ISequenceGenerator
{
    public SequenceShape Shape => SequenceShape.Ascending;
    
    public int[] Generate(int size)
    {
        int[] array = new int[size];
        
        for (int i = 0; i < size; i++)
        {
            array[i] = (i + 1) * 10; 
        }
        
        return array;
    }
}