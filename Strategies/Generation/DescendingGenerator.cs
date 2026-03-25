using Projekt1_gr2.Models;

namespace Projekt1_gr2.Strategies.Generation;

public class DescendingGenerator : ISequenceGenerator
{
    public SequenceShape Shape => SequenceShape.Descending;
    
    public int[] Generate(int size)
    {
        int[] array = new int[size];
        
        for (int i = 0; i < size; i++)
        {
            array[i] = (size - i) * 10; 
        }
        
        return array;
    }
}