using Projekt1_gr2.Models;

namespace Projekt1_gr2.Strategies.Generation;

public class RandomGenerator : ISequenceGenerator
{
    public SequenceShape Shape => SequenceShape.Random;
    private readonly Random _rng = new Random();

    public int[] Generate(int size)
    {
        int[] array = new int[size];
        int maxValue = 10 * size;

        for (int i = 0; i < size; i++)
        {
            array[i] = _rng.Next(1,  maxValue + 1);
        }
        
        return array;
    }
}