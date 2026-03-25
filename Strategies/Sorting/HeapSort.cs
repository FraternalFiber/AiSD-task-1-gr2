using System;
namespace Projekt1_gr2.Strategies.Sorting;

public static class HeapSort
{
    /// <summary>
    /// Główna metoda sortująca tablicę przy użyciu algorytmu Heap Sort.
    /// </summary>
    public static void Sort<T>(T[] array) where T : IComparable<T>
    {
        int n = array.Length;

        // 1. Budowanie kopca (Max Heap)
        // Zaczynamy od ostatniego węzła, który nie jest liściem
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(array, n, i);
        }

        // 2. Wyciąganie elementów z kopca jeden po drugim
        for (int i = n - 1; i > 0; i--)
        {
            // Przenosimy aktualny korzeń (największy element) na koniec
            (array[0], array[i])= (array[i], array[0]);

            // Wywołujemy Heapify na zredukowanym kopcu
            Heapify(array, i, 0);
        }
    }

    /// <summary>
    /// Przekształca poddrzewo w kopiec binarny typu Max Heap.
    /// </summary>
    /// <param name="n">Rozmiar kopca</param>
    /// <param name="i">Indeks korzenia poddrzewa</param>
    private static void Heapify<T>(T[] array, int n, int i) where T : IComparable<T>
    {
        int largest = i;      // Inicjalizujemy największy jako korzeń
        int left = 2 * i + 1; // Lewy syn = 2*i + 1
        int right = 2 * i + 2; // Prawy syn = 2*i + 2

        // Jeśli lewy syn jest większy od korzenia
        if (left < n && array[left].CompareTo(array[largest]) > 0)
        {
            largest = left;
        }

        // Jeśli prawy syn jest większy niż dotychczasowy największy
        if (right < n && array[right].CompareTo(array[largest]) > 0)
        {
            largest = right;
        }

        // Jeśli największy element nie jest korzeniem
        if (largest != i)
        {
            (array[i], array[largest])= (array[largest], array[i]);

            // Rekurencyjnie naprawiamy zmienione poddrzewo
            Heapify(array, n, largest);
        }
    }
}