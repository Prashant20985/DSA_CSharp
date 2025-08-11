namespace DSA.Sorting;

// If we have 2 sorted list, its easy to combine it into one sorted list.
// merge sort is a divide and conquer algorithm that splits the array into halves,
// until we have arrays of size 1,
// then merges them back together in sorted order.
// until we have a single sorted array.
public class MergeSort
{
    // Helper function to merge two sorted arrays
    // Input arrays should be sorted in ascending order.
    public static int[] Merge(int[] left, int[] right)
    {
        int[] combined = new int[left.Length + right.Length];
        int index = 0; // Index for combined array
        int i = 0; // Index for left array
        int j = 0; // Index for right array
        
        // Merge the two arrays until one of them is exhausted
        while (i < left.Length && j < right.Length)
        {
            if (left[i] < right[j])
            {
                combined[index] = left[i];
                index++;
                i++;
            }
            else
            {
                combined[index] = right[j];
                index++;
                j++;
            }
        }

        // If there are remaining elements in the left array, add them
        while (i < left.Length)
        {
            combined[index] = left[i];
            index++;
            i++;
        }

        // If there are remaining elements in the right array, add them
        while (j < right.Length)
        {
            combined[index] = right[j];
            index++;
            j++;
        }
        return combined;
    }
    
    // Function to perform merge sort on an array
    public static int[] Sort(int[] arr)
    {
        if (arr.Length <= 1) return arr;
        int mid = arr.Length / 2;
        // Split the array into two halves until we reach arrays of size 1
        int[] left = Sort(arr[..mid]); // Left half inclusive of mid
        int[] right = Sort(arr[mid..]); // Right half exclusive of mid
        return Merge(left, right); // Merge the sorted halves
    }
}