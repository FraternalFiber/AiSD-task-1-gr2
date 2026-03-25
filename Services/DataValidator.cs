namespace Projekt1_gr2.Services;

public class DataValidator
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