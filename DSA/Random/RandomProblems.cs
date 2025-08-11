namespace DSA.Random;

public class RandomProblems
{
    public string ReverseString(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public string ReverseStringWithoutArray(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        
        char[] reversed = new char[input.Length];
        int j = 0;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed[j] = input[i];
            j++;
        }
        return new string(reversed);
    }
    
    public int[] ReverseArray(int[] input)
    {
        if (input == null || input.Length == 0)
            return input;

        int[] reversed = new int[input.Length];
        int j = 0;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed[j] = input[i];
            j++;
        }
        return reversed;
    }

    // This method checks if a given string is a palindrome.
    // A palindrome reads the same backward as forward, e.g., "radar",
    public bool IsPalindrome(string input)
    {
        if (string.IsNullOrEmpty(input))
            return true;

        int left = 0;
        int right = input.Length - 1;

        while (left < right)
        {
            if (input[left] != input[right])
                return false;
            left++;
            right--;
        }
        return true;
    }
    
    // This method checks if two strings are anagrams of each other.
    // An anagram is a word or phrase formed by rearranging the letters of a different
    // word or phrase, typically using all the original letters exactly once.
    public bool AreAnagrams(string str1, string str2)
    {
        if (str1.Length != str2.Length)
            return false;

        int[] charCount = new int[256]; // Assuming ASCII characters

        for (int i = 0; i < str1.Length; i++)
        {
            charCount[str1[i]]++;
            charCount[str2[i]]--;
        }

        for (int i = 0; i < charCount.Length; i++)
        {
            if (charCount[i] != 0)
                return false;
        }
        return true;
    }
    
    // This method finds the first non-repeating character in a string.
    // A non-repeating character is a character that appears only once in the string.
    public char FirstNonRepeatingCharacter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return '\0'; // Return null character if input is empty
        var charCount = new Dictionary<char, int>();
        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        foreach (char c in input)
        {
            if (charCount[c] == 1)
                return c; // Return the first non-repeating character
        }

        return '\0'; // Return null character if no non-repeating character is found
    }
    
    // This method finds the last non-repeating character in a string.
    public char LastNonRepeatingCharacter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return '\0'; // Return null character if input is empty

        var charCount = new Dictionary<char, int>();
        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (charCount[input[i]] == 1)
                return input[i]; // Return the last non-repeating character
        }

        return '\0'; // Return null character if no non-repeating character is found
    }
    
    // This method finds the first repeating character in a string.
    public char FirstRepeatingCharacter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return '\0'; // Return null character if input is empty

        var charSet = new HashSet<char>();
        foreach (char c in input)
        {
            if (charSet.Contains(c))
                return c; // Return the first repeating character
            charSet.Add(c);
        }

        return '\0'; // Return null character if no repeating character is found
    }

    public char LastRepeatingCharacter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return '\0';
        var charSet = new HashSet<char>();
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (charSet.Contains(input[i]))
                return input[i]; // Return the last repeating character
            charSet.Add(input[i]);
        }
        return '\0'; // Return null character if no repeating character is found
    }
    
    // This method finds the maximum element in an array.
    public int FindMaxInArray(int[] input)
    {
        if (input == null || input.Length == 0)
            throw new ArgumentException("Array cannot be null or empty");

        int max = input[0];
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] > max)
                max = input[i];
        }
        return max;
    }
    
    // Two Sum Problem:
    // Given an array of integers and a target sum, find two numbers in the array that
    // add up to the target sum. Return their indices.
    public bool TwoSum(int[] nums, int target)
    {
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (nums[i] + nums[j] == target)
                    return true;
            }
        }
        return false;
    }
}