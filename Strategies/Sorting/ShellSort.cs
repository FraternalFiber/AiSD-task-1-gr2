namespace Projekt1_gr2.Strategies.Sorting;

public static class ShellSort
{
    public static void Sort(int[] array)
    {
        if (array.Length <= 1)
            return;

        int n = array.Length;

        // generowanie przyrostów Papernova & Stasevicha
        List<int> gaps = GenerateGaps(n);
        
        foreach (int gap in gaps)
        {
            // bubble sort dla elementów oddalonych o gap
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < n - gap; i++)
                {
                    if (array[i] > array[i + gap])
                    {
                        (array[i], array[i + gap]) = (array[i + gap], array[i]);
                        
                        swapped = true;
                    }
                }
            } while (swapped); 
        }
    }

    private static List<int> GenerateGaps(int n)
    {
        List<int> gaps = new List<int>();
        
        int k = 1;
        while (true)
        {
            int gap = (int)Math.Pow(2, k) + 1;
            
            if (gap >= n)
                break;
                
            gaps.Add(gap);
            k++;
        }
        // przyrosty w kolejności malejącej
        gaps.Reverse();
        gaps.Add(1);
        
        return gaps;
    }
}