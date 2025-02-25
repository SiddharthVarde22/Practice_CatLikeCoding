using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searching_Sorting : MonoBehaviour
{
    [SerializeField]
    int[] m_numbers;
    [SerializeField]
    int m_numberToFind;

    [SerializeField]
    bool linearSearch, binerySearch, quickSort, mergeSort, bubbleSort, InsertionSort, selectionSort;

    private void OnValidate()
    {
        if(linearSearch)
        {
            linearSearch = false;

            LinearSearch();
        }

        if(binerySearch)
        {
            binerySearch = false;

            BinarySearch();

            BinarySearch(0, m_numbers.Length);
        }

        if(selectionSort)
        {
            selectionSort = false;

            SelectionSort();
        }

        if(quickSort)
        {
            quickSort = false;

            QuickSort(m_numbers, 0, m_numbers.Length - 1);
        }

        if(bubbleSort)
        {
            bubbleSort = false;
            BubbleSort();
        }

        if(InsertionSort)
        {
            InsertionSort = false;
            InsertionSortMethod();
        }
    }

    void LinearSearch()
    {
        for(int i = 0; i < m_numbers.Length; i++)
        {
            if(m_numbers[i] == m_numberToFind)
            {
                Debug.LogError($"Found {m_numberToFind} at index {i} through linear Search");
                return;
            }
        }

        Debug.LogError("Could not found value in linear search");
    }

    void BinarySearch()
    {
        int start = 0, end = m_numbers.Length;

        while (start < end)
        {
            int l_middle = start + (end - start) / 2;
            if (m_numbers[l_middle] == m_numberToFind)
            {
                Debug.LogError($"Found {m_numberToFind} at index {l_middle} through binary search");
                return;
            }
            else if (m_numberToFind > m_numbers[l_middle])
            {
                start = l_middle + 1;
            }
            else if(m_numberToFind < m_numbers[l_middle])
            {
                end = l_middle - 1;
            }
        }

        Debug.LogError("Could not found value in binary search");
    }

    void BinarySearch(int a_start, int a_end)
    {
        if(a_end <= a_start)
        {
            return;
        }
        int l_middle = a_start + (a_end - a_start) / 2;

        Debug.Log(a_start + " , " + a_end + " , " + l_middle);
        if(m_numbers[l_middle] == m_numberToFind)
        {
            Debug.LogError($"Found {m_numberToFind} at index {l_middle} through binary search (Recurring)");
            return;
        }
        else if (m_numbers[l_middle] > m_numberToFind)
        {
            BinarySearch(a_start, l_middle - 1);
        }
        else if(m_numbers[l_middle] < m_numberToFind)
        {
            BinarySearch(l_middle + 1, a_end);
        }

        Debug.LogError("Could not found value in binary search recursion");
    }

    void QuickSort(int[] a_array, int a_start, int a_end)
    {
        if(a_start < a_end)
        {
            int pivot = Partition(a_array, a_start, a_end);

            QuickSort(a_array, a_start, pivot - 1);
            QuickSort(a_array, pivot + 1, a_end);
        }
    }

    int Partition(int[] a_array, int a_start, int a_end)
    {
        int pivot = a_end;
        int i = a_start - 1;
        int l_temp;
        for(int j = a_start; j < a_end; j++)
        {
            if(a_array[j] < a_array[pivot])
            {
                l_temp = a_array[j];
                i++;
                a_array[j] = a_array[i];
                a_array[i] = l_temp;
            }
        }

        l_temp = a_array[pivot];
        i++;
        a_array[pivot] = a_array[i];
        a_array[i] = l_temp;

        return i;
    }

    void SelectionSort()
    {
        for (int i = 0; i < m_numbers.Length; i++)
        {
            int l_smallestValueIndex = i;
            for (int j = i + 1; j < m_numbers.Length; j++)
            {
                if (m_numbers[j] <= m_numbers[l_smallestValueIndex])
                {
                    l_smallestValueIndex = j;
                }
            }

            if (l_smallestValueIndex != i)
            {
                int value = m_numbers[i];
                m_numbers[i] = m_numbers[l_smallestValueIndex];
                m_numbers[l_smallestValueIndex] = value;
            }
        }
    }

    void BubbleSort()
    {
        for (int i = 0; i < m_numbers.Length; i++)
        {
            for (int j = 0; j < m_numbers.Length - i - 1; j++)
            {
                if (m_numbers[j] > m_numbers[j + 1])
                {
                    int l_temp = m_numbers[j + 1];
                    m_numbers[j + 1] = m_numbers[j];
                    m_numbers[j] = l_temp;
                }
            }
        }
    }

    void InsertionSortMethod()
    {
        for(int i = 1; i < m_numbers.Length; i++)
        {
            int l_lastNumber = m_numbers[i];
            int j = i - 1;

            while(j >= 0 && m_numbers[j] > l_lastNumber)
            {
                m_numbers[j + 1] = m_numbers[j];
                j--;
            }

            m_numbers[j + 1] = l_lastNumber;
        }
    }
}
