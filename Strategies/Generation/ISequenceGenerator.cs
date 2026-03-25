using Projekt1_gr2.Models;

namespace Projekt1_gr2.Strategies.Generation;

public interface ISequenceGenerator
{
    SequenceShape Shape { get; }
    int[] Generate(int size);
}