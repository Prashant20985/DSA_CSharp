namespace DSA.Recursion;

public class Factorial
{
    public int CalculateFactorial(int number)
    {
        if (number == 1) return 1;
        return number * CalculateFactorial(number - 1);
    }
    
    public int CalculateFactorialIterative(int number)
    {
        if (number == 0 || number == 1) return 1;
        int result = 1;
        for (int i = 2; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }
    
    public int counter = 0;
    public int[] memo = new int[1000]; // Adjust size as needed
    public int CalculateFibonacci(int n)
    {
        counter++;
        if (memo[n] != 0) return memo[n]; // Check if already calculated
        if (n <= 1) return n;
        memo[n] = CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        return memo[n];
    }
    
    public int CalculateFibonacciIterative(int n)
    {
        if (n <= 1) return n;
        int a = 0, b = 1, c = 0;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}