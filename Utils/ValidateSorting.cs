namespace Projekt1_gr2.Utils;

public static class ValidateSorting
{
    public static bool ValidateAscending(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }
        
        return true;
    }
}