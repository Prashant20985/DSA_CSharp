namespace DSA.Sorting;

public class BasicSorts
{
    // Bubble Sort implementation
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    // First loop iterates through the array from the end to the beginning.
    // Second loop iterates through the array from the start to the end.
    // If the current element is greater than the next element, they are swapped.
    // This process is repeated until the array is sorted.
    // The outer loop ensures that the largest unsorted
    // element bubbles up to its correct position in each iteration.
    // The inner loop compares adjacent elements and swaps them if they are in the wrong order.
    public static void BubbleSort(int[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    
    // Selection Sort implementation
    // Time Complexity: O(n^2)
    // Space Complexity: O(1)
    // First we find the minimum element in the unsorted portion of the array.
    // We then swap it with the first unsorted element.
    // then we find the next minimum element in the remaining unsorted portion
    // and swap it with the second unsorted element.
    // This process is repeated until the entire array is sorted.
    // The outer loop iterates through the array, treating each index as the starting point of the unsorted portion.
    // The inner loop finds the minimum element in the unsorted portion and keeps track of its index.
    // If the minimum element is not already in the correct position, it is swapped with the current index.
    // This ensures that the smallest unsorted element is placed at the beginning of the unsorted
    // portion in each iteration, gradually building a sorted array from left to right.
    // The algorithm continues until the entire array is sorted.
    public static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }
    
    // We start with the second element of the array and compare it with the elements before it.
    // If the current element is smaller than the previous elements, we shift the larger elements to
    // the right until we find the correct position for the current element.
    // This process is repeated for each element in the array until the entire array is sorted.
    public static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int temp = arr[i];
            int j = i - 1;
            // Shift elements of arr[0..i-1], that are greater than temp,
            while (j > -1 && temp < arr[j])
            {
                arr[j + 1] = arr[j];
                arr[j] = temp;
                j--;
            }
        }
    }
}