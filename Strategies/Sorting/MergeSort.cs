namespace Projekt1_gr2.Strategies.Sorting;

public static class MergeSort
{
    public static void Sort(int[] array) 
    {
        if (array.Length <= 1)
            return;
        Sort(array, 0, array.Length - 1);
    }
    /// dzielenie tablic na mniejsze części
    private static void Sort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            Sort(array, left, middle);
            Sort(array, middle + 1, right);
            
            Merge(array, left, middle, right);
        }
    }
    
    private static void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;
        // tworzenie tablic pomocniczych
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, middle + 1, rightArray, 0, n2);

        int i = 0, j = 0;
        int k = left;

        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        // kopiowanie pozostałych elementów z leftArray
        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        // kopiowanie pozostałych elementów z rightArray
        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }
}