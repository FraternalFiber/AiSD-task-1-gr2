using Projekt1_gr2.Models;

namespace Projekt1_gr2.Strategies.Generation;

public class AShapeGenerator : ISequenceGenerator
{
    public SequenceShape Shape => SequenceShape.AShape;
    
    public int[] Generate(int size)
    {
        int[] array = new int[size];
        int left = 0;
        int right = size - 1;
        
        for (int i = 0; i < size; i++)
        {
            if (i % 2 == 0)
            {
                array[left++] = i * 10;
            }
            else
            {
                array[right--] = i * 10;
            }
        }
        
        return array;
    }
}